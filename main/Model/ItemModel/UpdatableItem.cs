using System;

namespace csharp.Model.ItemModel
{
    public abstract class UpdatableItem
    {
        private readonly Item Item;

        // This constructor was added since Program.cs is expecting the modification to be done on the Item that it owns.
        //  It might have been more interesting to recreate the object since we are not the owner of this object
        //  and hence should not modify it directly
        public UpdatableItem(Item Item)
        {
            this.Item = Item;
        }

        public UpdatableItem(string Name, int SellIn, int Quality) {
            Item = new Item
            {
                Name = Name,
                SellIn = SellIn,
                Quality = Quality
            };
        }

        public abstract void Update();

        public string GetName()
        {
            return Item.Name;
        }

        public int GetSellIn()
        {
            return Item.SellIn;
        }

        public int GetQuality() {
            return Item.Quality;
        }

        protected void IncrementQuality()
        {
            Item.Quality++;
        }

        protected void DecrementQuality()
        {
            Item.Quality--;
        }
        
        protected void SetQualityToZero()
        {
            Item.Quality = 0;
        }

        protected void DecrementSellIn() {
            Item.SellIn--;
        }

        protected void ResetQualityToZeroIfNegative()
        {
            Item.Quality = (Item.Quality < 0) ? 0 : Item.Quality;
        }

        protected void ResetQualityToFiftyIfHigher()
        {
            Item.Quality = (Item.Quality > 50) ? 50 : Item.Quality;
        }

        public override bool Equals(object obj)
        {
            return obj is UpdatableItem that &&
                this.Item.Name.Equals(that.Item.Name) &&
                this.Item.SellIn.Equals(that.Item.SellIn) &&
                this.Item.Quality.Equals(that.Item.Quality);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Item.Name, Item.SellIn, Item.Quality).GetHashCode(); 
        }
    }
}