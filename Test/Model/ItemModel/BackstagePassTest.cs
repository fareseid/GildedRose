using csharp.Model.ItemModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static csharpTest.Utils.ItemUtils;

namespace csharpTest.Model.ItemModel
{
    [TestClass]
    public class BackstagePassTest
    { 
        [TestMethod]
        public void Should_Not_Modify_Name()
        {
            BackstagePassItem Item = new BackstagePassItem("Backstage passes to a TAFKAL80ETC concert", 0, 0);

            Item.Update();

            AreEqual("Backstage passes to a TAFKAL80ETC concert", Item.GetName());
        } 

        [TestMethod]
        public void Should_Increment_Quality_If_BackstagePass()
        { 
            BackstagePassItem Item = new BackstagePassItem("Backstage passes to a TAFKAL80ETC concert", 11, 1);

            Item.Update();

            AssertOnUpdatableItem(Item, 10, 2);
        }

        [TestMethod]
        public void Should_Increment_Quality_By_2_If_BackstagePass_And_SellIn_Equals_To_10()
        { 
            BackstagePassItem Item = new BackstagePassItem("Backstage passes to a TAFKAL80ETC concert", 10, 30);

            Item.Update();

            AssertOnUpdatableItem(Item, 9, 32);
        }

        [TestMethod]
        public void Should_Increment_Quality_By_2_If_BackstagePass_And_SellIn_Less_Than_10()
        { 
            BackstagePassItem Item = new BackstagePassItem("Backstage passes to a TAFKAL80ETC concert", 9, 30);

            Item.Update();

            AssertOnUpdatableItem(Item, 8, 32);
        }

        [TestMethod]
        public void Should_Increment_Quality_By_3_If_BackstagePass_And_SellIn_Equals_To_5()
        { 
            BackstagePassItem Item = new BackstagePassItem("Backstage passes to a TAFKAL80ETC concert", 5, 30);

            Item.Update();

            AssertOnUpdatableItem(Item, 4, 33);
        }

        [TestMethod]
        public void Should_Increment_Quality_By_3_If_BackstagePass_And_SellIn_Less_Than_5()
        { 
            BackstagePassItem Item = new BackstagePassItem("Backstage passes to a TAFKAL80ETC concert", 4, 30);

            Item.Update();

            AssertOnUpdatableItem(Item, 3, 33);
        }

        [TestMethod]
        public void Should_Set_Quality_To_Zero_If_BackstagePass_And_SellIn_Equals_Zero()
        { 
            BackstagePassItem Item = new BackstagePassItem("Backstage passes to a TAFKAL80ETC concert", 0, 30);

            Item.Update();

            AssertOnUpdatableItem(Item, -1, 0);
        }
    }
}