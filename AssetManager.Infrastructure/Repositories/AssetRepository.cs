using AssetManager.Application.Repositories.Interfaces;
using AssetManager.Domain.Entities;
using AssetManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Infrastructure.Repositories;

public class AssetRepository : IAssetRepository
{
    private readonly AppDbContext _context;

    public AssetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Asset?> GetByUserIdAsync(int userId)
    {
        return await _context.Assets
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task<Asset> CreateForUserAsync(int userId)
    {
        var asset = new Asset
        {
            UserId = userId,
            Gold = 0,
            Silver = 0,
            Toman = 0,
            UpdatedAt = DateTime.UtcNow
        };

        await _context.Assets.AddAsync(asset);
        await _context.SaveChangesAsync();

        return asset;
    }

    public async Task UpdateAsync(Asset asset)
    {
        _context.Assets.Update(asset);
        await _context.SaveChangesAsync();
    }
}