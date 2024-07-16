using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SteamTopSellers
{
    /// <summary>
    /// Класс для извлечения информации об лидерах продаж в Steam с использованием Selenium.
    /// </summary>
    public class SteamScraper
    {
        private readonly string url;
        private readonly int topCount;

        private const string rowSelector = "tr._2-RN6nWOY56sNmcDHu069P";// маркер строки игры (любой из списка лидеров продаж)
        private const string placeSelector = "td._34h48M_x9S-9Q2FFPX_CcU";// маркер места
        private const string nameSelector = "div._1n_4-zvf0n4aqGEksbgW9N";// маркер наименования игры
        private const string priceSelector = "div._3j4dI1yA7cRfCvK8h406OB";// маркер цены игры

        /// <summary>
        /// Инициализирует экземпляр класса SteamScraper.
        /// </summary>
        /// <param name="url">URL-адрес страницы с лидерами продаж Steam.</param>
        /// <param name="topCount">Количество игр для извлечения из списка лидеров продаж.</param>
        public SteamScraper(string url, int topCount)
        {
            this.url = url;
            this.topCount = topCount;
        }

        /// <summary>
        /// Асинхронно извлекает список лидеров продаж Steam.
        /// </summary>
        /// <returns>Список объектов TopSeller, представляющих лидеров продаж Steam.</returns>
        public async Task<List<TopSeller>> GetTopSellersAsync()
        {
            var topSellers = new List<TopSeller>();

            try
            {
                var options = new ChromeOptions();
                options.AddArgument("--headless");// Запуск Chrome в режиме без графического интерфейса

                using var driver = new ChromeDriver(options);
                driver.Navigate().GoToUrl(url);

                await Task.Delay(5000);// Ждем загрузки динамического контента

                var rows = driver.FindElements(By.CssSelector(rowSelector));
                int place = 1;
                foreach (var row in rows)
                {
                    if (place > topCount) break;

                    var placeElement = row.FindElement(By.CssSelector(placeSelector));
                    var nameElement = row.FindElement(By.CssSelector(nameSelector));
                    var priceElement = row.FindElement(By.CssSelector(priceSelector));

                    string placeText = placeElement.Text;
                    string name = nameElement.Text.Trim();
                    string price = priceElement.Text.Trim();

                    topSellers.Add(new TopSeller(int.Parse(placeText), name, price));
                    place++;
                }

                driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка:");
                Console.WriteLine(e.Message);
            }

            return topSellers;
        }
    }
}
