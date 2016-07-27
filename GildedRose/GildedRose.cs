using System.Collections.Generic;
using GildedRose;

namespace Kata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            _itemUpdater = new ItemUpdater();
        }

        private readonly ItemUpdater _itemUpdater;

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                ItemUpdater.Create(item).UpdateItem();
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}