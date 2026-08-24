using AssetManager.Application.Services.Interfaces;
using AssetManager.Application.DTOs.Transactions;
using AssetManager.Domain.Enums;

namespace AssetManager.UI.Forms;

public partial class WithdrawalForm : Form
{
    private readonly IWithdrawalService _withdrawalService;
    private readonly int _userId;

    public WithdrawalForm(
        IWithdrawalService withdrawalService,
        int userId)
    {
        InitializeComponent();

        _withdrawalService = withdrawalService;
        _userId = userId;

        cmbAssetType.Items.Add("Gold");
        cmbAssetType.Items.Add("Silver");
        cmbAssetType.Items.Add("Toman");

        cmbAssetType.SelectedIndex = 0;
    }

    private void SetLoading(bool isLoading)
    {
        btnWithdrawal.Enabled = !isLoading;
        btnCancel.Enabled = !isLoading;

        Cursor = isLoading
            ? Cursors.WaitCursor
            : Cursors.Default;
    }

    private async void btnWithdrawal_Click(object sender, EventArgs e)
    {
        if (!decimal.TryParse(txtAmount.Text.Trim(), out var amount))
        {
            MessageBox.Show(
                "Please enter a valid amount.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (amount <= 0)
        {
            MessageBox.Show(
                "Amount must be greater than zero.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        AssetType assetType;

        switch (cmbAssetType.SelectedItem?.ToString())
        {
            case "Gold":
                assetType = AssetType.Gold;
                break;

            case "Silver":
                assetType = AssetType.Silver;
                break;

            case "Toman":
                assetType = AssetType.Toman;
                break;

            default:
                MessageBox.Show(
                    "Please select an asset type.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
        }

        var request = new WithdrawalDto
        {
            UserId = _userId,
            AssetType = assetType,
            Amount = amount
        };

        try
        {
            SetLoading(true);

            await _withdrawalService.WithdrawAsync(request);

            MessageBox.Show(
                "Withdrawal successful.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Withdrawal Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            SetLoading(false);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }
}