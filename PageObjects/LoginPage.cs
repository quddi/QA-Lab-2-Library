using OpenQA.Selenium;

namespace PageObjects;

public class LoginPage : BasePage
{
    private IWebElement _emailInputField;
    private IWebElement _passwordInputField;
    private IWebElement _rememberMeCheckBox;
    private IWebElement _loginButton;

    public LoginPage(IWebDriver driver) : base(driver)
    {
        _emailInputField = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div[1]/div[2]/div[2]/form/div[2]/input"));
        _passwordInputField = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div[1]/div[2]/div[2]/form/div[3]/input"));
        _rememberMeCheckBox = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div[1]/div[2]/div[2]/form/div[4]/input[1]"));
        _loginButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div[1]/div[2]/div[2]/form/div[5]/input"));
    }

    public void SetEmail(string email)
    {
        _emailInputField.SendKeys(email);
    }

    public void SetPassword(string password)
    {
        _passwordInputField.SendKeys(password);
    }

    public void ClickRememberMeCheckBox()
    {
        _rememberMeCheckBox.Click();
    }

    public StartPage ClickLoginButton()
    {
        _loginButton.Click();

        return new StartPage(_driver);
    }

    public string? GetUnsuccessLoginMessage()
    {
        try
        {
            var element = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div[1]/div[2]/div[2]/form/div[1]/div/span"));

            return element.Text;
        }
        catch 
        { 
            return null; 
        }
    }

    public string? GetNoCustomerFoundLoginMessage()
    {
        try
        {
            var element = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div[1]/div[2]/div[2]/form/div[1]/div/ul/li"));

            return element.Text;
        }
        catch
        {
            return null;
        }
    }

    public string? GetIncorrectCredentialsMessage()
    {
        try
        {
            var element = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div[1]/div[2]/div[2]/form/div[1]/div/ul/li"));

            return element.Text;
        }
        catch
        {
            return null;
        }
    }
}