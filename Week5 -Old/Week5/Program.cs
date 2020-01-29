using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Tree
    {
        //public Node Root { get; set; }

        /// <summary>
        /// get node if exsist or the parent node of this element to append this node in the future
        ///  I think Find return Leafe
        /// </summary>
        /// <param name="k"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public static Node Find(int k, Node root)
        {
            if (root.key == k)
            {
                return root;
            }
            if (root.key > k)
            {
                if (root.LeftNode != null)
                {
                    return Find(k, root.LeftNode);
                }
            }
            if (root.key < k)
            {
                if (root.RightNode != null)
                {
                    return Find(k, root.RightNode);
                }
            }
            // case there are no child node
            return root;
        }


        /// <summary>
        /// get the next node
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Node Next(Node n)
        {
            if (n.RightNode != null)
            {
                // get last left in the right
                return GetLeftDecendant(n.RightNode);
            }
            else
            {
                return GetRightAncestor(n);
            }

        }
        /// <summary>
        ///  get the first parent bigger than me
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static Node GetRightAncestor(Node n)
        {
            if (n.Parent != null)
            {
              
                if (n.key > n.Parent.key)
                {
                    return GetRightAncestor(n.Parent);
                }
                else
                {
                    return n.Parent;
                }
            }
            return null;
        }

        /// <summary>
        /// get the most left decendant
        /// </summary>
        /// <param name="rightNode"></param>
        /// <returns></returns>
        private static Node GetLeftDecendant(Node n)
        {
            if (n.LeftNode != null)
            {
                return GetLeftDecendant(n.LeftNode);
            }
            return n;
        }

        public static List<Node> GetRange(int x, int y, Node root)
        {
            List<Node> resultList = new List<Node>();
            // find 
            Node n = Tree.Find(x, root);
            while (n != null && n.key < y)
            {
                n = Tree.Next(n);
                if (n.key < y)
                {
                    resultList.Add(n);
                }
                n = Tree.Next(n);
            }
            return resultList;
        }

        public static void Insert(int k, Node root)
        {
            Node p = Tree.Find(k, root);
            if (p.key > k)
            {
                p.LeftNode = new Node(k);
            }
            else
            {
                p.RightNode = new Node(k);
            }
        }
    }

    class Node
    {
        public int key;
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public Node Parent { get; set; }
        public Node(int k)
        {
            this.key = k;
        }
    }
}
