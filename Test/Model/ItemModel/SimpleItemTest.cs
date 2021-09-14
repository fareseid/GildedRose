using csharp.Model.ItemModel;
using NUnit.Framework;
using static csharp.Test.Utils.ItemUtils;
using static NUnit.Framework.Assert;

namespace csharp.Test.Model.ItemModel
{
    [TestFixture]
    public class SimpleItemTest
    { 
        [Test]
        public void Should_Not_Modify_Name()
        { 
            SimpleItem Item = new SimpleItem("foo", 0, 0);

            Item.Update();

            AreEqual("foo", Item.GetName());
        }

        [Test]
        public void Should_Decrement_SellIn_And_Quality()
        { 
            SimpleItem Item = new SimpleItem("SimpleItem", 2, 40); 

            Item.Update();

            AssertOnUpdatableItem(Item, 1, 39);
        }

        [Test]
        public void Should_Degrade_Quality_Twice_As_Fast_When_SellIn_Passed()
        {
            SimpleItem Item = new SimpleItem("SimpleItem", 2, 40);
            Item.Update();
            Item.Update();

            Item.Update();

            AssertOnUpdatableItem(Item, -1, 36);
        }

        [Test]
        public void Should_Not_Decrement_Quality_When_Quality_Is_Zero()
        { 
            SimpleItem Item = new SimpleItem("SimpleItem", 10, 1);
            Item.Update();

            Item.Update();

            AssertOnUpdatableItem(Item, 8, 0);
        }        

    }
}