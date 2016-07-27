using Kata;

namespace GildedRose
{
    class NormalItemUpdater : IItemUpdater
    {
        public void UpdateItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality -= 1;
                }
            }
        }
    }
}