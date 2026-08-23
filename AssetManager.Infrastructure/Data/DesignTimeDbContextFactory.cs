using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AssetManager.Infrastructure.Data;

public class DesignTimeDbContextFactory
    : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "../AssetManager.UI"))
            .AddJsonFile(
                "appsettings.json",
                optional: false)
            .Build();

        var connectionString =
            configuration.GetConnectionString("AssetManagerDb");

        var optionsBuilder =
            new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseNpgsql(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}