using OpenQA.Selenium;

namespace PageObjects;

public class StartPage : BasePage
{
    private IWebElement _emailText;
    private IWebElement _booksButton; 

    public StartPage(IWebDriver driver) : base(driver) 
    {
        
        _emailText = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[1]/a"));
        _booksButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[2]/ul[1]/li[1]/a"));
    }

    public BookPage GoToBookPage()
    {
        _booksButton.Click();

        return new BookPage(_driver);
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
