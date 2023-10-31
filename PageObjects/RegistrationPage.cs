using OpenQA.Selenium;

namespace PageObjects;

public class RegistrationPage : BasePage
{
    private IWebElement _maleGenderButton;
    private IWebElement _femaleGenderButton;

    public RegistrationPage(IWebDriver driver) : base(driver) 
    {
        _maleGenderButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/form/div/div[2]/div[2]/div[2]/div[1]/div[1]/input"));
        _femaleGenderButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/form/div/div[2]/div[2]/div[2]/div[1]/div[2]/input"));
    }
}