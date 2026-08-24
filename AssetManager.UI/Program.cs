using AssetManager.Application.Repositories.Interfaces;
using AssetManager.Application.Security.Interfaces;
using AssetManager.Application.Services;
using AssetManager.Application.Services.Interfaces;
using AssetManager.Application.Validators.Users;
using AssetManager.Infrastructure.Data;
using AssetManager.Infrastructure.Repositories;
using AssetManager.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AssetManager.UI.Forms;

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
        builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
        builder.Services.AddScoped<RegisterUserValidator>();
        builder.Services.AddScoped<LoginUserValidator>();
        builder.Services.AddScoped<IAssetRepository, AssetRepository>();
        builder.Services.AddScoped<IAssetService, AssetService>();
        builder.Services.AddScoped<IAssetTransactionRepository, AssetTransactionRepository>();
        builder.Services.AddScoped<IDepositService, DepositService>();
        builder.Services.AddScoped<IWithdrawalService, WithdrawalService>();
        builder.Services.AddScoped<ITransactionService, TransactionService>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<LoginForm>();
        builder.Services.AddScoped<RegisterForm>();
        builder.Services.AddScoped<AssetForm>();
        builder.Services.AddScoped<DepositForm>();
        builder.Services.AddScoped<WithdrawalForm>();
        builder.Services.AddScoped<TransactionHistoryForm>();

        var host = builder.Build();

        using var scope = host.Services.CreateScope();

        var loginForm = scope.ServiceProvider.GetRequiredService<LoginForm>();

        System.Windows.Forms.Application.Run(loginForm);
    }
}