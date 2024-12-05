using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Edge;
using static OpenQA.Selenium.BiDi.Modules.Script.RealmInfo;

namespace Selenium_Avito
{
    internal class Program
    {
        static void Main(string[] args)
        {
//< p data - marker = "item-price" itemprop = "offers" itemscope = "" itemtype = "http://schema.org/Offer" class="styles-module-root-s4tZ2 styles-module-size_s-nEvE8 styles-module-size_s-PDQal stylesMarningNormal-module-root-_xKyG stylesMarningNormal-module-paragraph-s-HX94M"><meta itemprop = "priceCurrency" content="RUB"><meta itemprop = "price" content="6500"><meta itemprop = "availability" content="https://schema.org/LimitedAvailability"><strong class="styles-module-root-iIeZo"><span class="">6&nbsp;500&nbsp;₽</span></strong></p>

            var prices = new List<Decimal> ();
            var chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            IWebDriver driver = new ChromeDriver(chromeOptions);
            //IWebDriver driver = new EdgeDriver();

            try
            {
                driver.Navigate().GoToUrl("https://www.avito.ru");

                ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.CssSelector("[itemprop='price']"));

                foreach (IWebElement element in elements)
                {
                    var pr = element.GetDomAttribute("content");
                    if (Decimal.TryParse(pr, out decimal v))
                    {
                        prices.Add(v);
                    }
                }

                Console.WriteLine("---------------------------------------------------");
                if (prices.Count > 0)
                {
                    Console.WriteLine("----- List price -------");
                    foreach (var pr in prices)
                    {
                        Console.WriteLine(pr);
                    }
                    Console.WriteLine("----- End list of price -----");
                    Console.WriteLine($" Sum of prices = {prices.Sum()}");
                }
                else
                {
                    Console.WriteLine("Prices not found");
                }

                Console.WriteLine(driver.Title);
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
