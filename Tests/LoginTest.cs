using NUnit.Framework;
using PageObjects;

namespace Tests;

public class LoginTest : BaseTest
{
    private const string ExistingEmail = "nyqug9@yahoo.com";
    private const string ExistingPassword = "extbp6";
    private readonly string IncorrectPassword = ExistingPassword + "_incorrect";

    private const string UnsuccessMessageText = "Login was unsuccessful. Please correct the errors and try again.";
    private const string NoCustomerMessageText = "No customer account found";
    private const string IncorrectCredentialsMessageText = "The credentials provided are incorrect";

    [Test] 
    public async Task NormalLoginTest()
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

        var actualEmailText = startPage.GetEmailText();
        var actualUrl = _webDriver?.Url;

        //Assert
        Assert.That(() => actualUrl == StartPageUrl);
        Assert.That(() => actualEmailText == ExistingEmail);
    }

    [Test]
    public async Task WrongEmailLoginTest()
    {
        //Arrange
        var startPage = new StartPage(_webDriver!);
        var loginPage = startPage.GoToLoginPage();

        //Act
        loginPage.ClickLoginButton();
        await Task.Delay(TimeSpan.FromSeconds(2));

        var actualUnsuccessMessageText = loginPage.GetUnsuccessLoginMessage();
        var actualNoCustomerMessageText = loginPage.GetNoCustomerFoundLoginMessage();

        //Assert
        Assert.That(() => actualUnsuccessMessageText == UnsuccessMessageText);
        Assert.That(() => actualNoCustomerMessageText == NoCustomerMessageText);
    }

    [Test]
    public async Task IncorrectLoginTest()
    {
        //Arrange
        var startPage = new StartPage(_webDriver!);
        var loginPage = startPage.GoToLoginPage();

        //Act
        loginPage.SetEmail(ExistingEmail);
        loginPage.SetPassword(IncorrectPassword);
        loginPage.ClickRememberMeCheckBox();
        await Task.Delay(TimeSpan.FromSeconds(2));
        loginPage.ClickLoginButton();
        await Task.Delay(TimeSpan.FromSeconds(2));

        var actualUnsuccessMessageText = loginPage.GetUnsuccessLoginMessage();
        var actualIncorrectMessageTest = loginPage.GetIncorrectCredentialsMessage();

        //Assert
        Assert.That(() => actualUnsuccessMessageText == UnsuccessMessageText);
        Assert.That(() => actualIncorrectMessageTest == IncorrectCredentialsMessageText);
    }
}
