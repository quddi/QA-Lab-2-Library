using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace PageObjects;

public class BasePage
{
    private const string LogInText = "Log in";
    private const string LogOutText = "Log out";

    protected IWebDriver _driver;

    private IWebElement _registerButton;
    private IWebElement _logInOutButton;
    private IWebElement _cartPageButton;

    public BasePage(IWebDriver driver)
    {
        _driver = driver;
        _registerButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[1]/a"));
        _logInOutButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[2]/a"));
        _cartPageButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[3]/a/span[1]"));
    }

    public RegistrationPage GoToRegistrationPage()
    {
        _registerButton.Click();

        return new RegistrationPage(_driver);
    }

    public LoginPage? GoToLoginPage()
    {
        if (GetLogInOutButtonText() == LogInText)
        {
            _logInOutButton.Click();

            return new LoginPage(_driver);
        }

        return null;
    }

    public CartPage GoToCartPage()
    {
        _cartPageButton.Click();

        return new CartPage(_driver);
    }

    public StartPage? ClickLogoutButton()
    {
        if (GetLogInOutButtonText() == LogOutText)
        {
            _logInOutButton.Click();

            return new StartPage(_driver);
        }

        return null;
    }

    public string? GetLogInOutButtonText()
    {
        try
        {
            return _logInOutButton.Text;
        }
        catch
        {
            return null;
        }
    }

    public void ScrollBy(int x, int y)
    {
        _driver?.ExecuteJavaScript($"window.scrollBy({x},{y})");
    }
}
