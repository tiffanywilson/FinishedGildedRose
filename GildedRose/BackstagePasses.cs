using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Kata;

namespace GildedRose
{

    class BackStagePassUpdater : IItemUpdater
    {
        private readonly Item item;

        public BackStagePassUpdater(Item item)
        {
            this.item = item;
        }

        public void UpdateItem()
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }

            else if (item.SellIn < 6)
            {
                item.Quality += 3;
            }

            else if (item.SellIn <11)
            {
                item.Quality += 2;
            }

            else
            {
                item.Quality += 1;
            }

            item.Quality = Math.Min(50, item.Quality);
        }
    }
}
