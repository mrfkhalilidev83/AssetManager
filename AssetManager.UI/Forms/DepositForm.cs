using AssetManager.Application.DTOs.Transactions;
using AssetManager.Application.Services.Interfaces;
using AssetManager.Domain.Enums;

namespace AssetManager.UI.Forms;

public partial class DepositForm : Form
{
    private readonly IDepositService _depositService;
    private readonly int _userId;

    public DepositForm(
        IDepositService depositService,
        int userId)
    {
        InitializeComponent();

        _depositService = depositService;
        _userId = userId;

        cmbAssetType.Items.Add("Gold");
        cmbAssetType.Items.Add("Silver");
        cmbAssetType.Items.Add("Toman");

        cmbAssetType.SelectedIndex = 0;
    }

    private void SetLoading(bool isLoading)
    {
        btnDeposit.Enabled = !isLoading;
        btnCancel.Enabled = !isLoading;

        Cursor = isLoading
            ? Cursors.WaitCursor
            : Cursors.Default;
    }

    private async void btnDeposit_Click(object sender, EventArgs e)
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

        var request = new DepositDto
        {
            UserId = _userId,
            AssetType = assetType,
            Amount = amount
        };

        try
        {
            SetLoading(true);

            await _depositService.DepositAsync(request);

            MessageBox.Show(
                "Deposit successful.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Deposit Failed",
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