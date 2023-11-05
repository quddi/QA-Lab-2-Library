using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace PageObjects;

public class BasePage
{
    protected IWebDriver _driver;

    public BasePage(IWebDriver driver)
    {
        _driver = driver;

    }

    public void ScrollBy(int x, int y)
    {
        _driver?.ExecuteJavaScript($"window.scrollBy({x},{y})");
    }
}
