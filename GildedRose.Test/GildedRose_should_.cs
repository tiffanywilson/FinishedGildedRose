using System.Collections.Generic;
using Kata;
using NUnit.Framework;

namespace GildedRose.Test
{
    public class GildedRose_
    {
        [Test]
        public void should_lower_quality_at_the_end_of_each_day()
        {
            var item = new Item
            {
                Name = "Test",
                Quality = 3,
                SellIn = 2
            };
            var gr = new Kata.GildedRose(new List<Item> {item});

            gr.UpdateQuality();

            Assert.AreEqual(2, item.Quality);
        }

        [Test]
        public void should_lower_sellin_at_the_end_of_the_day()
        {
            var item = new Item
            {
                Name = "Test",
                Quality = 3,
                SellIn = 3
            };

            var gr = new Kata.GildedRose(new List<Item> {item});

            gr.UpdateQuality();

            Assert.AreEqual(2, item.SellIn);
        }


        [Test]
        public void should_lower_quality_twice_as_fast_after_sell_by()
        {
            var item = new Item
            {
                Name = "Test",
                Quality = 3,
                SellIn = 0
            };

            var gr = new Kata.GildedRose(new List<Item> {item});

            gr.UpdateQuality();

            Assert.AreEqual(1, item.Quality);
        }

        [Test]
        public void should_not_decrease_quality_below_zero()
        {
            var item = new Item
            {
                Name = "Test",
                Quality = 0,
                SellIn = 0
            };

            var gr = new Kata.GildedRose(new List<Item> {item});

            gr.UpdateQuality();

            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void should_increase_aged_brie_quality_as_sellin_date_decreases()
        {
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = 1,
                SellIn = 5
            };

            var gr = new Kata.GildedRose(new List<Item> {item});

            gr.UpdateQuality();

            Assert.AreEqual(2, item.Quality);
        }

        [Test]
        public void should_never_increase_quality_above_50()
        {
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = 50,
                SellIn = 5
            };

            var gr = new Kata.GildedRose(new List<Item> {item});

            gr.UpdateQuality();

            Assert.AreEqual(50, item.Quality);
        }

        //"Backstage passes" increases in Quality as it's SellIn value approaches
        [Test]
        public void should_increment_backstage_passes_quality_by_1_when_sellin_greater_than_10()
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 5,
                SellIn = 11
            };

            var gr = new Kata.GildedRose(new List<Item> {item});

            gr.UpdateQuality();

            Assert.AreEqual(6, item.Quality);
        }

        //Quality increases by 2 when there are 10 days or less
        [TestCase(10)]
        [TestCase(9)]

        public void should_increment_backstage_passes_quality_by_2_when_sellin_less_than_or_equal_to_10(int sellIn)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 5,
                SellIn = sellIn
            };

            var gr = new Kata.GildedRose(new List<Item> { item });

            gr.UpdateQuality();

            Assert.AreEqual(7, item.Quality);
        }

        // by 3 when there are 5 days or less 
        [TestCase(5)]
        [TestCase(4)]

        public void should_increment_backstage_passes_quality_by_3_when_sellin_less_than_or_equal_to_5(int sellIn)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 5,
                SellIn = sellIn
            };

            var gr = new Kata.GildedRose(new List<Item> { item });

            gr.UpdateQuality();

            Assert.AreEqual(8, item.Quality);
        }

        [Test]
        public void should_set_quality_to_0_after_SellIn_equals_zero()
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 5,
                SellIn = 0,
            };

            var gr = new Kata.GildedRose(new List<Item> { item });

            gr.UpdateQuality();

            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void should_not_alter_the_quality_of_legendary_items()
        {
            var item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = 80,
                SellIn = 3,
            };

            var gr = new Kata.GildedRose(new List<Item> { item });

            gr.UpdateQuality();

            Assert.AreEqual(80, item.Quality);
        }

        [Test]
        public void should_not_alter_the_sellin_of_legendary_items()
        {
            var item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = 80,
                SellIn = 3,
            };

            var gr = new Kata.GildedRose(new List<Item> { item });

            gr.UpdateQuality();

            Assert.AreEqual(3, item.SellIn);
        }

        [Test]
        public void should_decrease_quality_of_conjured_items_twice_as_fast()
        {
                var item = new Item
                {
                    Name = "Conjured",
                    Quality = 10,
                    SellIn = 5,
                };

                var gr = new Kata.GildedRose(new List<Item> { item });

                gr.UpdateQuality();

                Assert.AreEqual(8, item.Quality);
        }
    }
}
