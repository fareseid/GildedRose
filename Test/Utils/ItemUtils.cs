using csharp.Model.ItemModel;
using static NUnit.Framework.Assert;

namespace csharp.Test.Utils
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