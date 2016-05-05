namespace FractionalKnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FractionalKnapsackProblem
    {
        public static void Main(string[] args)
        {
            double capasity = double.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            int itemsCount = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            List<Item> items = new List<Item>();
            for (int i = 0; i < itemsCount; i++)
            {
                double[] itemsParams =
                    Console.ReadLine()
                        .Split(new[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(double.Parse)
                        .ToArray();
                var item = new Item(itemsParams[0], itemsParams[1]);
                items.Add(item);
            }

            items.Sort();
            double totalPrice = 0;
            while (capasity > 0 && items.Count > 0)
            {
                var currentItem = items[0];

                double persentTaken = capasity / currentItem.Weight;
                double weigthTaken = capasity;
                if (persentTaken > 1)
                {
                    persentTaken = 1;
                    weigthTaken = currentItem.Weight;
                }
                totalPrice += persentTaken * currentItem.Price;
                capasity -= weigthTaken;
                items.RemoveAt(0);
                Console.WriteLine("Take {0:P} of item with price {1:f2} and weight {2:f2}", persentTaken, currentItem.Price, currentItem.Weight);
            }

            Console.WriteLine("Total price: {0:f2}", totalPrice);
        }
    }
}
