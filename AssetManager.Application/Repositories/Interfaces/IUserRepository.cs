using AssetManager.Domain.Entities;

namespace AssetManager.Application.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetByUsernameOrPhoneAsync(string? usernameOrPhone);

    Task<bool> ExistsByUsernameAsync(string username);

    Task<bool> ExistsByPhoneNumberAsync(string phoneNumber);

    Task<User> CreateAsync(User user);

    Task<User?> GetByIdAsync(int id);

    Task DeleteAsync(User user);
}