using AssetManager.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AssetManager.UI.Forms;

public partial class AssetForm : Form
{
    private readonly IAssetService _assetService;
    private readonly IUserService _userService;
    private readonly int _userId;
    private readonly IServiceProvider _serviceProvider;

    public AssetForm(
        IAssetService assetService,
        IUserService userService,
        IServiceProvider serviceProvider,
        int userId)
    {
        InitializeComponent();

        _assetService = assetService;
        _userService = userService;
        _serviceProvider = serviceProvider;
        _userId = userId;
    }

    private async void AssetForm_Load(object sender, EventArgs e)
    {
        var user = await _userService.GetByIdAsync(_userId);

        if (user is not null)
        {
            lblWelcome.Text = $"Welcome, {user.Username}";
        }

        await LoadAssetAsync();
    }

    private async Task LoadAssetAsync()
    {
        try
        {
            var asset = await _assetService.GetByUserIdAsync(_userId);

            if (asset is null)
            {
                asset = await _assetService.CreateForUserAsync(_userId);
            }

            lblGold.Text = asset.Gold.ToString();
            lblSilver.Text = asset.Silver.ToString();
            lblToman.Text = asset.Toman.ToString("N0");

            var totalValue =
                (asset.Gold * 20_000_000m)
                + (asset.Silver * 400_000m)
                + asset.Toman;

            lblTotal.Text = totalValue.ToString("N0");
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Abort;
        Close();
    }

    private void btnDeposit_Click(object sender, EventArgs e)
    {
        var depositForm = ActivatorUtilities.CreateInstance<DepositForm>(
            _serviceProvider,
            _userId);

        depositForm.ShowDialog();

        _ = LoadAssetAsync();
    }

    private void btnWithdrawal_Click(object sender, EventArgs e)
    {
        var withdrawalForm = ActivatorUtilities.CreateInstance<WithdrawalForm>(
            _serviceProvider,
            _userId);

        withdrawalForm.ShowDialog();

        _ = LoadAssetAsync();
    }

    private void btnHistory_Click(object sender, EventArgs e)
    {
        var historyForm = ActivatorUtilities.CreateInstance<TransactionHistoryForm>(
            _serviceProvider,
            _userId);

        historyForm.ShowDialog();
    }

    private async void btnDeleteAccount_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show(
            "Are you sure you want to delete your account?",
            "Delete Account",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
            return;

        try
        {
            await _userService.DeleteAccountAsync(_userId);

            MessageBox.Show(
                "Your account has been deleted.",
                "Account Deleted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.Abort;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Delete Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}