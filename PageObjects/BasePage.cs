using OpenQA.Selenium;

namespace PageObjects;

public class BasePage
{
    protected IWebDriver _driver;

    public BasePage(IWebDriver driver)
    {
        _driver = driver;
    }
}
