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

    public async Task<User?> GetByUsernameOrPhoneAsync(string usernameOrPhone)
    {
        var users = await _context.Users
            .FromSqlRaw(
                """
                SELECT *
                FROM "Users"
                WHERE "Username" = {0}
                   OR "PhoneNumber" = {0}
                LIMIT 1
                """,
                usernameOrPhone)
            .ToListAsync();

        return users.FirstOrDefault();
    }
}