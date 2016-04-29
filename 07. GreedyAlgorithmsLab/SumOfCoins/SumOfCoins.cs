namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var chosenCoins = new Dictionary<int, int>();
            var sortedCoins = coins.OrderByDescending(c => c).ToList();
            int currentSum = 0;
            int currentIndex = 0;

            while (currentSum != targetSum && currentIndex < sortedCoins.Count)
            {
                int currentCoinValue = sortedCoins[currentIndex];
                int remainingSum = targetSum - currentSum;
                int coinsToTake = remainingSum / currentCoinValue;
                if (coinsToTake > 0)
                {
                    chosenCoins.Add(currentCoinValue, coinsToTake);
                    currentSum += coinsToTake * currentCoinValue;
                }

                currentIndex++;
            }

            if (currentSum != targetSum)
            {
                throw new InvalidOperationException("Greedy algorithm cannot produce desired sum with specified coins.");
            }

            return chosenCoins;
        }
    }
}