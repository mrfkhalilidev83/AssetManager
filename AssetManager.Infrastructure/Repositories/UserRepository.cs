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

    public async Task<bool> ExistsByUsernameAsync(string username)
    {
        var result = await _context.Users
            .FromSqlRaw(
                """
                SELECT
                    "Id",
                    "PhoneNumber",
                    "Username",
                    "PasswordHash",
                    "CreatedAt"
                FROM "Users"
                WHERE "Username" = {0}
                LIMIT 1
                """,
                username)
            .ToListAsync();

        return result.Count > 0;
    }

    public async Task<bool> ExistsByPhoneNumberAsync(string phoneNumber)
    {
        var result = await _context.Users
            .FromSqlRaw(
                """
                SELECT
                    "Id",
                    "PhoneNumber",
                    "Username",
                    "PasswordHash",
                    "CreatedAt"
                FROM "Users"
                WHERE "PhoneNumber" = {0}
                LIMIT 1
                """,
                phoneNumber)
            .ToListAsync();

        return result.Count > 0;
    }
    public async Task<User> CreateAsync(User user)
    {
        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return user;
    }

}