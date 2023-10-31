using OpenQA.Selenium;
using PageObjects;

namespace PageObjects;

public class StartPage : BasePage
{
    private IWebElement _registerButton; 

    public StartPage(IWebDriver driver) : base(driver) 
    {
        _registerButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[1]/a"));
    }

    public void GoToRegistrationPage()
    {
        _registerButton.Click();
    }
}
