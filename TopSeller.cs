namespace SteamTopSellers
{
    /// <summary>
    /// Класс, представляющий информацию об игре из лидеров продаж.
    /// </summary>
    public class TopSeller
    {
        public int Place { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

        public TopSeller(int place, string name, string price)
        {
            Place = place;
            Name = name;
            Price = price;
        }
    }
}
