using csharp.Model.ItemModel;
using NUnit.Framework;
using static csharp.Test.Utils.ItemUtils;
using static NUnit.Framework.Assert;

namespace csharp.Test.Model.ItemModel
{
    [TestFixture]
    public class AgedBrieItemTest
    {
        [Test]
        public void Should_Not_Modify_Name()
        {
            AgedBrieItem Item = new AgedBrieItem("Aged Brie", 0, 0);

            Item.Update();

            AreEqual("Aged Brie", Item.GetName());
        } 

        [Test]
        public void Should_Increment_Quality_If_AgedBrie()
        {
            AgedBrieItem Item = new AgedBrieItem("Aged Brie", 10, 1);

            Item.Update();

            AssertOnUpdatableItem(Item, 9, 2);
        }

        [Test]
        public void Should_Not_Increment_Quality_More_Than_50()
        {
            AgedBrieItem Item = new AgedBrieItem("Aged Brie", 10, 49);
            Item.Update();

            Item.Update();

            AssertOnUpdatableItem(Item, 8, 50);
        }       
    }
}