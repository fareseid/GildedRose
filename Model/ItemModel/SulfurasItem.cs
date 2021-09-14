namespace csharp.Model.ItemModel
{
    public class SulfurasItem :UpdatableItem
    {
        public SulfurasItem(string Name, int SellIn, int Quality) :base(Name, SellIn, Quality)
        { 
        }

        public override void Update()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is SulfurasItem && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}