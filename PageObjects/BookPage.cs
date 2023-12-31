﻿using OpenQA.Selenium;

namespace PageObjects;

public class BookPage : BasePage
{
    private IWebElement _selectFirstProductButton;
    private IWebElement _selectSecondProductButton;

    public BookPage(IWebDriver driver) : base(driver)
    {
        _selectFirstProductButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div[2]/div[2]/div[3]/div[1]/div/div[2]/div[3]/div[2]/input"));
        _selectSecondProductButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div[2]/div[2]/div[3]/div[3]/div/div[2]/div[3]/div[2]/input"));
        
    }

    public void ClickSelectFirstProductButton()
    {
        _selectFirstProductButton.Click();
    }

    public void ClickSelectSecondProductButton()
    {
        _selectSecondProductButton.Click();
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

    public string? GetSecondProductName()
    {
        try
        {
            var element = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/div[2]/div[2]/div[3]/div[3]/div/div[2]/h2/a"));

            return element.Text;
        }
        catch
        {
            return null;
        }
    }
}
