namespace AssetManager.Application.DTOs.Users;

public class RegisterUserDto
{
    public string Username { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Password { get; set; } = null!;
}