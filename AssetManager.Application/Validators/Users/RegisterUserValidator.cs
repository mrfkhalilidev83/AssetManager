using AssetManager.Application.DTOs.Users;

namespace AssetManager.Application.Validators.Users;

public class RegisterUserValidator
{
    public void Validate(RegisterUserDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Username))
            throw new ArgumentException("Username is required.");

        if (string.IsNullOrWhiteSpace(request.PhoneNumber))
            throw new ArgumentException("Phone number is required.");

        if (string.IsNullOrWhiteSpace(request.Password))
            throw new ArgumentException("Password is required.");

        if (request.Password.Length < 8)
            throw new ArgumentException("Password must be at least 8 characters.");
    }
}