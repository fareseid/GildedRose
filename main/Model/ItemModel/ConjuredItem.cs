namespace csharp.Model.ItemModel
{
    public class ConjuredItem : UpdatableItem
    {
        public ConjuredItem(Item Item) : base(Item)
        {
        }
        
        public ConjuredItem(string Name, int SellIn, int Quality) : base(Name, SellIn, Quality)
        {
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
                DecrementQuality(); 
                DecrementQualityTwiceIfSellInLessThanZero();
            }
        }
        private void DecrementQualityTwiceIfSellInLessThanZero()
        {
            if (GetSellIn() < 0)
            {
                DecrementQuality();
                DecrementQuality();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is ConjuredItem && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        } 
    }
}