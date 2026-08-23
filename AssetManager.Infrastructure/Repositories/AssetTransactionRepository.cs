using AssetManager.Application.Repositories.Interfaces;
using AssetManager.Domain.Entities;
using AssetManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Infrastructure.Repositories;

public class AssetTransactionRepository : IAssetTransactionRepository
{
    private readonly AppDbContext _context;

    public AssetTransactionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AssetTransaction transaction)
    {
        await _context.AssetTransactions.AddAsync(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task<List<AssetTransaction>> GetByUserIdAsync(int userId)
    {
        return await _context.AssetTransactions
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }
}