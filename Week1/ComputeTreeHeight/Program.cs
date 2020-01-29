using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputeTreeHeight
{
    class Program
    {
        /// <summary>
        /// The first line contains the number of nodes 𝑛. The second line contains 𝑛 integer numbers
        //  from −1 to 𝑛 − 1 — parents of nodes.If the 𝑖-th one of them(0 ≤ 𝑖 ≤ 𝑛 − 1) is −1, node 𝑖 is the root,
        //otherwise it’s 0-based index of the parent of 𝑖-th node.It is guaranteed that there is exactly one root.
        //It is guaranteed that the input represents a tree.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arrayInput = Console.ReadLine().Split(' ').Select(w => int.Parse(w)).ToArray();
            BST bST = new BST(arrayInput);

            int height = bST.GetHeight();
            Console.WriteLine(height);
        }
    }
    class Node
    {
        int value;
        List<Node> children = new List<Node>();
        public void AddChildren(int valuePr)
        {
            this.children.Add(new Node(valuePr));
        }
        public void AddChildren(Node nodeValue)
        {
            this.children.Add((nodeValue));
        }
        public Node(int valuePr)
        {
            this.value = valuePr;
        }
        public List<Node> GetChildren()
        {
            return this.children;
        }
    }

    class BST
    {
        Node root;
        Node[] nodes;
        public BST(int[] nodeArray)
        {
            nodes = new Node[nodeArray.Length];
            for (int child = 0; child < nodeArray.Length; child++)
            {
                int parent = nodeArray[child];

                if (nodes[child] == null)
                    nodes[child] = new Node(child);

                if (parent == -1)
                {
                    this.root = nodes[child];
                    nodes[child] = root;
                }
                else
                {
                    if (nodes[parent] == null)
                        nodes[parent] = new Node(parent);

                    nodes[parent].AddChildren(nodes[child]);
                }
            }
        }
        public int GetHeight()
        {
            Queue<Node> queue = new Queue<Node>();
            int height = 0;
            int nodeCount = 0;
            queue.Enqueue(this.root);
            while (true)
            {
                nodeCount = queue.Count;
                if (nodeCount == 0)
                {
                    break;
                }
                height++;
                while (nodeCount > 0)
                {
                    Node TempNode = queue.Dequeue();
                    List<Node> childrenTemp = TempNode.GetChildren();
                    foreach (Node child in childrenTemp)
                    {
                        queue.Enqueue(child);
                    }
                    nodeCount--;
                }
            }
            return height;
        }
    }
}
