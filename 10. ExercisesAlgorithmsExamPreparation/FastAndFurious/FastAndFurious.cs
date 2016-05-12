namespace FastAndFurious
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class FastAndFurious
    {
        public static void Main(string[] args)
        {
            var cities = new Dictionary<string, List<Tuple<string, double>>>();
            var townsIndex = new Dictionary<string, int>();
            ReadRoads(cities, townsIndex);
            double[,] distances = BuildGraph(cities, townsIndex);

            var cars = new Dictionary<string, List<Tuple<string, DateTime>>>();
            var speededCars = new SortedSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] carArgs = input.Split();
                string town = carArgs[0];
                string licenseNumber = carArgs[1];
                DateTime time = DateTime.Parse(carArgs[2]);
                if (!cars.ContainsKey(licenseNumber))
                {
                    cars[licenseNumber] = new List<Tuple<string, DateTime>>();
                    cars[licenseNumber].Add(new Tuple<string, DateTime>(town, time));
                    continue;
                }

                foreach (var record in cars[licenseNumber])
                {
                    string recordTown = record.Item1;
                    double duration = Math.Abs((time - record.Item2).TotalHours);
                    if (!double.IsPositiveInfinity(distances[townsIndex[town], townsIndex[recordTown]]) &&
                        distances[townsIndex[town], townsIndex[recordTown]] > duration)
                    {
                        speededCars.Add(licenseNumber);
                    }
                }
                cars[licenseNumber].Add(new Tuple<string, DateTime>(town, time));
            }
            
            foreach (var speededCar in speededCars)
            {
                Console.WriteLine(speededCar);
            }
            
        }

        private static void ReadRoads(Dictionary<string, List<Tuple<string, double>>> cities, Dictionary<string, int> townsIndex)
        {
            int index = 0;
            Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Records:")
                {
                    break;
                }
                string[] inputArgs = input.Split();
                string startCity = inputArgs[0];
                string endCity = inputArgs[1];
                double km = double.Parse(inputArgs[2]);
                double speed = double.Parse(inputArgs[3]);
                double timeNeeded = km/speed;
                if (!cities.ContainsKey(startCity))
                {
                    cities[startCity] = new List<Tuple<string, double>>();
                    townsIndex[startCity] = index;
                    index++;
                }
                if (!cities.ContainsKey(endCity))
                {
                    cities[endCity] = new List<Tuple<string, double>>();
                    townsIndex[endCity] = index;
                    index++;
                }
                cities[startCity].Add(new Tuple<string, double>(endCity, timeNeeded));
                cities[endCity].Add(new Tuple<string, double>(startCity, timeNeeded));
            }
        }

        private static double[,] BuildGraph(Dictionary<string, List<Tuple<string, double>>> cities, Dictionary<string, int> townsIndex)
        {
            double[,] distances = new double[cities.Count, cities.Count];
            for (int row = 0; row < distances.GetLength(0); row++)
            {
                for (int col = 0; col < distances.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        continue;
                    }

                    distances[row, col] = double.PositiveInfinity;
                }

            }

            foreach (var city in cities)
            {
                int startIndex = townsIndex[city.Key];
                foreach (var connection in city.Value)
                {
                    int endIndex = townsIndex[connection.Item1];
                    distances[startIndex, endIndex] = connection.Item2;
                }
            }

            for (int k = 0; k < distances.GetLength(0); k++)
            {
                for (int i = 0; i < distances.GetLength(0); i++)
                {
                    for (int j = 0; j < distances.GetLength(0); j++)
                    {
                        if (distances[i, j] > distances[i, k] + distances[k, j])
                        {
                            distances[i, j] = distances[i, k] + distances[k, j];
                        }
                    }
                }
            }

            return distances;
        }
    }
}
