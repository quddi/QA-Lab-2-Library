using OpenQA.Selenium;

namespace PageObjects;

public class BookPage : BasePage
{
    private IWebElement _selectFirstBookButton;
    private IWebElement _cartPageButton;

    public BookPage(IWebDriver driver) : base(driver)
    {
        _selectFirstBookButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div[2]/div[2]/div[3]/div[1]/div/div[2]/div[3]/div[2]/input"));
        _cartPageButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[3]/a/span[1]"));
    }

    public void ClickSelectFirstProductButton()
    {
        _selectFirstBookButton.Click();
    }

    public CartPage GoToCartPage()
    {
        _cartPageButton.Click();

        return new CartPage(_driver);
    }

    public string? GetSelectingSuccessMessage()
    {
        try
        {
            var element = _driver.FindElement(By.XPath("/html/body/div[3]/p"));

            return element.Text;
        }
        catch 
        { 
            return null; 
        }
    }

    public string? GetFirstProductName()
    {
        try
        {
            var element = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div[2]/div[2]/div[3]/div[1]/div/div[2]/h2/a"));

            return element.Text;
        }
        catch 
        { 
            return null; 
        }
    }
}
