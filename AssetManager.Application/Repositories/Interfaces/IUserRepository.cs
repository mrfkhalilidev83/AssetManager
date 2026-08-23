using AssetManager.Domain.Entities;

namespace AssetManager.Application.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetByUsernameOrPhoneAsync(string? usernameOrPhone);
}