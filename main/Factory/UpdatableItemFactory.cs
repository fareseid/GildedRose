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
                    return new AgedBrieItem(Item.Name, Item.SellIn, Item.Quality);
                case EnumItemType.BACKSTAGE_PASSES:
                    return new BackstagePassItem(Item.Name, Item.SellIn, Item.Quality);
                case EnumItemType.SULFURAS:
                    return new SulfurasItem(Item.Name, Item.SellIn, Item.Quality);
                case EnumItemType.CONJURED:
                    return new ConjuredItem(Item.Name, Item.SellIn, Item.Quality);
                case EnumItemType.SIMPLE:
                default:
                    return new SimpleItem(Item.Name, Item.SellIn, Item.Quality);
            }
        }
    }
}