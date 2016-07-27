using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kata;

namespace GildedRose
{
    class ConjuredItemUpdater: IItemUpdater
    {
        public void UpdateItem()
        {
            if (item.Quality > 0)
            {
                item.Quality -= 2;
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality = 0;
                }
            }
        }
    }
}
