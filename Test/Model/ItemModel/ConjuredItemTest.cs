using csharp.Model.ItemModel;
using NUnit.Framework;
using static csharp.Test.Utils.ItemUtils;
using static NUnit.Framework.Assert;

namespace csharp.Test.Model.ItemModel
{
    [TestFixture]
    public class ConjuredItemTest
    { 
        [Test]
        public void Should_Not_Modify_Name()
        { 
            ConjuredItem Item = new ConjuredItem("foo", 0, 0);

            Item.Update();

            AreEqual("foo", Item.GetName());
        }

        [Test]
        public void Should_Decrement_SellIn_And_Twice_Quality_If_Conjured()
        { 
            ConjuredItem Item = new ConjuredItem("ConjuredItem", 2, 40); 

            Item.Update();

            AssertOnUpdatableItem(Item, 1, 38);
        }

        [Test]
        public void Should_Degrade_Quality_Twice_As_Fast_When_SellIn_Passed_If_Conjured()
        {
            ConjuredItem Item = new ConjuredItem("ConjuredItem", 2, 40);
            Item.Update();
            Item.Update();

            Item.Update();

            AssertOnUpdatableItem(Item, -1, 32);
        }

        [Test]
        public void Should_Not_Decrement_Quality_When_Quality_Is_Zero()
        { 
            ConjuredItem Item = new ConjuredItem("ConjuredItem", 10, 1);
            Item.Update();

            Item.Update();

            AssertOnUpdatableItem(Item, 8, 0);
        }         
    }
}