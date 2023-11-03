using OpenQA.Selenium;

namespace PageObjects;

public class StartPage : BasePage
{
    private const string LogInText = "Log in";
    private const string LogOutText = "Log out";

    private IWebElement _registerButton; 
    private IWebElement _logInOutButton; 
    private IWebElement _emailText;

    public StartPage(IWebDriver driver) : base(driver) 
    {
        _registerButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[1]/a"));
        _logInOutButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[2]/a"));
        _emailText = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[1]/a"));
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

    public StartPage? ClickLogoutButton()
    {
        if (GetLogInOutButtonText() == LogOutText)
        {
            _logInOutButton.Click();

            return new StartPage(_driver);
        }

        return null;
    }

    public string? GetEmailText()
    {
        try
        {
            return _emailText.Text;
        }
        catch
        {
            return null;
        }
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
}
