using csharp;
using csharp.Model;
using csharp.Model.ItemModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static csharp.Factory.UpdatableItemFactory;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace csharpTest.Factory
{
    [TestClass]
    public class UpdatableItemFactoryTest
    {
        [TestMethod]
        public void Should_Build_AgedBrie_Item_If_Enum_Is_AgedBrie()
        {
            EnumItemType ItemType = EnumItemType.AGED_BRIE;
            Item Item = new Item()
            {
                Name = "Aged Brie",
                SellIn = 12,
                Quality = 40
            };

            UpdatableItem ActualItem = BuildUpdatableItem(ItemType, Item);

            AgedBrieItem ExpectedItem = new AgedBrieItem("Aged Brie", 12, 40);
            AreEqual(ExpectedItem, ActualItem);
        }

        [TestMethod]
        public void Should_Build_BackstagePass_Item_If_Enum_Is_BackstagePass()
        {
            EnumItemType ItemType = EnumItemType.BACKSTAGE_PASSES;
            Item Item = new Item()
            {
                Name = "Backstage Pass",
                SellIn = 12,
                Quality = 40
            };

            UpdatableItem ActualItem = BuildUpdatableItem(ItemType, Item);

            BackstagePassItem ExpectedItem = new BackstagePassItem("Backstage Pass", 12, 40);
            AreEqual(ExpectedItem, ActualItem);
        }

        [TestMethod]
        public void Should_Build_Sulfuras_Item_If_Enum_Is_Sulfuras()
        {
            EnumItemType ItemType = EnumItemType.SULFURAS;
            Item Item = new Item()
            {
                Name = "Sulfuras",
                SellIn = 12,
                Quality = 40
            };

            UpdatableItem ActualItem = BuildUpdatableItem(ItemType, Item);

            SulfurasItem ExpectedItem = new SulfurasItem("Sulfuras", 12, 40);
            AreEqual(ExpectedItem, ActualItem);
        }

        [TestMethod]
        public void Should_Build_Conjured_Item_If_Enum_Is_Conjured()
        {
            EnumItemType ItemType = EnumItemType.CONJURED;
            Item Item = new Item()
            {
                Name = "Conjured",
                SellIn = 12,
                Quality = 40
            };

            UpdatableItem ActualItem = BuildUpdatableItem(ItemType, Item);

            ConjuredItem ExpectedItem = new ConjuredItem("Conjured", 12, 40);
            AreEqual(ExpectedItem, ActualItem);
        }

        [TestMethod]
        public void Should_Build_Simple_Item_If_Enum_Is_Simple()
        {
            EnumItemType ItemType = EnumItemType.SIMPLE;
            Item Item = new Item()
            {
                Name = "Simple",
                SellIn = 12,
                Quality = 40
            };

            UpdatableItem ActualItem = BuildUpdatableItem(ItemType, Item);

            SimpleItem ExpectedItem = new SimpleItem("Simple", 12, 40);
            AreEqual(ExpectedItem, ActualItem);
        }
    }
}