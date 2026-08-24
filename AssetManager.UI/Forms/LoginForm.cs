using AssetManager.Application.DTOs.Users;
using AssetManager.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AssetManager.UI.Forms;

public partial class LoginForm : Form
{
    private readonly IUserService _userService;
    private readonly IServiceProvider _serviceProvider;

    public LoginForm(
        IUserService userService,
        IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _userService = userService;
        _serviceProvider = serviceProvider;
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
    }

    private void SetLoading(bool isLoading)
    {
        btnLogin.Enabled = !isLoading;
        btnRegister.Enabled = !isLoading;

        Cursor = isLoading
            ? Cursors.WaitCursor
            : Cursors.Default;
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUsernameOrPhone.Text))
        {
            MessageBox.Show(
                "Please enter your username or phone number.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtUsernameOrPhone.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            MessageBox.Show(
                "Please enter your password.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtPassword.Focus();
            return;
        }

        var request = new LoginUserDto
        {
            UsernameOrPhone = txtUsernameOrPhone.Text.Trim(),
            Password = txtPassword.Text
        };

        try
        {
            SetLoading(true);

            var user = await _userService.LoginAsync(request);

            if (user is null)
            {
                MessageBox.Show(
                    "Username/Phone or password is incorrect.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            var assetForm = ActivatorUtilities.CreateInstance<AssetForm>(
                _serviceProvider,
                user.Id);

            Hide();

            assetForm.FormClosed += (s, e) =>
            {
                if (assetForm.DialogResult == DialogResult.Abort)
                {
                    Show();
                }
                else
                {
                    Close();
                }
            };

            assetForm.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Login Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            SetLoading(false);
        }
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        var registerForm = ActivatorUtilities.CreateInstance<RegisterForm>(
            _serviceProvider);

        Hide();

        registerForm.FormClosed += (s, e) => Show();

        registerForm.Show();
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
}