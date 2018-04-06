using System.Collections.Generic;
using System.Linq;

namespace LabyrinthGeneration
{
    public class LabyrinthGeneration<T>
    {
        private readonly int[,] _adjacencyMatrix;
        private readonly Dictionary<int, T> _nodes = new Dictionary<int, T>();
        private int _edgeCount;

        public LabyrinthGeneration(IReadOnlyList<T> nodes)
        {
            _adjacencyMatrix = new int[nodes.Count, nodes.Count];
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < nodes.Count; j++)
                {
                    if (i != j)
                        _adjacencyMatrix[i, j] = 1;
                }
            }
            for (var i = 0; i < nodes.Count; i++)
            {
                _nodes.Add(i, nodes[i]);
            }
        }
        
        public LinkedList.LinkedList<T> Generate()
        {
            var visitedNodes = new LinkedList.LinkedList<T>();
            var visited = new HashSet<int>();
            
            DeepFirstSearch(0, visitedNodes, visited);
            
            return visitedNodes;
        }

        private void DeepFirstSearch(int nodeNumber, LinkedList.LinkedList<T> visitedNodes, HashSet<int> visited)
        {
            visited.Add(nodeNumber);
            visitedNodes.Insert(_nodes[nodeNumber]);
            var nextNode = GetRandomNode(visited);
            if (!visited.Contains(nextNode))
                DeepFirstSearch(nextNode, visitedNodes, visited);
        }
        
        
        
        private int GetRandomNode(HashSet<int> visited)
        {
            var range = Enumerable.Range(0, _nodes.Count).Where(i => !visited.Contains(i));
            var rand = new System.Random();
            var index = rand.Next(0, _nodes.Count - visited.Count);

            if (range.Any())
                return range.ElementAt(index);

            return 0;
        }
        
    }
}