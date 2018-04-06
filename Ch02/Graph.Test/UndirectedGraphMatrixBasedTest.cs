using System;
using System.Collections.Generic;
using NUnit.Framework;
using Graph;

namespace Graph.Test
{
    [TestFixture]
    public class UndirectedGraphMatrixBasedTest
    {
        [Test]
        public void DeepFirstSearch_ValidParamsPassed_Success()
        {
            string[] nodes = new[] {"0", "1", "2", "3", "4", "5", "6", "7"};
            UndirectedGraphMatrixBased<string> graph = new UndirectedGraphMatrixBased<string>(nodes);
            
            graph.SetEdge(0, 1);
            graph.SetEdge(0, 2);
            graph.SetEdge(0, 3);
            
            graph.SetEdge(1, 4);
            
            graph.SetEdge(3, 5);
            
            graph.SetEdge(4, 5);
            
            graph.SetEdge(5, 6);
            graph.SetEdge(5, 7);
            
            var visitedNodes = graph.DeepFirstSearch();
            Assert.That(visitedNodes, Is.EquivalentTo(new string[] {"0", "1", "4", "5", "3", "6", "7", "2"}));
        }
        
        [Test]
        public void StackDeepFirstSearch_ValidParamsPassed_Success()
        {
            string[] nodes = new[] {"0", "1", "2", "3", "4", "5", "6", "7"};
            UndirectedGraphMatrixBased<string> graph = new UndirectedGraphMatrixBased<string>(nodes);
            
            graph.SetEdge(0, 1);
            graph.SetEdge(0, 2);
            graph.SetEdge(0, 3);
            
            graph.SetEdge(1, 4);
            
            graph.SetEdge(3, 5);
            
            graph.SetEdge(4, 5);
            
            graph.SetEdge(5, 6);
            graph.SetEdge(5, 7);
            
            var visitedNodes = graph.StackDeepFirstSearch();
            Assert.That(visitedNodes, Is.EquivalentTo(new string[] {"0", "3", "5", "7", "6", "4", "2", "1"}));
        }
        
        [Test]
        public void BreadthFirstSearch_ValidParamsPassed_Success()
        {
            string[] nodes = new[] {"0", "1", "2", "3", "4", "5", "6", "7"};
            UndirectedGraphMatrixBased<string> graph = new UndirectedGraphMatrixBased<string>(nodes);
            
            graph.SetEdge(0, 1);
            graph.SetEdge(0, 2);
            graph.SetEdge(0, 3);
            
            graph.SetEdge(1, 4);
            
            graph.SetEdge(3, 5);
            
            graph.SetEdge(4, 5);
            
            graph.SetEdge(5, 6);
            graph.SetEdge(5, 7);

            var visitedNodes = graph.BreadthFirstSearch();
            Assert.That(visitedNodes, Is.EquivalentTo(new string[] {"0", "1", "2", "3", "4", "5", "6", "7"}));
        }
        
        [Test]
        public void IsBipartiteDFS_BipartiteGraph_Success()
        {
            UndirectedGraphMatrixBased<string> graph = new UndirectedGraphMatrixBased<string>(new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I"});
            graph.SetEdge(0, 1);
            
            graph.SetEdge(1, 2);
            graph.SetEdge(1, 8);
            
            graph.SetEdge(2, 3);
            
            graph.SetEdge(3, 6);
            
            graph.SetEdge(4, 5);
            graph.SetEdge(4, 7);
            
            graph.SetEdge(7, 8);
            
            var r = graph.IsBipartiteDFS();
            Assert.IsTrue(r);
        }
        
        [Test]
        public void IsBipartiteDFS_NotBipartiteGraph_Failure()
        {
            UndirectedGraphMatrixBased<string> graph = new UndirectedGraphMatrixBased<string>(new string[] {"A", "B", "C", "D"});
            graph.SetEdge(0, 1);
            graph.SetEdge(1, 2);
            graph.SetEdge(2, 3);
            graph.SetEdge(1, 3);
            
            var r = graph.IsBipartiteDFS();
            Assert.IsFalse(r);
        }
    }
}