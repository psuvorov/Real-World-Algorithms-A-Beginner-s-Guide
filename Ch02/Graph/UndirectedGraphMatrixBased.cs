using System;
using System.Collections.Generic;
using Queue;
using Stack;

namespace Graph
{
    public class UndirectedGraphMatrixBased<T>
    {
        private readonly int[,] _adjacencyMatrix;
        private readonly Dictionary<int, T> _nodes = new Dictionary<int, T>();
        private int _edgeCount;
        
        public UndirectedGraphMatrixBased(IReadOnlyList<T> nodes)
        {
            _adjacencyMatrix = new int[nodes.Count, nodes.Count];
            for (var i = 0; i < nodes.Count; i++)
            {
                _nodes.Add(i, nodes[i]);
            }
        }

        public T GetNode(int vertexNumber)
        {
            return _nodes[vertexNumber];
        }

        public void SetEdge(int nodeNumberA, int nodeNumberB)
        {
            _adjacencyMatrix[nodeNumberA, nodeNumberB] = 1;
            _adjacencyMatrix[nodeNumberB, nodeNumberA] = 1;
            _edgeCount++;
        }

        public IEnumerable<T> DeepFirstSearch()
        {
            var visitedNodes = new LinkedList.LinkedList<T>();
            var visited = new bool[_nodes.Count];

            DeepFirstSearch(0, visitedNodes, visited);

            return visitedNodes;
        }

        public IEnumerable<T> StackDeepFirstSearch()
        {
            var visitedNodes = new LinkedList.LinkedList<T>();
            StackDeepFirstSearch(0, visitedNodes);

            return visitedNodes;
        }

        public IEnumerable<T> BreadthFirstSearch()
        {
            var visitedNodes = new LinkedList.LinkedList<T>();
            BreadthFirstSearch(visitedNodes);

            return visitedNodes;
        }

        public bool IsBipartiteDFS()
        {
            var coloredNodes = new int[_nodes.Count];
            coloredNodes[0] = 1;
            
            return TraverseForBipartitionDeepFirstSearch(0, coloredNodes);
        }
        
        public bool IsBipartiteBFS()
        {
            throw new NotImplementedException();
        }

        private void DeepFirstSearch(int nodeNumber, LinkedList.LinkedList<T> visitedNodes, bool[] visited)
        {
            visited[nodeNumber] = true;
            visitedNodes.Insert(_nodes[nodeNumber]);
            foreach (var v in GetAdjacentVertices(nodeNumber))
            {
                if (!visited[v])
                    DeepFirstSearch(v, visitedNodes, visited);
            }
        }

        private void StackDeepFirstSearch(int nodeNumber, LinkedList.LinkedList<T> visitedNodes)
        {
            IStack<int> stack = new ArrayStack<int>(_nodes.Count);
            bool[] visited = new bool[_nodes.Count];
            bool[] instack = new bool[_nodes.Count];
            
            stack.Push(nodeNumber);
            instack[nodeNumber] = true;

            while (!stack.IsEmpty())
            {
                var n = stack.Pop();
                visited[n] = true;
                instack[n] = false;
                visitedNodes.Insert(_nodes[n]);
                foreach (var v in GetAdjacentVertices(n))
                {
                    if (!visited[v] && !instack[v])
                    {
                        stack.Push(v);
                        instack[v] = true;
                    }
                }
            }
        }

        private void BreadthFirstSearch(LinkedList.LinkedList<T> visitedNodes)
        {
            IQueue<int> queue = new ArrayQueue<int>(_nodes.Count);
            bool[] visited = new bool[_nodes.Count];
            bool[] inqueue = new bool[_nodes.Count];
            
            queue.Enqueue(0);
            inqueue[0] = true;

            while (!queue.IsEmpty())
            {
                var n = queue.Dequeue();
                visited[n] = true;
                inqueue[n] = false;
                visitedNodes.Insert(_nodes[n]);

                foreach (var v in GetAdjacentVertices(n))
                {
                    if (!visited[v] && !inqueue[v])
                    {
                        queue.Enqueue(v);
                        inqueue[v] = true;
                    }
                }
            }
        }
        
        private IEnumerable<int> GetAdjacentVertices(int v)
        {
            int n = _nodes.Count;
            for (int i = 0; i < n; i++)
            {
                var vs = _adjacencyMatrix[v, i];
                if (vs == 1)
                    yield return i;
            }
        }
        
        private bool TraverseForBipartitionDeepFirstSearch(int currentNodeNumber, int[] coloredNodes)
        {
            foreach (var v in GetAdjacentVertices(currentNodeNumber))
            {
                if (coloredNodes[v] == 0) // вершина не помечена 
                {
                    coloredNodes[v] = coloredNodes[currentNodeNumber] == 1 ? 2 : 1;
                    return TraverseForBipartitionDeepFirstSearch(v, coloredNodes);
                }

                if (coloredNodes[v] == coloredNodes[currentNodeNumber])
                {
                    return false;
                }
            }
            
            return true;
        }

        
    }
}