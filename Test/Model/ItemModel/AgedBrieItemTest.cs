using csharp.Model.ItemModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static csharpTest.Utils.ItemUtils;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace csharpTest.Model.ItemModel
{
    [TestClass]
    public class AgedBrieItemTest
    {
        [TestMethod]
        public void Should_Not_Modify_Name()
        {
            AgedBrieItem Item = new AgedBrieItem("Aged Brie", 0, 0);

            Item.Update();

            AreEqual("Aged Brie", Item.GetName());
        }

        [TestMethod]
        public void Should_Increment_Quality_If_AgedBrie()
        {
            AgedBrieItem Item = new AgedBrieItem("Aged Brie", 10, 1);

            Item.Update();

            AssertOnUpdatableItem(Item, 9, 2);
        }

        [TestMethod]
        public void Should_Not_Increment_Quality_More_Than_50()
        {
            AgedBrieItem Item = new AgedBrieItem("Aged Brie", 10, 49);
            Item.Update();

            Item.Update();

            AssertOnUpdatableItem(Item, 8, 50);
        }
    }
}