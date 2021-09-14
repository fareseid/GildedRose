using csharp.Model;
using NUnit.Framework;
using static csharp.Model.EnumUtils;
using static NUnit.Framework.Assert;

namespace csharp.Test.Model
{
    [TestFixture]
    public class EnumItemTypeTest
    {
        [Test]
        public void Should_Return_AgedBrie_If_Name_Contains_AgedBrie()
        {
            string Name = "Aged Brie";

            EnumItemType ActualItemType = ToEnum(Name); 

            AreEqual(EnumItemType.AGED_BRIE, ActualItemType);
        }

        [Test]
        public void Should_Return_BackstagePasses_If_Name_Contains_BackstagePasses()
        {
            string Name = "Backstage passes to a TAFKAL80ETC concert";

            EnumItemType ActualItemType = ToEnum(Name);

            AreEqual(EnumItemType.BACKSTAGE_PASSES, ActualItemType);
        }

        [Test]
        public void Should_Return_BackstagePasses_With_Different_Concert_Name_If_Name_Contains_BackstagePasses()
        {
            string Name = "Backstage passes ignore string after that";

            EnumItemType ActualItemType = ToEnum(Name);

            AreEqual(EnumItemType.BACKSTAGE_PASSES, ActualItemType);
        }

        [Test]
        public void Should_Return_Sulfuras_If_Name_Contains_Sulfuras()
        {
            string Name = "Sulfuras, Hand of Ragnaros";

            EnumItemType ActualItemType = ToEnum(Name);

            AreEqual(EnumItemType.SULFURAS, ActualItemType);
        }

        [Test]
        public void Should_Return_Sulfuras_With_Different_Suffix_Name_If_Name_Contains_Sulfuras()
        {
            string Name = "Sulfuras ignore string after that";

            EnumItemType ActualItemType = ToEnum(Name);

            AreEqual(EnumItemType.SULFURAS, ActualItemType);
        }

        [Test]
        public void Should_Return_Simple_If_Does_Not_Contains_Any_Other_Enum_Description()
        {
            string Name = "I am a simple item";

            EnumItemType ActualItemType = ToEnum(Name);

            AreEqual(EnumItemType.SIMPLE, ActualItemType);
        }
    }
}
