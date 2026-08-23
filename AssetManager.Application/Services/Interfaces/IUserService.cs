using AssetManager.Application.DTOs.Users;
using AssetManager.Domain.Entities;

namespace AssetManager.Application.Services.Interfaces;

public interface IUserService
{
    Task<User> RegisterAsync(RegisterUserDto request);

    Task<User?> LoginAsync(LoginUserDto request);

    Task DeleteAccountAsync(int userId);
}