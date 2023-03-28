
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    public class SeleniumTestsExample
    {
        IWebDriver? driver;

        [SetUp]
        public void startBrowser()
        {
            // TODO: Place here path to you chrome driver
            driver = new ChromeDriver("C:\\Users\\stysk\\Downloads");
        }

        [Test]
        public void OrderProcessTest()
        {
            driver.Url = "https://www.saucedemo.com";

            // TODO: Place your test code here

            var name = driver.FindElement(By.Id("user-name"));

            name.SendKeys("standard_user");

            var pass = driver.FindElement(By.Id("password"));
            pass.SendKeys("secret_sauce");

            var loginButton = driver.FindElement(By.Id("login-button"));

            loginButton.Click();

            var backpack = driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));

            backpack.Click();

            var bikeLight = driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));

            bikeLight.Click();

            var shoppingCart = driver.FindElement(By.ClassName("shopping_cart_link"));

            shoppingCart.Click();


            var cartItems = driver.FindElements(By.ClassName("inventory_item_name"));

            Assert.AreEqual("Sauce Labs Backpack", cartItems[0].Text);
            Assert.AreEqual("Sauce Labs Bike Light", cartItems[1].Text);

            var checkout = driver.FindElement(By.Name("checkout"));

            checkout.Click();

            var firstName = driver.FindElement(By.Name("firstName"));

            firstName.SendKeys("Krystof");

            var lastName = driver.FindElement(By.Name("lastName"));

            lastName.SendKeys("Stys");

            var postalCode = driver.FindElement(By.Name("postalCode"));

            postalCode.SendKeys("61300");

            var continueButton = driver.FindElement(By.Name("continue"));

            continueButton.Click();

            var finishButton = driver.FindElement(By.Name("finish"));

            finishButton.Click();

            var spanTitle = driver.FindElement(By.ClassName("title"));

            Assert.AreEqual(spanTitle.Text, "Checkout: Complete!");
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }

}