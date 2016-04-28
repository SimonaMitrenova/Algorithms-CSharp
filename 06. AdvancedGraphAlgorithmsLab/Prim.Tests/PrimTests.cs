using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prim.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class PrimTests
    {
        [TestMethod]
        public void TestPrimWithSingleEdge()
        {
            var graphEdges = new List<Edge>
            {
                new Edge(0, 1, 3)
            };

            var minimumSpanningForest = PrimAlgorithm.Prim(graphEdges.ToList());
            var totalWeight = minimumSpanningForest.Sum(edge => edge.Weight);

            var expectedTotalWeight = 3;
            Assert.AreEqual(expectedTotalWeight, totalWeight, "Weights should match.");
        }

        [TestMethod]
        public void TestPrimWithTwoConnectedEdges()
        {
            var graphEdges = new List<Edge>
            {
                new Edge(0, 1, 3),
                new Edge(2, 1, 4)
            };

            var minimumSpanningForest = PrimAlgorithm.Prim(graphEdges.ToList());
            var totalWeight = minimumSpanningForest.Sum(edge => edge.Weight);

            var expectedTotalWeight = 7;
            Assert.AreEqual(expectedTotalWeight, totalWeight, "Weights should match.");
        }

        [TestMethod]
        public void TestPrimWithTwoEdgesFormingForest()
        {
            var graphEdges = new List<Edge>
            {
                new Edge(0, 1, 3),
                new Edge(2, 3, 4)
            };

            var minimumSpanningForest = PrimAlgorithm.Prim(graphEdges.ToList());
            var totalWeight = minimumSpanningForest.Sum(edge => edge.Weight);

            var expectedTotalWeight = 7;
            Assert.AreEqual(expectedTotalWeight, totalWeight, "Weights should match.");
        }

        [TestMethod]
        public void TestPrimWith9VerticesAnd11Edges()
        {
            var graphEdges = new List<Edge>
            {
                new Edge(0, 3, 9),
                new Edge(0, 5, 4),
                new Edge(0, 8, 5),
                new Edge(1, 4, 8),
                new Edge(1, 7, 7),
                new Edge(2, 6, 12),
                new Edge(3, 5, 2),
                new Edge(3, 6, 8),
                new Edge(3, 8, 20),
                new Edge(4, 7, 10),
                new Edge(6, 8, 7)
            };

            var minimumSpanningForest = PrimAlgorithm.Prim(graphEdges.ToList());
            var totalWeight = minimumSpanningForest.Sum(edge => edge.Weight);

            var expectedTotalWeight = 45;
            Assert.AreEqual(expectedTotalWeight, totalWeight, "Weights should match.");
        }

        [TestMethod]
        public void TestPrimWith9VerticesAnd10Edges()
        {
            var graphEdges = new List<Edge>
            {
                new Edge(0, 3, 9),
                new Edge(0, 8, 5),
                new Edge(1, 4, 8),
                new Edge(1, 7, 7),
                new Edge(2, 6, 12),
                new Edge(3, 5, 2),
                new Edge(3, 6, 8),
                new Edge(3, 8, 20),
                new Edge(4, 7, 10),
                new Edge(6, 8, 7)
            };

            var minimumSpanningForest = PrimAlgorithm.Prim(graphEdges.ToList());
            var totalWeight = minimumSpanningForest.Sum(edge => edge.Weight);

            var expectedTotalWeight = 49;
            Assert.AreEqual(expectedTotalWeight, totalWeight, "Weights should match.");
        }
    }
}
