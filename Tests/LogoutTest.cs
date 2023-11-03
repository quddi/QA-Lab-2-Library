using NUnit.Framework;
using PageObjects;

namespace Tests;

public class LogoutTest : BaseTest
{
    private const string ExistingEmail = "nyqug9@yahoo.com";
    private const string ExistingPassword = "extbp6";
    private const string LogInButtonText = "Log in";

    [Test]
    public async Task LogoutFromStartPageTest()
    {
        //Arrange
        var startPage = new StartPage(_webDriver!);
        var loginPage = startPage.GoToLoginPage();

        //Act
        loginPage.SetEmail(ExistingEmail);
        loginPage.SetPassword(ExistingPassword);
        loginPage.ClickRememberMeCheckBox();
        await Task.Delay(TimeSpan.FromSeconds(2));
        startPage = loginPage.ClickLoginButton();
        await Task.Delay(TimeSpan.FromSeconds(2));

        startPage = startPage.ClickLogoutButton();

        var actualUrl = _webDriver!.Url;
        var actualLogInOutButtonText = startPage!.GetLogInOutButtonText();

        //Assert
        Assert.That(() => actualUrl == StartPageUrl);
        Assert.That(() => actualLogInOutButtonText == LogInButtonText);
    }
}
