using csharp.Model;
using csharp.Model.ItemModel;

namespace csharp.Factory
{
    public static class UpdatableItemFactory
    {
        public static UpdatableItem BuildUpdatableItem(EnumItemType ItemType, Item Item)
        {
            switch (ItemType) { 
                case EnumItemType.AGED_BRIE:
                    return new AgedBrieItem(Item);
                case EnumItemType.BACKSTAGE_PASSES:
                    return new BackstagePassItem(Item);
                case EnumItemType.SULFURAS:
                    return new SulfurasItem(Item);
                case EnumItemType.CONJURED:
                    return new ConjuredItem(Item);
                case EnumItemType.SIMPLE:
                default:
                    return new SimpleItem(Item);  
            }
        }
    }
}