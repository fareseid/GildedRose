using csharp.Model.ItemModel;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace csharpTest.Utils
{
    public static class ItemUtils
    {
        public static void AssertOnUpdatableItem(UpdatableItem ActualItem, int ExpectedSellIn, int ExpectedQuality)
        {
            AreEqual(ExpectedSellIn, ActualItem.GetSellIn());
            AreEqual(ExpectedQuality, ActualItem.GetQuality());
        }  
    }
}