namespace Knapsack_Problem
{
    public class Item
    {
        public int Weight { get; set; }

        public int Price { get; set; }

        public override string ToString()
        {
            return string.Format("  (weight: {0}, price: {1})", this.Weight, this.Price);
        }
    }
}
