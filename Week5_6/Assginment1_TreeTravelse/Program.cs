using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assginment1_TreeTravelse
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
            tree.TravelsInOrder();
            Console.WriteLine();
            tree.ResetTravelse();
            tree.TravelsPreOrder();
            Console.WriteLine();
            tree.ResetTravelse();
            tree.TravelsePostOrder();
 
        }
    }
    class Tree
    {
        Node[] array;
        Stack<Node> stack;

        public Tree(int n)
        {
            array = new Node[n];

            stack = new Stack<Node>();
        }
        internal void Insert(int[] nodeData, int i)
        {

            array[i] = new Node(nodeData[0]);
            array[i].LeftNodeIndex = nodeData[1];

            array[i].RightNodeIndex = nodeData[2];

        }
        public void TravelsInOrder()
        {
            stack.Push(array[0]);
            while (stack.Count != 0)
            {
                if (stack.Peek().LeftNodeIndex != -1 && array[stack.Peek().LeftNodeIndex].IsPrinted == false)
                {
                    stack.Push(array[stack.Peek().LeftNodeIndex]);
                }
                else if (stack.Peek().IsPrinted == false)
                {
                    Console.Write(stack.Peek().key + " ");
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
        }
        public void TravelsPreOrder()
        {
            stack.Push(array[0]);
            while (stack.Count != 0)
            {
                if (stack.Peek().IsPrinted == false)
                {
                    Console.Write(stack.Peek().key + " ");
                    stack.Peek().IsPrinted = true;
                }
                else if (stack.Peek().LeftNodeIndex != -1 && array[stack.Peek().LeftNodeIndex].IsPrinted == false)
                {
                    stack.Push(array[stack.Peek().LeftNodeIndex]);
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
        }

        internal void ResetTravelse()
        {
            foreach (var item in array)
            {
                item.IsPrinted = false;
            }
        }

        internal void TravelsePostOrder()
        {
            stack.Push(array[0]);
            while (stack.Count != 0)
            {
                if (stack.Peek().LeftNodeIndex != -1 && array[stack.Peek().LeftNodeIndex].IsPrinted == false)
                {
                    stack.Push(array[stack.Peek().LeftNodeIndex]);
                }
                else if (stack.Peek().RightNodeIndex != -1 && array[stack.Peek().RightNodeIndex].IsPrinted == false)
                {
                    stack.Push(array[stack.Peek().RightNodeIndex]);
                }
                else if (stack.Peek().IsPrinted == false)
                {
                    Console.Write(stack.Peek().key + " ");
                    stack.Peek().IsPrinted = true;
                }
                else
                {
                    stack.Pop();
                }
            }
        }
    }

    class Node
    {
        public int key;
        public int LeftNodeIndex { get; set; }
        public int RightNodeIndex { get; set; }

        public bool IsPrinted;

        public Node(int k)
        {
            this.key = k;
        }
    }
}
