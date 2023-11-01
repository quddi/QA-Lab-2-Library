using NUnit.Framework;
using PageObjects;
using System.Linq;

namespace Tests;

public class StartPageTest : BaseTest
{
    private const string ExpectedEmailExistenceErrorMessage = "The specified email already exists";

    [Test]
    public async Task ExistedEmailRegistrationTest()
    {
        var startPage = new StartPage(_webDriver!);

        var registrationPage = startPage.GoToRegistrationPage();

        var gender = (Gender)Enum.GetValues(typeof(Gender)).GetRandom();

        registrationPage.SetGender(gender);

        registrationPage.SetCredentials(
            firstName: Extensions.GetRandomString(6),
            lastName: Extensions.GetRandomString(6),
            email: "alemkhf12@gmail.com");

        var password = Extensions.GetRandomString(6);

        registrationPage.SetPassword(password, password);

        await Task.Delay(TimeSpan.FromSeconds(2));

        registrationPage.ClickRegisterButton();

        await Task.Delay(TimeSpan.FromSeconds(2));

        var actualEmailExistenceErrorMessage = registrationPage.GetEmailExistenceErrorMessage();

        Assert.That(() => actualEmailExistenceErrorMessage == ExpectedEmailExistenceErrorMessage);
    }
}