using AssetManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Asset> Assets { get; set; }

    public DbSet<AssetTransaction> AssetTransactions { get; set; }
}