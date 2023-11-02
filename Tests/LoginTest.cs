using NUnit.Framework;
using PageObjects;

namespace Tests;

public class LoginTest : BaseTest
{
    private const string ExistingFirstName = "3dtj9u";
    private const string ExistingLastName = "dmjtp7";
    private const string ExistingEmail = "nyqug9@yahoo.com";
    private const string ExistingPassword = "extbp6";

    [Test] 
    public async Task NormalLoginTest()
    {
        //Arrange
        var startPage = new StartPage(_webDriver!);
        var loginPage = startPage.GoToAuthorizationPage();

        //Act
        loginPage.SetEmail(ExistingEmail);
        loginPage.SetPassword(ExistingPassword);
        loginPage.ClickRememberMeCheckBox();
        await Task.Delay(TimeSpan.FromSeconds(2));
        startPage = loginPage.ClickLoginButton();
        await Task.Delay(TimeSpan.FromSeconds(2));

        var actualEmailText = startPage.GetEmailText();
        var actualUrl = _webDriver?.Url;

        //Assert
        Assert.That(() => actualUrl == StartPageUrl);
        Assert.That(() => actualEmailText == ExistingEmail);
    }
}
