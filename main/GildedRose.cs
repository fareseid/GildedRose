using csharp.Model.ItemModel;
using System.Collections.Generic;
using System.Linq;
using static csharp.Factory.UpdatableItemFactory;
using static csharp.Model.EnumUtils;

namespace csharp
{
    public class GildedRose
    {
        private readonly IList<UpdatableItem> Items;
        
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items.Select(item => BuildUpdatableItem(ToEnum(item.Name), item)).ToList();
        }

        public void UpdateQuality()
        {
            foreach (UpdatableItem CurrentItem in Items)
            {
                CurrentItem.Update();
            }
        }

        public Item Get(int Index)
        {
            return Items[Index].GetUnderlyingItem();
        }
    }
}