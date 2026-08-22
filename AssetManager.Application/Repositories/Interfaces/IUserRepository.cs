using AssetManager.Domain.Entities;

namespace AssetManager.Application.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByUsernameOrPhoneAsync(string usernameOrPhone);
}