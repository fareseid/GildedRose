using csharp.Model.ItemModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static csharpTest.Utils.ItemUtils;

namespace csharpTest.Model.ItemModel
{
    [TestClass]
    public class ConjuredItemTest
    { 
        [TestMethod]
        public void Should_Not_Modify_Name()
        { 
            ConjuredItem Item = new ConjuredItem("foo", 0, 0);

            Item.Update();

            AreEqual("foo", Item.GetName());
        }

        [TestMethod]
        public void Should_Decrement_SellIn_And_Twice_Quality_If_Conjured()
        { 
            ConjuredItem Item = new ConjuredItem("ConjuredItem", 2, 40); 

            Item.Update();

            AssertOnUpdatableItem(Item, 1, 38);
        }

        [TestMethod]
        public void Should_Degrade_Quality_Twice_As_Fast_When_SellIn_Passed_If_Conjured()
        {
            ConjuredItem Item = new ConjuredItem("ConjuredItem", 2, 40);
            Item.Update();
            Item.Update();

            Item.Update();

            AssertOnUpdatableItem(Item, -1, 32);
        }

        [TestMethod]
        public void Should_Not_Decrement_Quality_When_Quality_Is_Zero()
        { 
            ConjuredItem Item = new ConjuredItem("ConjuredItem", 10, 1);
            Item.Update();

            Item.Update();

            AssertOnUpdatableItem(Item, 8, 0);
        }         
    }
}