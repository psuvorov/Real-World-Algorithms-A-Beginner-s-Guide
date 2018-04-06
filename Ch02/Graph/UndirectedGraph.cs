using System;
using System.Collections;
using System.Collections.Generic;
using Queue;
using Stack;

namespace Graph
{
    public class UndirectedGraph<T>
    {
        private readonly LinkedList.LinkedList<int>[] _vertices;
        private readonly Dictionary<int, T> _nodes = new Dictionary<int, T>();
        private int _edgeCount;

        public UndirectedGraph(IReadOnlyList<T> nodes)
        {
            _vertices = new LinkedList.LinkedList<int>[nodes.Count];
            for (var i = 0; i < _vertices.Length; i++)
            {
                _vertices[i] = new LinkedList.LinkedList<int>();
                _nodes.Add(i, nodes[i]);
            }
        }

        public T GetNode(int vertexNumber)
        {
            return _nodes[vertexNumber];
        }

        public void SetEdge(int nodeNumberA, int nodeNumberB)
        {
            _vertices[nodeNumberA].Insert(nodeNumberB);
            _vertices[nodeNumberB].Insert(nodeNumberA);
            _edgeCount++;
        }

        public IEnumerable<T> DeepFirstSearch()
        {
            var visitedNodes = new LinkedList.LinkedList<T>();
            var visited = new bool[_vertices.Length];

            DeepFirstSearch(0, visitedNodes, visited);

            return visitedNodes;
        }
        
        public IEnumerable<T> StackDeepFirstSearchWithDuplicates()
        {
            var visitedNodes = new LinkedList.LinkedList<T>();            

            StackDeepFirstSearchWithDuplicates(0, visitedNodes);

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
            var coloredNodes = new int[_vertices.Length];
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
            foreach (var v in _vertices[nodeNumber])
            {
                if (!visited[v])
                    DeepFirstSearch(v, visitedNodes, visited);
            }
        }
        
        private void StackDeepFirstSearchWithDuplicates(int nodeNumber, LinkedList.LinkedList<T> visitedNodes)
        {
            IStack<int> stack = new ArrayStack<int>(_nodes.Count);
            stack.Push(nodeNumber);
            bool[] visited = new bool[_vertices.Length];

            while (!stack.IsEmpty())
            {
                var n = stack.Pop();
                visited[n] = true;
                visitedNodes.Insert(_nodes[n]);
                foreach (var v in _vertices[n])
                {
                    if (!visited[v])
                        stack.Push(v);
                }
            }
        }
        
        // Нужен стек без дубликатов, в который добавляется лишь тот объект, которого еще нет в стеке.
        // Для этого нам понадобится дополнительный массив.
        // Элемент данного массива будет истинным, если такой элемент уже есть в стеке, и будет ложным, если его нет.
        private void StackDeepFirstSearch(int nodeNumber, LinkedList.LinkedList<T> visitedNodes)
        {
            IStack<int> stack = new ArrayStack<int>(_nodes.Count);
            bool[] visited = new bool[_vertices.Length];
            bool[] instack = new bool[_vertices.Length];
            
            stack.Push(nodeNumber);
            instack[nodeNumber] = true;
            
            while (!stack.IsEmpty())
            {
                var n = stack.Pop();
                visited[n] = true;
                instack[n] = false;
                visitedNodes.Insert(_nodes[n]);
                foreach (var v in _vertices[n])
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
            IQueue<int> queue = new ArrayQueue<int>(_vertices.Length);
            bool[] visited = new bool[_vertices.Length];
            bool[] inqueue = new bool[_vertices.Length];
            
            queue.Enqueue(0);
            inqueue[0] = true;

            while (!queue.IsEmpty())
            {
                int n = queue.Dequeue();
                visited[n] = true;
                inqueue[n] = false;
                visitedNodes.Insert(_nodes[n]);
                foreach (var v in _vertices[n])
                {
                    if (!visited[v] && !inqueue[v])
                    {
                        queue.Enqueue(v);
                        inqueue[v] = true;
                    }
                }
            }
        }

        private bool TraverseForBipartitionDeepFirstSearch(int currentNodeNumber, int[] coloredNodes)
        {
            foreach (var v in _vertices[currentNodeNumber])
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