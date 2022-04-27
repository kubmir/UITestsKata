using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace SeleniumTests
{
    public class SeleniumTestsExample
    {
        IWebDriver? driver;

        [SetUp]
        public void startBrowser()
        {
            // TODO: Place here path to you chrome driver
            driver = new EdgeDriver("C:");
        }

        [Test]
        public void OrderProcessTest()
        {
            driver.Url = "https://www.saucedemo.com";

            // TODO: Place your test code here
            driver.FindElement(By.Name("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Name("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Name("login-button")).Submit();

            driver.FindElement(By.Name("add-to-cart-sauce-labs-backpack")).Submit();
            Assert.True(driver.FindElement(By.ClassName("shopping_cart_badge")).Text.Equals("1"));

           

            driver.FindElement(By.Name("add-to-cart-sauce-labs-bike-light")).Submit();
            Assert.True(driver.FindElement(By.ClassName("shopping_cart_badge")).Text.Equals("2"));

            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            driver.FindElement(By.Name("checkout")).Submit();
            driver.FindElement(By.Name("firstName")).SendKeys("Name");
            driver.FindElement(By.Name("lastName")).SendKeys("LAST");
            driver.FindElement(By.Name("postalCode")).SendKeys("50977");

            driver.FindElement(By.Name("continue")).Submit();
            driver.FindElement(By.Name("finish")).Submit();

            Assert.True(driver.FindElement(By.ClassName("complete-header")).Text.Equals("THANK YOU FOR YOUR ORDER"));
            driver.FindElement(By.Name("back-to-products")).Submit();


        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }

}