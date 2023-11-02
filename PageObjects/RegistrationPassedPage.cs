using OpenQA.Selenium;

namespace PageObjects;

public class RegistrationPassedPage : BasePage
{
    private IWebElement _registrationSuccessMessageText;
    private IWebElement _emailText;

    public RegistrationPassedPage(IWebDriver driver) : base(driver) 
    {
        _registrationSuccessMessageText = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div[1]"));
        _emailText = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[1]/a"));
    }

    public string GetRegistrationSuccessMessageText()
    {
        return _registrationSuccessMessageText.Text;
    }

    public string GetEmailText()
    {
        return _emailText.Text;
    }
}