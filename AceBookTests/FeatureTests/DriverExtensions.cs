using OpenQA.Selenium;
namespace AceBookTests.FeatureTests
{
    public static class DriverExtensions
    {
        public static IWebElement Get(this IWebDriver driver, string cssSelector)
        {
            return driver.FindElement(By.CssSelector(cssSelector));
        }
    }
}