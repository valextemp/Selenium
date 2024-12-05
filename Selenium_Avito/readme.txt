
<p data-marker="item-price" itemprop="offers" itemscope="" itemtype="http://schema.org/Offer" class="styles-module-root-s4tZ2 styles-module-size_s-nEvE8 styles-module-size_s-PDQal stylesMarningNormal-module-root-_xKyG stylesMarningNormal-module-paragraph-s-HX94M"><meta itemprop="priceCurrency" content="RUB"><meta itemprop="price" content="6500"><meta itemprop="availability" content="https://schema.org/LimitedAvailability"><strong class="styles-module-root-iIeZo"><span class="">6&nbsp;500&nbsp;₽</span></strong></p>


using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Selenium_Avito
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var prices = new List<Decimal> ();

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.avito.ru");

            //ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.TagName("span"));
            //ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.CssSelector("[data-marker='item-price']"));
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.CssSelector("[itemprop='price']"));

            foreach (IWebElement element in elements)
            {
                var pr=element.GetDomAttribute("content");
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
            Console.WriteLine("---------------------------------------------------");

            //foreach (IWebElement element in elements)
            //{
            //    Console.WriteLine($"TagName -- {element.TagName}, ToString = {element.ToString()}, Text -- {element.Text}");
            //}
            //query.SendKeys("Acer");
            //query.Submit();
            Console.WriteLine(driver.Title);

            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
    }
}
