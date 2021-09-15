using csharp.Model.ItemModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static csharpTest.Utils.ItemUtils;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace csharpTest.Model.ItemModel
{
    [TestClass]
    public class SulfurasItemTest
    {
        [TestMethod]
        public void Should_Not_Modify_Name()
        {
            SulfurasItem Item = new SulfurasItem("Sulfuras", 0, 0);

            Item.Update();

            AreEqual("Sulfuras", Item.GetName());
        }    

        [TestMethod]
        public void Should_Not_Modify_SellIn_Nor_Quality_If_Sulfuras()
        {
            SulfurasItem Item = new SulfurasItem("Sulfuras", 10, 49); 

            Item.Update();

            AssertOnUpdatableItem(Item, 10, 49);
        }
    }
}