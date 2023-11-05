using OpenQA.Selenium;

namespace PageObjects;

public class CartPage : BasePage
{
    public CartPage(IWebDriver driver) : base(driver)
    {
    }

    public string? GetFirstProductName()
    {
        try
        {
            var element = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div/div/div[2]/div/form/table/tbody/tr/td[3]/a"));

            return element.Text;
        }
        catch 
        { 
            return null; 
        }
    }
    
    public string? GetSecondProductName()
    {
        try
        {
            var element = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div/div/div[2]/div/form/table/tbody/tr[2]/td[3]/a"));

            return element.Text;
        }
        catch 
        { 
            return null; 
        }
    }
}
