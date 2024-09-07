using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Newtonsoft.Json.Linq;

namespace MoralisUITest
{
    public class MoralisAdminUITest
    {
        private IWebDriver driver;
        public static class GlobalSettings
        {
            public static string NodeURL { get; set; }
        }

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--disable-search-engine-choice-screen");

            // Initialize ChromeDriver with the options
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        public void Login()
        {
            driver.Navigate().GoToUrl("https://admin.moralis.io");

            // Log in
            driver.FindElement(By.Id("cookiescript_accept")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.Name("email input")).SendKeys("saniaakifmalik@gmail.com");
            Thread.Sleep(2000);

            driver.FindElement(By.Name("password input")).SendKeys("MoralisTaskAssignment47");
            Thread.Sleep(3000);

            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(20000);

            // Wait for the page to fully load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void TestLoginAndCreateNode()
        {
            try
            {
                Login();

                // Navigate to Nodes creation page
                driver.FindElement(By.CssSelector("a[href^='/nodes']")).Click();
                Thread.Sleep(3000);

                // Click on create a new node
                driver.FindElement(By.CssSelector("button[data-testid='mui-button-primary']")).Click();
                Thread.Sleep(3000);

                // Select node protocol
                var protocol = driver.FindElement(By.Name("select-protoccol"));
                var selectProtocol = new SelectElement(protocol);
                selectProtocol.SelectByValue("Ethereum");

                // Select node network
                var network = driver.FindElement(By.Name("select-network"));
                var selectNetwork = new SelectElement(network);
                selectNetwork.SelectByValue("0x1-Mainnet");
                Thread.Sleep(3000);

                // Click on Create Node
                driver.FindElement(By.XPath("//button[.='Create Node']")).Click();

                Console.WriteLine("Node creation successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred - {ex.Message}");
            }
        }

        [Test]
        public void TestLoginAndGetApiKey()
        {
            try
            {
                Login();

                // Navigate to API Key section 
                IWebElement apiKeyElement = driver.FindElement(By.CssSelector("input[data-testid='mui-input']"));
                // Get the value attribute (API key)
                string apiKey = apiKeyElement.GetAttribute("value");

                // Output the API key
                Console.WriteLine("API Key: " + apiKey);

                Thread.Sleep(3000);

                // Save API key to a JSON file
                var json = new JObject();
                json["apiKey"] = apiKey;
                File.WriteAllText("apikey.json", json.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred - {ex.Message}");
            }
        }
    }
}

