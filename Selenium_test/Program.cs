using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");

            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Acer");
            query.Submit();

            Console.WriteLine(driver.Title);

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
    }
}
