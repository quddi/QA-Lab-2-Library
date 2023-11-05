using NUnit.Framework;
using PageObjects;

namespace Tests;

public class CartTest : BaseTest
{
    private const string ExistingEmail = "nyqug9@yahoo.com";
    private const string ExistingPassword = "extbp6";
    private const string SuccessMessage = "The product has been added to your shopping cart";

    private async Task<StartPage> LogIn()
    {
        var startPage = new StartPage(_webDriver!);
        var loginPage = startPage.GoToLoginPage();

        loginPage.SetEmail(ExistingEmail);
        loginPage.SetPassword(ExistingPassword);
        loginPage.ClickRememberMeCheckBox();
        await Task.Delay(TimeSpan.FromSeconds(2));

        return loginPage.ClickLoginButton();
    }

    [Test]
    public async Task LogoutFromStartPageTest()
    {
        //Arrange
        var loggedInStartPage = await LogIn();

        //Act
        var booksPage = loggedInStartPage.GoToBookPage();
        booksPage.ScrollBy(0, 200);

        var selectedProductName = booksPage.GetFirstProductName();

        booksPage.ClickSelectFirstProductButton();
        
        await Task.Delay(TimeSpan.FromSeconds(0.5));

        var actualSelectingSuccessMessage = booksPage.GetSelectingSuccessMessage();

        booksPage.ScrollBy(0, -200);
        var cartPage = booksPage.GoToCartPage();

        var actualProductName = cartPage.GetFirstProductName();

        //Assert
        Assert.That(() => actualSelectingSuccessMessage == SuccessMessage);
        Assert.That(() => selectedProductName == actualProductName);
    }
}
