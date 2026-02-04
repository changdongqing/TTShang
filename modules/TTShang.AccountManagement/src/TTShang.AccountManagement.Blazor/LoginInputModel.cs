namespace TTShang.AccountManagement.Blazor;

/// <summary>
/// Login input model for the Blazor login page
/// </summary>
public class LoginInputModel
{
    public string? UserNameOrEmailAddress { get; set; }
    public string? Password { get; set; }
    public bool RememberMe { get; set; }
}

/// <summary>
/// Login result model
/// </summary>
public class BlazorLoginResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public bool IsLockedOut { get; set; }
    public bool IsNotAllowed { get; set; }
    public bool RequiresTwoFactor { get; set; }

    public static BlazorLoginResult Succeeded()
    {
        return new BlazorLoginResult { Success = true };
    }

    public static BlazorLoginResult Failed(string errorMessage)
    {
        return new BlazorLoginResult { Success = false, ErrorMessage = errorMessage };
    }

    public static BlazorLoginResult LockedOut(string errorMessage)
    {
        return new BlazorLoginResult { Success = false, IsLockedOut = true, ErrorMessage = errorMessage };
    }

    public static BlazorLoginResult NotAllowed(string errorMessage)
    {
        return new BlazorLoginResult { Success = false, IsNotAllowed = true, ErrorMessage = errorMessage };
    }

    public static BlazorLoginResult TwoFactorRequired(string errorMessage)
    {
        return new BlazorLoginResult { Success = false, RequiresTwoFactor = true, ErrorMessage = errorMessage };
    }
}
