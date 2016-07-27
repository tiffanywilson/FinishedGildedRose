using GildedRose;

namespace Kata
{
    public class ItemUpdater
    {
        public ItemUpdater()
        {
        }

        public static IItemUpdater Create(Item item)
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                return new BackStagePassUpdater(item);
            }

            if (item.Name == "Aged Brie")
            {
                return new AgedBrieItemUpdater(item);
            }

            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return new LegendaryItemUpdater(item);
            }

            if (item.Name == "Conjured")
            {
                return new ConjuredItemUpdater(item);
            }
            return new NormalItemUpdater(item);
        }
    }
}