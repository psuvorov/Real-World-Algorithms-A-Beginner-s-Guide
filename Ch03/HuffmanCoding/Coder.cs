using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PriorityQueue;

namespace HuffmanCoding
{
    // Coder data types 
    internal abstract class TreeNode
    {
        internal readonly int Count;
        internal string Code;

        protected TreeNode(int count)
        {
            Count = count;
        }

        protected internal virtual void CreateCode(string code)
        {
            Code = code;
        }
    }

    internal class InnerTreeNode : TreeNode
    {
        private readonly TreeNode _left;
        private readonly TreeNode _right;

        public InnerTreeNode(TreeNode left, TreeNode right) : base(left.Count + right.Count)
        {
            _left = left;
            _right = right;
        }

        protected internal override void CreateCode(string code)
        {
            base.CreateCode(code);
            _left.CreateCode(code + "0");
            _right.CreateCode(code + "1");
        }
    }

    internal class LeafTreeNode : TreeNode
    {
        public LeafTreeNode(int count) : base(count)
        {
        }
    }
    
    
    
    
    
    
    public static class Coder
    {
        private static readonly Dictionary<char, TreeNode> CharToNodes = new Dictionary<char, TreeNode>();
        
        public static string Perform(string text)
        {
            var chars = text.ToCharArray();

            // Gathering alphabet frequency
            var alphabetFrequency = new Dictionary<char, int>();
            foreach (var c in chars) // First pass through the char array
            {
                if (!alphabetFrequency.ContainsKey(c))
                    alphabetFrequency.Add(c, 1);
                else
                    alphabetFrequency[c] = alphabetFrequency[c] + 1; 
            }
            
            // Create binary heap
            var priorityQueue = new BinaryHeapPriorityQueue<TreeNode>(alphabetFrequency.Count, (i1, i2) => i2.Count.CompareTo(i1.Count));
            
            
             

            foreach (var entry in alphabetFrequency)
            {
                var leafNode = new LeafTreeNode(entry.Value);
                CharToNodes.Add(entry.Key, leafNode);
                priorityQueue.Insert(leafNode); // Initially PQ contains only leaf nodes  
            }

            // Main part of the algorithm
            while (priorityQueue.GetSize() > 1)
            {
                var n1 = priorityQueue.Extract();
                var n2 = priorityQueue.Extract();
                
                var innerNode = new InnerTreeNode(n1, n2); // Creates a new node with sum of frequencies...  
                
                priorityQueue.Insert(innerNode); // ...and put it back
            } // Repeat the procedure untill PQ has only one element 

            var root = priorityQueue.Extract(); // Take the last element (root) from the PQ 
            root.CreateCode(alphabetFrequency.Count == 1 ? "0" : ""); // Build codes for the whole hierarchy

            var sb = new StringBuilder();
            foreach (var t in chars) // Second pass through the char array
            {
                var c = CharToNodes[t].Code;
                sb.Append(c);
            }

            return sb.ToString();
        }

        public static Dictionary<char, string> GetCodingTable()
        {
            var res = new Dictionary<char, string>();

            foreach (var item in CharToNodes)
            {
                res.Add(item.Key, item.Value.Code);
            }

            return res;
        }
    }
}