using AssetManager.Application.DTOs.Users;
using AssetManager.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AssetManager.UI.Forms;

public partial class RegisterForm : Form
{
    private readonly IUserService _userService;
    private readonly IServiceProvider _serviceProvider;

    public RegisterForm(
        IUserService userService,
        IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _userService = userService;
        _serviceProvider = serviceProvider;
    }

    private void SetLoading(bool isLoading)
    {
        btnRegister.Enabled = !isLoading;
        btnBackToLogin.Enabled = !isLoading;

        Cursor = isLoading
            ? Cursors.WaitCursor
            : Cursors.Default;
    }

    private async void btnRegister_Click(object sender, EventArgs e)
    {
        var username = txtUsername.Text.Trim();
        var phoneNumber = txtPhoneNumber.Text.Trim();
        var password = txtPassword.Text;
        var confirmPassword = txtConfirmPassword.Text;

        if (string.IsNullOrWhiteSpace(username))
        {
            MessageBox.Show(
                "Please enter a username.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtUsername.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            MessageBox.Show(
                "Please enter your phone number.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtPhoneNumber.Focus();
            return;
        }

        if (phoneNumber.Length != 11 ||
            !phoneNumber.StartsWith("09") ||
            !phoneNumber.All(char.IsDigit))
        {
            MessageBox.Show(
                "Phone number must be exactly 11 digits and start with 09.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtPhoneNumber.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show(
                "Please enter a password.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtPassword.Focus();
            return;
        }

        if (!password.Any(char.IsUpper))
        {
            MessageBox.Show(
                "Password must contain at least one uppercase English letter.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtPassword.Focus();
            return;
        }

        if (!password.Any(char.IsLower))
        {
            MessageBox.Show(
                "Password must contain at least one lowercase English letter.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtPassword.Focus();
            return;
        }

        if (!password.Any(char.IsDigit))
        {
            MessageBox.Show(
                "Password must contain at least one digit.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtPassword.Focus();
            return;
        }

        if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
        {
            MessageBox.Show(
                "Password must contain at least one special character.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtPassword.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(confirmPassword))
        {
            MessageBox.Show(
                "Please confirm your password.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtConfirmPassword.Focus();
            return;
        }

        if (password != confirmPassword)
        {
            MessageBox.Show(
                "Passwords do not match.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtConfirmPassword.Focus();
            return;
        }

        var request = new RegisterUserDto
        {
            Username = username,
            PhoneNumber = phoneNumber,
            Password = password
        };

        try
        {
            SetLoading(true);

            var user = await _userService.RegisterAsync(request);

            MessageBox.Show(
                "Registration successful.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            var assetForm = ActivatorUtilities.CreateInstance<AssetForm>(
                _serviceProvider,
                user.Id);

            Hide();

            assetForm.FormClosed += (s, e) => Close();

            assetForm.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Registration Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            SetLoading(false);
        }
    }

    private void btnBackToLogin_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnTogglePassword_Click(object sender, EventArgs e)
    {
        if (txtPassword.PasswordChar == '●')
        {
            txtPassword.PasswordChar = '\0';
            btnTogglePassword.Text = "Hide";
        }
        else
        {
            txtPassword.PasswordChar = '●';
            btnTogglePassword.Text = "Show";
        }
    }

    private void btnToggleConfirmPassword_Click(object sender, EventArgs e)
    {
        if (txtConfirmPassword.PasswordChar == '●')
        {
            txtConfirmPassword.PasswordChar = '\0';
            btnToggleConfirmPassword.Text = "Hide";
        }
        else
        {
            txtConfirmPassword.PasswordChar = '●';
            btnToggleConfirmPassword.Text = "Show";
        }
    }
}