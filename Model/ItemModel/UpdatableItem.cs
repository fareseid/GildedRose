namespace csharp.Model.ItemModel
{
    public abstract class UpdatableItem
    {
        private readonly Item Item;

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
    }
}