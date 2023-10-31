using NUnit.Framework;
using PageObjects;
using System.Linq;

namespace Tests;

public class StartPageTest : BaseTest
{
    [Test]
    public void Test()
    {
        var startPage = new StartPage(_webDriver!);

        var registrationPage = startPage.GoToRegistrationPage();

        Thread.Sleep(3000);

        var gender = (Gender)Enum.GetValues(typeof(Gender)).GetRandom();

        registrationPage.SetGender(gender);

        registrationPage.SetCredentials(
            Extensions.GetRandomString(6),
            Extensions.GetRandomString(6),
            Extensions.GetRandomEmail());

        var password = Extensions.GetRandomString(6);

        registrationPage.SetPassword(password, password);

        Thread.Sleep(10000);

        Assert.Pass();
    }
}