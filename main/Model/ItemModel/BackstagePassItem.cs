namespace csharp.Model.ItemModel
{
    public class BackstagePassItem : UpdatableItem
    {
        public BackstagePassItem(Item Item) : base(Item)
        {
        }

        public BackstagePassItem(string Name, int SellIn, int Quality) : base(Name, SellIn, Quality)
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
                IncrementQualityIfSellInLessThanTen();
                IncrementQualityIfSellInLessThanFive();
            }
            SetQualityToZeroIfSellInLessThanZero();
        }

        private void SetQualityToZeroIfSellInLessThanZero()
        {
            if (GetSellIn() < 0)
            {
                SetQualityToZero();
            }
        }

        private void IncrementQualityIfSellInLessThanFive()
        {
            if (GetSellIn() < 5)
            {
                IncrementQuality();
            }
        }

        private void IncrementQualityIfSellInLessThanTen()
        {
            if (GetSellIn() < 10)
            {
                IncrementQuality();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is BackstagePassItem && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}