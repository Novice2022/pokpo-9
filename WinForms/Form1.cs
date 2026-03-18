using MyApp.Core.Services;

namespace MyApp.WinForms;

public partial class Form1 : Form
{
    private readonly AuthenticationService _authService;

    public Form1()
    {
        InitializeComponent();
        _authService = new AuthenticationService();
        lblMessage.Text = string.Empty;
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        var success = _authService.Login(txtUsername.Text, txtPassword.Text);
        lblMessage.Text = success ? "Успешный вход!" : "Ошибка: неверный логин или пароль.";

        if (success)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            lblMessage.Text = "Ошибка: заполните все поля";
            return;
        }

        var success = _authService.Register(txtUsername.Text, txtPassword.Text);
        lblMessage.Text = success ? "Регистрация успешна! Теперь войдите." : "Ошибка: пользователь уже существует.";
    }
}