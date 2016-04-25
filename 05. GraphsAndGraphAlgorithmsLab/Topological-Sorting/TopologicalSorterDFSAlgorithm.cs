namespace Topological_Sorting_DFS
{
    using System;
    using System.Collections.Generic;

    public class TopologicalSorterDFSAlgorithm 
    {
        private Dictionary<string, List<string>> graph;
        private LinkedList<string> sortedNodes;
        private HashSet<string> visitedNodes;
        private HashSet<string> cycleNodes;

        public TopologicalSorterDFSAlgorithm(Dictionary<string, List<string>> graph)
        {
            this.graph = graph;
        }

        public ICollection<string> TopSort()
        {
            sortedNodes = new LinkedList<string>();
            visitedNodes = new HashSet<string>();
            this.cycleNodes = new HashSet<string>();

            foreach (var node in this.graph.Keys)
            {
                this.TopSortDfs(node);
            }

            return this.sortedNodes;
        }



        private void TopSortDfs(string node)
        {
            if (this.cycleNodes.Contains(node))
            {
                throw new InvalidOperationException("A cycle detected in a graph");
            }

            if (!this.visitedNodes.Contains(node))
            {
                this.visitedNodes.Add(node);
                this.cycleNodes.Add(node);

                foreach (var child in this.graph[node])
                {
                    this.TopSortDfs(child);
                }
                this.sortedNodes.AddFirst(node);
                this.cycleNodes.Remove(node);
            }
        }
    }
}
