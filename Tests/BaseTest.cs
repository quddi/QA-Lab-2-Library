using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests;

public class BaseTest
{
    protected IWebDriver? _webDriver;
    
    private const string Url = "https://demowebshop.tricentis.com";
    
    [SetUp]
    public void SetUp()
    {
        _webDriver = new ChromeDriver();
        
        _webDriver.Manage().Window.Maximize();
        _webDriver.Navigate().GoToUrl(Url);
    }

    [TearDown]
    public void TearDown()
    {
        _webDriver?.Close();
    }
}