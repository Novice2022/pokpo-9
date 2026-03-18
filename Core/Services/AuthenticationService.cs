using MyApp.Core.Models;
using System.Text.Json;

namespace MyApp.Core.Services;

public class AuthenticationService
{
    private readonly string _usersFilePath;
    private List<User> _users = new();

    public AuthenticationService()
    {
        var appData = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "MyApp");

        if (!Directory.Exists(appData))
            Directory.CreateDirectory(appData);

        _usersFilePath = Path.Combine(appData, "users.json");
        LoadUsers();
    }

    public AuthenticationService(string customPath)
    {
        _usersFilePath = customPath;
        LoadUsers();
    }

    private void LoadUsers()
    {
        if (File.Exists(_usersFilePath))
        {
            var json = File.ReadAllText(_usersFilePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                _users = new List<User>();
                return;
            }
            try
            {
                _users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            catch (JsonException)
            {
                _users = new List<User>();
            }
        }
        else
        {
            _users = new List<User>();
        }
    }

    private void SaveUsers()
    {
        var json = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_usersFilePath, json);
    }

    public bool Login(string username, string password)
    {
        return _users.Any(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
            u.Password == password);
    }

    public bool Register(string username, string password)
    {
        if (_users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            return false;

        _users.Add(new User { Username = username, Password = password });
        SaveUsers();
        return true;
    }

    public bool IsPasswordStrong(string password)
    {
        if (string.IsNullOrEmpty(password))
            return false;

        return password.Length >= 8 && password.Any(char.IsDigit);
    }
}