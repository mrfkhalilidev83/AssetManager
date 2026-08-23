using AssetManager.Application.Repositories.Interfaces;
using AssetManager.Application.Services;
using AssetManager.Application.Services.Interfaces;
using AssetManager.Infrastructure.Data;
using AssetManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace AssetManager.UI;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        System.Windows.Forms.Application.EnableVisualStyles();
        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

        var builder = Host.CreateApplicationBuilder();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("AssetManagerDb")));

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();

        var host = builder.Build();

        System.Windows.Forms.Application.Run(new Form1());
    }
}