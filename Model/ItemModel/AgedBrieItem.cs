namespace csharp.Model.ItemModel
{
    public class AgedBrieItem : UpdatableItem
    { 
        public AgedBrieItem(string Name, int SellIn, int Quality) : base(Name, SellIn, Quality)
        {
        }

        public override void Update()
        {
            DecrementSellIn();
            UpdateQuality();
            ResetQualityToFiftyIfHigher();
        }

        private void UpdateQuality()
        {
            if (GetQuality() != 50)
            {
                IncrementQuality();
                IncrementQualityIfSellInLessThanZero();
            }
        }

        private void IncrementQualityIfSellInLessThanZero()
        {
            if (GetSellIn() < 0)
            {
                IncrementQuality();
            }
        }
    }
}