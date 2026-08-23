namespace AssetManager.Application.DTOs.Users;

public class LoginUserDto
{
    public string UsernameOrPhone { get; set; } = null!;

    public string Password { get; set; } = null!;
}