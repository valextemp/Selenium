using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Selenium_Upload_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            IWebDriver driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
            //IWebDriver driver = new EdgeDriver();
            
            try
            {
                driver.Navigate().GoToUrl("https://ruforms.online/form/1efac8a2-ae32-67b6-b0dc-cecff9414307");
                Task.Delay(700);
                var textBox = driver.FindElement(By.Name("r0"));
                textBox.SendKeys("Test text from my project");
                var radioButtons = driver.FindElements(By.Name("r1"));
                foreach (var radioButton in radioButtons)
                {
                    if (radioButton.GetDomAttribute("value")=="2")
                    {
                        radioButton.Click();
                    }
                }

                var uploadElement= driver.FindElement(By.Name("r2"));

                var filePath = @"D:\Selen\myfile.txt";
                uploadElement.SendKeys(filePath);

                var sendButton = driver.FindElement(By.CssSelector("input[type=submit]"));
                sendButton.Click();
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
