using System.Threading.Tasks;

namespace TTShang.AccountManagement.Blazor;

/// <summary>
/// Blazor login service interface for handling user authentication
/// </summary>
public interface IBlazorLoginService
{
    /// <summary>
    /// Performs user login with the provided credentials
    /// </summary>
    /// <param name="userNameOrEmailAddress">Username or email address</param>
    /// <param name="password">User password</param>
    /// <param name="rememberMe">Whether to persist the login</param>
    /// <returns>Login result indicating success or failure with details</returns>
    Task<BlazorLoginResult> LoginAsync(string userNameOrEmailAddress, string password, bool rememberMe);

    /// <summary>
    /// Logs out the current user
    /// </summary>
    Task LogoutAsync();
}
