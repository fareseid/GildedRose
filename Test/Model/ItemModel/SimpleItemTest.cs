using csharp.Model.ItemModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static csharpTest.Utils.ItemUtils;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace csharpTest.Model.ItemModel
{
    [TestClass]
    public class SimpleItemTest
    { 
        [TestMethod]
        public void Should_Not_Modify_Name()
        { 
            SimpleItem Item = new SimpleItem("foo", 0, 0);

            Item.Update();

            AreEqual("foo", Item.GetName());
        }

        [TestMethod]
        public void Should_Decrement_SellIn_And_Quality()
        { 
            SimpleItem Item = new SimpleItem("SimpleItem", 2, 40); 

            Item.Update();

            AssertOnUpdatableItem(Item, 1, 39);
        }

        [TestMethod]
        public void Should_Degrade_Quality_Twice_As_Fast_When_SellIn_Passed()
        {
            SimpleItem Item = new SimpleItem("SimpleItem", 2, 40);
            Item.Update();
            Item.Update();

            Item.Update();

            AssertOnUpdatableItem(Item, -1, 36);
        }

        [TestMethod]
        public void Should_Not_Decrement_Quality_When_Quality_Is_Zero()
        { 
            SimpleItem Item = new SimpleItem("SimpleItem", 10, 1);
            Item.Update();

            Item.Update();

            AssertOnUpdatableItem(Item, 8, 0);
        }        

    }
}