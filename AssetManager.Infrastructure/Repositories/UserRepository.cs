using AssetManager.Application.Repositories.Interfaces;
using AssetManager.Domain.Entities;
using AssetManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetByUsernameOrPhoneAsync(string? usernameOrPhone)
    {
        return await _context.Users
            .FromSqlRaw(
                """
                SELECT
                    "Id",
                    "PhoneNumber",
                    "Username",
                    "PasswordHash",
                    "CreatedAt"
                FROM "Users"
                WHERE
                    {0} IS NULL
                    OR "Username" = {0}
                    OR "PhoneNumber" = {0}
                """,
                usernameOrPhone)
            .ToListAsync();
    }
}