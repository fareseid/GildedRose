using csharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace csharpTest
{
    [TestClass]
    public class GildedRoseTest
    {
        [TestMethod]
        public void Should_Not_Modify_Name()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AreEqual("foo", Items[0].Name);
        }

        [TestMethod]
        public void Should_Decrement_SellIn_And_Quality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "SimpleItem", SellIn = 2, Quality = 40 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 1, 39);
        }

        [TestMethod]
        public void Should_Degrade_Quality_Twice_As_Fast_When_SellIn_Passed()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "SimpleItem", SellIn = 2, Quality = 40 } };
            GildedRose App = new GildedRose(Items);
            App.UpdateQuality();
            App.UpdateQuality();

            App.UpdateQuality();

            AssertOnItem(Items[0], -1, 36);
        }

        [TestMethod]
        public void Should_Not_Decrement_Quality_When_Quality_Is_Zero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "SimpleItem", SellIn = 10, Quality = 1 } };
            GildedRose App = new GildedRose(Items);
            App.UpdateQuality();

            App.UpdateQuality();

            AssertOnItem(Items[0], 8, 0);
        }

        [TestMethod]
        public void Should_Increment_Quality_If_AgedBrie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 1 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 9, 2);
        }

        [TestMethod]
        public void Should_Not_Increment_Quality_More_Than_50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 49 } };
            GildedRose App = new GildedRose(Items);
            App.UpdateQuality();

            App.UpdateQuality();

            AssertOnItem(Items[0], 8, 50);
        }

        [TestMethod]
        public void Should_Not_Modify_SellIn_Nor_Quality_If_Sulfuras()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 49 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 10, 49);
        }

        [TestMethod]
        public void Should_Increment_Quality_If_BackstagePass()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 1 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 10, 2);
        }

        [TestMethod]
        public void Should_Increment_Quality_By_2_If_BackstagePass_And_SellIn_Equals_To_10()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 30 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 9, 32);
        }

        [TestMethod]
        public void Should_Increment_Quality_By_2_If_BackstagePass_And_SellIn_Less_Than_10()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 30 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 8, 32);
        }

        [TestMethod]
        public void Should_Increment_Quality_By_3_If_BackstagePass_And_SellIn_Equals_To_5()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 30 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 4, 33);
        }

        [TestMethod]
        public void Should_Increment_Quality_By_3_If_BackstagePass_And_SellIn_Less_Than_5()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 30 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], 3, 33);
        }

        [TestMethod]
        public void Should_Set_Quality_To_Zero_If_BackstagePass_And_SellIn_Equals_Zero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 30 } };
            GildedRose App = new GildedRose(Items);

            App.UpdateQuality();

            AssertOnItem(Items[0], -1, 0);
        }

        public static void AssertOnItem(Item ActualItem, int ExpectedSellIn, int ExpectedQuality)
        {
            AreEqual(ExpectedSellIn, ActualItem.SellIn);
            AreEqual(ExpectedQuality, ActualItem.Quality);
        }
    }
}