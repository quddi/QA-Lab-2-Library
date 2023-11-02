using NUnit.Framework;
using PageObjects;
using System.Linq;

namespace Tests;

public class RegistrationTest : BaseTest
{
    private const string ExpectedEmailExistenceErrorMessage = "The specified email already exists";
    private const string DifferentPasswordsErrorMessage = "The password and confirmation password do not match.";
    private const string RegistrationSuccessMessage = "Your registration completed";

    [Test]
    public async Task ExistedEmailRegistrationTest()
    {
        //Arrange
        var startPage = new StartPage(_webDriver!);
        var registrationPage = startPage.GoToRegistrationPage();
        var gender = (Gender)Enum.GetValues(typeof(Gender)).GetRandom();
        var firstName = Extensions.GetRandomString(6);
        var lastName = Extensions.GetRandomString(6);
        var email = "alemkhf12@gmail.com";
        var password = Extensions.GetRandomString(6);

        //Act
        registrationPage.SetGender(gender);
        registrationPage.SetCredentials(firstName, lastName, email);
        registrationPage.SetPassword(password, password);
        await Task.Delay(TimeSpan.FromSeconds(2));
        registrationPage.ClickRegisterButton();
        await Task.Delay(TimeSpan.FromSeconds(2));

        var actualEmailExistenceErrorMessage = registrationPage.GetEmailExistenceErrorMessage();

        //Assert
        Assert.That(() => actualEmailExistenceErrorMessage == ExpectedEmailExistenceErrorMessage);
    }

    [Test]
    public async Task DifferentPasswordRegistrationTest()
    {
        //Arrange
        var startPage = new StartPage(_webDriver!);
        var registrationPage = startPage.GoToRegistrationPage();
        var gender = (Gender)Enum.GetValues(typeof(Gender)).GetRandom();
        var firstName = Extensions.GetRandomString(6);
        var lastName = Extensions.GetRandomString(6);
        var email = Extensions.GetRandomEmail();
        var firstPassword = "firstPassword";
        var secondPassword = "secondPassword";

        //Act
        registrationPage.SetGender(gender);
        registrationPage.SetCredentials(firstName, lastName, email);
        registrationPage.SetPassword(firstPassword, secondPassword);
        await Task.Delay(TimeSpan.FromSeconds(2));
        registrationPage.ClickRegisterButton();
        await Task.Delay(TimeSpan.FromSeconds(2));

        var actualDifferentPasswordsErrorMessage = registrationPage.GetDifferentPasswordsErrorMessage();

        //Assert
        Assert.That(() => actualDifferentPasswordsErrorMessage == DifferentPasswordsErrorMessage);
    }

    [Test]
    public async Task NormalRegistrationTest()
    {
        //Arrange
        var startPage = new StartPage(_webDriver!);
        var registrationPage = startPage.GoToRegistrationPage();
        var gender = (Gender)Enum.GetValues(typeof(Gender)).GetRandom();
        var firstName = Extensions.GetRandomString(6);
        var lastName = Extensions.GetRandomString(6);
        var email = Extensions.GetRandomEmail();
        var password = Extensions.GetRandomString(6);

        //Act
        registrationPage.SetGender(gender);
        registrationPage.SetCredentials(firstName, lastName, email);
        registrationPage.SetPassword(password, password);
        await Task.Delay(TimeSpan.FromSeconds(2));
        var registrationPassedPage = registrationPage.ClickRegisterButton();
        await Task.Delay(TimeSpan.FromSeconds(2));

        var registrationSuccessText = registrationPassedPage!.GetRegistrationSuccessMessageText();
        var emailText = registrationPassedPage!.GetEmailText();

        //Assert
        Assert.That(() => registrationSuccessText == RegistrationSuccessMessage);
        Assert.That(() => emailText == email);
    }
}