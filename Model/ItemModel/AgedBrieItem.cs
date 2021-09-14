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

        public override bool Equals(object obj)
        {
            return obj is AgedBrieItem &&  base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}