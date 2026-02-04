using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using TTShang.AccountManagement.Blazor;
using Volo.Abp.Account.Localization;
using Volo.Abp.DependencyInjection;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace TTShang.AccountManagement.Blazor.Server;

/// <summary>
/// Server-side implementation of the Blazor login service using ASP.NET Core Identity
/// </summary>
public class BlazorLoginService : IBlazorLoginService, ITransientDependency
{
    protected SignInManager<IdentityUser> SignInManager { get; }
    protected UserManager<IdentityUser> UserManager { get; }
    protected ILogger<BlazorLoginService> Logger { get; }
    protected IStringLocalizer<AccountResource> Localizer { get; }

    public BlazorLoginService(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        ILogger<BlazorLoginService> logger,
        IStringLocalizer<AccountResource> localizer)
    {
        SignInManager = signInManager;
        UserManager = userManager;
        Logger = logger;
        Localizer = localizer;
    }

    public virtual async Task<BlazorLoginResult> LoginAsync(
        string userNameOrEmailAddress,
        string password,
        bool rememberMe)
    {
        try
        {
            // First, resolve the user by username or email
            var user = await UserManager.FindByNameAsync(userNameOrEmailAddress);
            if (user == null)
            {
                user = await UserManager.FindByEmailAsync(userNameOrEmailAddress);
            }

            if (user == null)
            {
                Logger.LogWarning("User not found: {UserNameOrEmail}", userNameOrEmailAddress);
                return BlazorLoginResult.Failed(Localizer["InvalidUserNameOrPassword"]);
            }

            // Use the resolved username for sign-in
            var result = await SignInManager.PasswordSignInAsync(
                user.UserName,
                password,
                rememberMe,
                lockoutOnFailure: true
            );

            if (result.Succeeded)
            {
                Logger.LogInformation("User logged in successfully.");
                return BlazorLoginResult.Succeeded();
            }

            if (result.IsLockedOut)
            {
                Logger.LogWarning("User account is locked out.");
                return BlazorLoginResult.LockedOut(Localizer["UserLockedOutMessage"]);
            }

            if (result.IsNotAllowed)
            {
                return BlazorLoginResult.NotAllowed(Localizer["LoginIsNotAllowed"]);
            }

            if (result.RequiresTwoFactor)
            {
                return BlazorLoginResult.TwoFactorRequired(Localizer["RequiresTwoFactor"]);
            }

            Logger.LogWarning("Failed login attempt.");
            return BlazorLoginResult.Failed(Localizer["InvalidUserNameOrPassword"]);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Login error occurred.");
            return BlazorLoginResult.Failed(Localizer["InvalidUserNameOrPassword"]);
        }
    }

    public virtual async Task LogoutAsync()
    {
        await SignInManager.SignOutAsync();
        Logger.LogInformation("User logged out.");
    }
}
