namespace csharp.Model.ItemModel
{
    public class SimpleItem: UpdatableItem
    { 

        public SimpleItem(string Name, int SellIn, int Quality) : base(Name,SellIn,Quality) { 
        }

        public override void Update()
        {
            DecrementSellIn();
            UpdateQuality();
            ResetQualityToZeroIfNegative();
        }

        private void UpdateQuality()
        {
            if (GetQuality() != 0)
            {
                DecrementQuality();
                DecrementQualityIfSellInLessThanZero();
            }
        }

        private void DecrementQualityIfSellInLessThanZero()
        {
            if (GetSellIn() < 0)
            {
                DecrementQuality();
            }
        }
    }
}