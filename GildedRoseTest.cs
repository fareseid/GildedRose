using NUnit.Framework;
using System.Collections.Generic;
using static NUnit.Framework.Assert;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void Should_Not_Modify_Name()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void Should_Decrement_SellIn_And_Quality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "SimpleItem", SellIn = 2, Quality = 40 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 39, 1);
        }

        [Test]
        public void Should_Degrade_Quality_Twice_As_Fast_When_SellIn_Passed()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "SimpleItem", SellIn = 2, Quality = 40 } };
            GildedRose App = new GildedRose(Items);
            App.UpdateQuality();
            App.UpdateQuality();

            App.UpdateQuality();

            AssertOnItem(Items[0], 36, -1);
        }

        [Test]
        public void Should_Not_Decrement_Quality_When_Quality_Is_Zero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "SimpleItem", SellIn = 10, Quality = 1 } };
            GildedRose App = new GildedRose(Items);
            App.UpdateQuality();

            App.UpdateQuality();

            AssertOnItem(Items[0], 0, 8);
        }

        [Test]
        public void Should_Increment_Quality_If_AgedBrie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 1 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 2, 9);
        }

        [Test]
        public void Should_Not_Increment_Quality_More_Than_50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 49 } };
            GildedRose App = new GildedRose(Items);
            App.UpdateQuality();

            App.UpdateQuality();

            AssertOnItem(Items[0], 50, 8);
        }

        [Test]
        public void Should_Not_Modify_SellIn_Nor_Quality_If_Sulfuras()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 49 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 49, 10);
        }

        [Test]
        public void Should_Increment_Quality_If_BackstagePass()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 1 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 2, 10);
        }

        [Test]
        public void Should_Increment_Quality_By_2_If_BackstagePass_And_SellIn_Equals_To_10()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 30 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 32, 9);
        }

        [Test]
        public void Should_Increment_Quality_By_2_If_BackstagePass_And_SellIn_Less_Than_10()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 30 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 32, 8);
        }

        [Test]
        public void Should_Increment_Quality_By_3_If_BackstagePass_And_SellIn_Equals_To_5()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 30 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 33, 4);
        }

        [Test]
        public void Should_Increment_Quality_By_3_If_BackstagePass_And_SellIn_Less_Than_5()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 30 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 33, 3);
        }

        [Test]
        public void Should_Set_Quality_To_Zero_If_BackstagePass_And_SellIn_Equals_Zero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 30 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 0, -1);
        }

        private static void AssertOnItem(Item ActualItem, int ExpectedQuality, int ExpectedSellIn)
        {
            AreEqual(ExpectedQuality, ActualItem.Quality);
            AreEqual(ExpectedSellIn, ActualItem.SellIn);
        }
    }
}
