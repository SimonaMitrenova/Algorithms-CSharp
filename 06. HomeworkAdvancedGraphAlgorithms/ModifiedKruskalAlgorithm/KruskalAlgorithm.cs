namespace ModifiedKruskalAlgorithm
{
    using System;
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(Dictionary<int, Node> nodes, List<Edge> edges)
        {
            edges.Sort();
            var spanningTree = new List<Edge>();
            foreach (var edge in edges)
            {
                Node rootStartNode = FindRoot(edge.StartNode, nodes);
                Node rootEndNode = FindRoot(edge.EndNode, nodes);
                if (rootStartNode.Id != rootEndNode.Id)
                {
                    spanningTree.Add(edge);
                    rootStartNode.Parent = rootEndNode.Parent;
                }
            }

            return spanningTree;

        }

        private static Node FindRoot(int node, Dictionary<int, Node> nodes)
        {
            int root = node;
            while (nodes[root].Parent != root)
            {
                root = nodes[root].Parent;
            }

            while (node != root)
            {
                int oldParent = nodes[node].Parent;
                nodes[node].Parent = root;
                node = oldParent;
            }

            return nodes[root];
        }
    }
}
