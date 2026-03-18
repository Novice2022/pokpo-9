using MyApp.Core.Services;


namespace MyApp.UnitTests;

public class AuthenticationServiceTests
{
    [Fact]
    public void Register_NewUser_ReturnsTrue()
    {
        // Arrange
        var tempFile = Path.GetTempFileName();
        var service = new AuthenticationService(tempFile);

        // Act
        var result = service.Register("testuser", "password123");

        // Assert
        Assert.True(result);
        File.Delete(tempFile);
    }

    [Fact]
    public void voidRegister_DuplicateUser_ReturnsFalse()
    {
        // Arrange
        var tempFile = Path.GetTempFileName();
        var service = new AuthenticationService(tempFile);
        service.Register("testuser", "password123");

        // Act
        var result = service.Register("testuser", "anotherpass");

        // Assert
        Assert.False(result);
        File.Delete(tempFile);
    }

    [Fact]
    public void Login_CorrectCredentials_ReturnsTrue()
    {
        // Arrange
        var tempFile = Path.GetTempFileName();
        var service = new AuthenticationService(tempFile);
        service.Register("testuser", "password123");

        // Act
        var result = service.Login("testuser", "password123");

        // Assert
        Assert.True(result);
        File.Delete(tempFile);
    }

    [Fact]
    public void Login_WrongPassword_ReturnsFalse()
    {
        // Arrange
        var tempFile = Path.GetTempFileName();
        var service = new AuthenticationService(tempFile);
        service.Register("testuser", "password123");

        // Act
        var result = service.Login("testuser", "wrongpass");

        // Assert
        Assert.False(result);
        File.Delete(tempFile);
    }

    [Fact]
    public void Login_NonexistentUser_ReturnsFalse()
    {
        // Arrange
        var tempFile = Path.GetTempFileName();
        var service = new AuthenticationService(tempFile);

        // Act
        var result = service.Login("nosuchuser", "password123");

        // Assert
        Assert.False(result);
        File.Delete(tempFile);
    }

    [Fact]
    public void IsPasswordStrong_ValidPassword_ReturnsTrue()
    {
        // Arrange
        var service = new AuthenticationService(); // использует путь по умолчанию, но это не важно для этого метода

        // Act & Assert
        Assert.True(service.IsPasswordStrong("strongPass1"));
        Assert.True(service.IsPasswordStrong("12345678a"));
    }

    [Fact]
    public void IsPasswordStrong_TooShort_ReturnsFalse()
    {
        // Arrange
        var service = new AuthenticationService();

        // Act & Assert
        Assert.False(service.IsPasswordStrong("short1")); // 6 символов
    }

    [Fact]
    public void IsPasswordStrong_NoDigit_ReturnsFalse()
    {
        // Arrange
        var service = new AuthenticationService();

        // Act & Assert
        Assert.False(service.IsPasswordStrong("nodigitshere"));
    }

    [Fact]
    public void IsPasswordStrong_NullOrEmpty_ReturnsFalse()
    {
        // Arrange
        var service = new AuthenticationService();

        // Act & Assert
        Assert.False(service.IsPasswordStrong(null));
        Assert.False(service.IsPasswordStrong(""));
    }
}