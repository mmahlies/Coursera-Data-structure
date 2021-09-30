using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeRobertSedwarg
{
    public class Tree
    {
        public Node Root { get; set; }

        public void Put(int key, int value)
        {
            Root = Put(Root, key, value);
        }

        private Node Put(Node root, int key, int value)
        {
            if (root == null)
                root = new Node() { Key = key, Value = value };

            if (root.Key > key)
            {
             root.Left =    Put(root.Left, key, value);
            }
            else if (root.Key < key)
            {
             root.Rite =    Put(root.Rite, key, value);
            }
            else
            {
                root.Value = value;
            }
            root.N = Size(root.Left) + Size(root.Rite) + 1;
            return root;
        }

        public Node Get(int key)
        {
           return Get(Root, key);
        }

        private Node Get(Node root, int key)
        {
            if (root == null)
                return root;

            if (root.Key > key)
            {
               return Get    (root.Left, key);
            }
            else if (root.Key < key)
            {
                return Get(root.Rite, key);
            }
            else
            {
                return root;
            }
           
        }

        private int Size(Node node)
        {
            if (node == null)
                return 0;
            else
            {
                return node.N;
            }

        }
    }



    public class Node
    {
        public int Key { get; set; }
        public int Value { get; set; }

        public Node Left { get; set; }
        public Node Rite { get; set; }

        public int N { get; set; }
    }
}
