namespace MessageSharing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MessageSharing
    {
        public static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Substring(7)
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] connections = Console.ReadLine()
                .Substring(12)
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] starts = Console.ReadLine()
                .Substring(6)
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            for (int i = 0; i < names.Length; i++)
            {
                graph[names[i]] = new List<string>();
            }
            for (int i = 0; i < connections.Length; i++)
            {
                string[] connectionArgs = connections[i].Split('-').Select(n => n.Trim()).ToArray();
                graph[connectionArgs[0]].Add(connectionArgs[1]);
                graph[connectionArgs[1]].Add(connectionArgs[0]);
            }

            Dictionary<string, int> position = new Dictionary<string, int>();
            Queue<string> receivedTheMessage = new Queue<string>();
            foreach (var start in starts)
            {
                position[start] = 0;
                receivedTheMessage.Enqueue(start);
            }

            while (receivedTheMessage.Count > 0)
            {
                string current = receivedTheMessage.Dequeue();
                foreach (var child in graph[current])
                {
                    if (!position.ContainsKey(child))
                    {
                        position[child] = position[current] + 1;
                        receivedTheMessage.Enqueue(child);
                    }
                }
            }

            int maxStep = position.Values.Max();
            List<string> notVisited = new List<string>();
            List<string> lastVisited = new List<string>();
            foreach (var name in names)
            {
                if (!position.ContainsKey(name))
                {
                    notVisited.Add(name);
                }
                else if (position[name] == maxStep)
                {
                    lastVisited.Add(name);
                }
            }

            if (notVisited.Count > 0)
            {
                Console.WriteLine("Cannot reach: {0}", string.Join(", ", notVisited.OrderBy(p => p)));
            }
            else
            {
                Console.WriteLine("All people reached in {0} steps", maxStep);
                Console.WriteLine("People at last step: {0}", string.Join(", ", lastVisited.OrderBy(p => p)));
            }
        }
    }
}
