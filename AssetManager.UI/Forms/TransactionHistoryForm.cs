using AssetManager.Application.Services.Interfaces;

namespace AssetManager.UI.Forms;

public partial class TransactionHistoryForm : Form
{
    private readonly ITransactionService _transactionService;
    private readonly int _userId;

    public TransactionHistoryForm(
        ITransactionService transactionService,
        int userId)
    {
        InitializeComponent();

        _transactionService = transactionService;
        _userId = userId;
    }

    private async void TransactionHistoryForm_Load(object sender, EventArgs e)
    {
        await LoadTransactionsAsync();
    }

    private async Task LoadTransactionsAsync()
    {
        try
        {
            var transactions = await _transactionService.GetHistoryAsync(_userId);

            dgvTransactions.DataSource = transactions
                .Select(x => new
                {
                    Username = x.User.Username,
                    Asset = x.AssetType,
                    Type = x.TransactionType,
                    Amount = x.Amount,
                    Date = x.CreatedAt.ToLocalTime()
                })
                .ToList();
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

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}