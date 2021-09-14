using csharp.Model.ItemModel;
using NUnit.Framework;
using static csharp.Test.Utils.ItemUtils;
using static NUnit.Framework.Assert;

namespace csharp.Test.Model.ItemModel
{
    [TestFixture]
    public class SulfurasItemTest
    {
        [Test]
        public void Should_Not_Modify_Name()
        {
            SulfurasItem Item = new SulfurasItem("Sulfuras", 0, 0);

            Item.Update();

            AreEqual("Sulfuras", Item.GetName());
        }    

        [Test]
        public void Should_Not_Modify_SellIn_Nor_Quality_If_Sulfuras()
        {
            SulfurasItem Item = new SulfurasItem("Sulfuras", 10, 49); 

            Item.Update();

            AssertOnUpdatableItem(Item, 10, 49);
        }
    }
}