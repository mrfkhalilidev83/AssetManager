using AssetManager.Application.DTOs.Users;

namespace AssetManager.Application.Validators.Users;

public class LoginUserValidator
{
    public void Validate(LoginUserDto request)
    {
        if (string.IsNullOrWhiteSpace(request.UsernameOrPhone))
            throw new ArgumentException("Username or phone number is required.");

        if (string.IsNullOrWhiteSpace(request.Password))
            throw new ArgumentException("Password is required.");
    }
}