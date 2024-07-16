namespace SteamTopSellers
{
    /// <summary>
    /// Класс программы для получения лидеров продаж Steam.
    /// </summary>
    class Program
    {
        private const string baseUrl = "https://store.steampowered.com/charts/topselling/";
        private const string locale = "RU";
        private const int topCount = 10;

        static async Task Main(string[] args)
        {
            string url = baseUrl + locale;
            var scraper = new SteamScraper(url, topCount);

            List<TopSeller> topSellers = await scraper.GetTopSellersAsync();

            Console.WriteLine("Лидеры продаж в Steam " + locale + ":");
            foreach (var seller in topSellers)
            {
                Console.WriteLine($"{seller.Place}. {seller.Name} - {seller.Price}");
            }
        }
    }
}

