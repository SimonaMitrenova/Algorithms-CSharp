namespace AStarAlgorithm
{
    using System;
    using System.Collections.Generic;

    public class AStar
    {
        private readonly PriorityQueue<Node> openNodesByFCost;
        private readonly HashSet<Node> closedSet;
        private readonly char[,] map;
        private readonly Node[,] graph;

        public AStar(char[,] map)
        {
            this.map = map;
            this.graph = new Node[map.GetLength(0), map.GetLength(1)];
            this.closedSet = new HashSet<Node>();
            this.openNodesByFCost = new PriorityQueue<Node>();
        }

        public List<int[]> FindShortestPath(int[] startCoords, int[] endCoords)
        {
            var startNode = this.GetNode(startCoords[0], startCoords[1]);
            startNode.GCost = 0;
            this.openNodesByFCost.Enqueue(startNode);

            while (this.openNodesByFCost.Count > 0)
            {
                var node = this.openNodesByFCost.ExtractMin();
                this.closedSet.Add(node);
                if (node.Row == endCoords[0] && node.Col == endCoords[1])
                {
                    return this.ReconstructPath(node);
                }

                var neighbours = this.GetNeighbours(node);
                foreach (var neighbour in neighbours)
                {
                    if (this.closedSet.Contains(neighbour))
                    {
                        continue;
                    }
                    var gCost = node.GCost + this.CalculateGCost(neighbour, node);
                    if (gCost < neighbour.GCost)
                    {
                        neighbour.GCost = gCost;
                        neighbour.Parent = node;
                        if (!this.openNodesByFCost.Contains(neighbour))
                        {
                            neighbour.HCost = this.CalculateHCost(neighbour, endCoords);
                            this.openNodesByFCost.Enqueue(neighbour);
                        }
                        else
                        {
                            this.openNodesByFCost.DecreaseKey(neighbour);
                        }
                    }
                }
            }

            return new List<int[]>(0);
        }

        private List<int[]> ReconstructPath(Node currentNode)
        {
            var cells = new List<int[]>();
            while (currentNode != null)
            {
                cells.Add(new []{currentNode.Row, currentNode.Col});
                currentNode = currentNode.Parent;
            }

            return cells;
        }

        private int CalculateHCost(Node node, int[] endCoords)
        {
            return this.GetDistance(node.Row, node.Col, endCoords[0], endCoords[1]);
        }

        private int CalculateGCost(Node node, Node previous)
        {
            return this.GetDistance(node.Row, node.Col, previous.Row, previous.Col);
        }

        private int GetDistance(int row1, int col1, int row2, int col2)
        {
            var deltaX = Math.Abs(col1 - col2);
            var deltaY = Math.Abs(row1 - row2);

            if (deltaX > deltaY)
            {
                return 14 * deltaY + 10 * (deltaX - deltaY);
            }

            return 14 * deltaX + 10 * (deltaY - deltaX);
        }

        private Node GetNode(int row, int col)
        {
            if (this.graph[row, col] == null)
            {
                this.graph[row, col] = new Node(row, col);
            }

            return this.graph[row, col];
        }

        private List<Node> GetNeighbours(Node node)
        {
            var neighbours = new List<Node>();
            for (int row = node.Row - 1; row <= node.Row + 1; row++)
            {
                for (int col = node.Col - 1; col <= node.Col + 1; col++)
                {
                    if (row == node.Row && col == node.Col)
                    {
                        continue;
                    }
                    if (this.IsInRange(row, col))
                    {
                        var newNode = this.GetNode(row, col);
                        neighbours.Add(newNode);
                    }
                }
            }

            return neighbours;
        }

        private bool IsInRange(int row, int col)
        {
            return (row >= 0) && (row < this.map.GetLength(0)) && (col >= 0) && (col < this.map.GetLength(1)) && this.map[row, col] != 'W';
        }
    }
}
