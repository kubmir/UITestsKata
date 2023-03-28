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
            driver = new ChromeDriver("/Users/matejsoroka/Projects/UITestsKata/SeleniumTests/chromedriver");
        }

        public void addItem(string productName)
        {
            driver.FindElement(By.Id("add-to-cart-" + productName)).Click();
        }

        public int checkCartSize()
        {
            var text = driver.FindElement(By.ClassName("shopping_cart_badge")).Text;
            if (int.TryParse(text, out int j))
            {
                return j;
            }
            else
            {
                return 0;
            }
        }

        [Test]
        public void OrderProcessTest()
        {
            driver.Url = "https://www.saucedemo.com";
            
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

            
            addItem("sauce-labs-backpack");

            Assert.AreEqual(1, checkCartSize());
            
            addItem("sauce-labs-bike-light");
            
            Assert.AreEqual(2, checkCartSize());

            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            driver.FindElement(By.Id("checkout")).Click();
            
            driver.FindElement(By.Id("first-name")).SendKeys("Matej");
            driver.FindElement(By.Id("last-name")).SendKeys("Soroka");
            driver.FindElement(By.Id("postal-code")).SendKeys("08501");
            
            driver.FindElement(By.Id("continue")).Click();
            driver.FindElement(By.Id("finish")).Click();
            
            driver.FindElement(By.Id("back-to-products")).Click();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }

}