namespace FractionalKnapsackProblem
{
    using System;
    public class Item : IComparable<Item>
    {
        public Item(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price { get; set; }

        public double Weight { get; set; }

        public int CompareTo(Item other)
        {
            double first = other.Price/other.Weight;
            double second = this.Price/this.Weight;
            return first.CompareTo(second);
        }
    }
}
