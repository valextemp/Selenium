using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Selenium_auth_download
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myDownloadFolder = @"D:\Selen\";

            var chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            chromeOptions.AddUserProfilePreference("download.default_directory", myDownloadFolder);

            IWebDriver driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
            //IWebDriver driver = new EdgeDriver();

            try
            {
                driver.Navigate().GoToUrl("https://ruforms.online/login");
                var emailInput = driver.FindElement(By.Name("email"));
                var passInput = driver.FindElement(By.Name("password"));
                var sendButton = driver.FindElement(By.CssSelector("input[type=submit]"));
                var email = @"testseleniumuser@testseleniumuser.ru";
                var pass = @"";
                
                emailInput.SendKeys(email);
                Task.Delay(500);
                passInput.SendKeys(pass);
                Task.Delay(500);
                sendButton.Click();
                Task.Delay(500);
                driver.Navigate().GoToUrl("https://ruforms.online/formAnswer/1efac8a2-ae32-67b6-b0dc-cecff9414307");
                Task.Delay(800);
                //var links = driver.FindElements(By.TagName("a"));

                var links = driver.FindElements(By.LinkText("Скачать файл"));
                foreach (var link in links)
                {
                    Console.WriteLine(link.ToString());
                    link.Click();
                    Task.Delay(950);
                }
                
                //foreach (var link in links)
                //{
                //    if (link.GetDomAttribute("href").Contains(@"/storage/form_files/"))
                //    {
                //        link.Click();
                //    }
                //}
            }
            finally
            {
                Task.Delay(5000);
                //driver.Quit();
            }

            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
    }
}
