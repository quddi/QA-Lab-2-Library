using NUnit.Framework;
using PageObjects;

namespace Tests;

public class MainPageTest : BaseTest
{
    [Test]
    public void Test()
    {
        var startPage = new StartPage(_webDriver!);

        startPage.GoToRegistrationPage();

        Thread.Sleep(10000);

        Assert.Pass();
    }
}