using OpenQA.Selenium;

namespace PageObjects;

public class StartPage : BasePage
{
    private IWebElement _registerButton; 
    private IWebElement _loginButton; 
    private IWebElement _emailText;

    public StartPage(IWebDriver driver) : base(driver) 
    {
        _registerButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[1]/a"));
        _loginButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[2]/a"));
        _emailText = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[1]/a"));
    }

    public RegistrationPage GoToRegistrationPage()
    {
        _registerButton.Click(); 

        return new RegistrationPage(_driver);
    }

    public LoginPage GoToAuthorizationPage()
    {
        _loginButton.Click(); 
        
        return new LoginPage(_driver);
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
}
