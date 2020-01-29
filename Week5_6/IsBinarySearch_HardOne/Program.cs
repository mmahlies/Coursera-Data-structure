using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBinarySearch_HardOne
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Tree tree = new Tree(n);
            for (int i = 0; i < n; i++)
            {
                int[] nodeData = Console.ReadLine().Split(' ').Select(w => int.Parse(w)).ToArray();
                tree.Insert(nodeData, i);
            }
            tree.IsBinarySearchTree();
            if (tree.IsBinarySearchTree())
            {
                Console.WriteLine("CORRECT");
            }
            else
            {
                Console.WriteLine("INCORRECT");
            }

        }
    }
    class Tree
    {
        Node[] array;
        Stack<Node> stack;
        long previousValue;
        bool IsBST;
        public Tree(int n)
        {
            array = new Node[n];
            IsBST = true;
            stack = new Stack<Node>();
            previousValue = long.MinValue;
        }
        internal void Insert(int[] nodeData, int i)
        {

            array[i] = new Node(nodeData[0]);
            array[i].LeftNodeIndex = nodeData[1];

            array[i].RightNodeIndex = nodeData[2];

        }
        public bool IsBinarySearchTree()
        {
            if (array.Count() == 0)
                return IsBST;
            stack.Push(array[0]);
            while (stack.Count != 0)
            {
                if (stack.Peek().LeftNodeIndex != -1 && array[stack.Peek().LeftNodeIndex].IsPrinted == false)
                {
                    stack.Push(array[stack.Peek().LeftNodeIndex]);
                }
                else if (stack.Peek().IsPrinted == false)
                {
                    //Console.Write(stack.Peek().key + " ");
                    if (previousValue > stack.Peek().key || 
                        (stack.Peek().LeftNodeIndex != -1 && array[stack.Peek().LeftNodeIndex].key == stack.Peek().key))
                    {
                        IsBST = false;
                        return IsBST;
                    }
                    previousValue = stack.Peek().key;
                    stack.Peek().IsPrinted = true;
                }
                else if (stack.Peek().RightNodeIndex != -1 && array[stack.Peek().RightNodeIndex].IsPrinted == false)
                {
                    stack.Push(array[stack.Peek().RightNodeIndex]);
                }
                else
                {
                    stack.Pop();
                }
            }
            return IsBST;
        }

    }

    class Node
    {
        public long key;
        public int LeftNodeIndex { get; set; }
        public int RightNodeIndex { get; set; }

        public bool IsPrinted;

        public Node(int k)
        {
            this.key = k;
        }
    }
}
