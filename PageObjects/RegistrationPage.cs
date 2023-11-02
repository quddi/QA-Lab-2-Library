using OpenQA.Selenium;

namespace PageObjects;

public class RegistrationPage : BasePage
{
    private IWebElement _maleGenderButton;
    private IWebElement _femaleGenderButton;
    private IWebElement _firstNameInputField;
    private IWebElement _lastNameInputField;
    private IWebElement _emailInputField;
    private IWebElement _passwordInputField;
    private IWebElement _passwordConfirmationInputField;
    private IWebElement _registerButton;

    public RegistrationPage(IWebDriver driver) : base(driver) 
    {
        _maleGenderButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/form/div/div[2]/div[2]/div[2]/div[1]/div[1]/input"));
        _femaleGenderButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/form/div/div[2]/div[2]/div[2]/div[1]/div[2]/input"));
        _firstNameInputField = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/form/div/div[2]/div[2]/div[2]/div[2]/input"));
        _lastNameInputField = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/form/div/div[2]/div[2]/div[2]/div[3]/input"));
        _emailInputField = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/form/div/div[2]/div[2]/div[2]/div[4]/input"));
        _passwordInputField = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/form/div/div[2]/div[3]/div[2]/div[1]/input"));
        _passwordConfirmationInputField = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/form/div/div[2]/div[3]/div[2]/div[2]/input"));
        _registerButton = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/form/div/div[2]/div[4]/input"));
    }

    public void SetGender(Gender gender)
    {
        var button = gender switch
        {
            Gender.Male => _maleGenderButton,
            Gender.Female => _femaleGenderButton,
            _ => throw new NotImplementedException()
        };

        button.Click();
    }

    public void SetCredentials(string firstName, string lastName, string email)
    {
        _firstNameInputField.SendKeys(firstName);
        _lastNameInputField.SendKeys(lastName);
        _emailInputField.SendKeys(email);
    }

    public void SetPassword(string password, string confirmationPassword) 
    { 
        _passwordInputField.SendKeys(password);
        _passwordConfirmationInputField.SendKeys(confirmationPassword);
    }

    public RegistrationPassedPage? ClickRegisterButton()
    {
        var previousWindowHandle = _driver.Url;

        _registerButton.Click();

        var newWindowHandle = _driver.Url;

        return previousWindowHandle == newWindowHandle ? null : new RegistrationPassedPage(_driver);
    }

    public string? GetEmailExistenceErrorMessage()
    {
        try 
        {
            var element = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/form/div/div[2]/div[1]/div/ul/li"));

            return element.Text;
        }
        catch 
        { 
            return null; 
        }
    }

    public string? GetDifferentPasswordsErrorMessage()
    {
        try
        {
            var element = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[2]/form/div/div[2]/div[3]/div[2]/div[2]/span[2]/span"));

            return element.Text;
        }
        catch
        {
            return null;
        }
    }
}

public enum Gender
{
    Male = 0,
    Female = 1
}