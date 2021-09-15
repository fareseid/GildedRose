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

        // I did not want to modify the creation of Item as well as the signature of this constructor and methods; 
        //  this is why I am mapping Item to UpdatableItem
        //  inside the constructor not at Item Creation Level in Program.cs
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
    }
}