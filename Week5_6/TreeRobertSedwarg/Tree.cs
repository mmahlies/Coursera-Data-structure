using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeRobertSedwarg
{
    public class Tree
    {
        public Node Root { get; set; }


        // u hsvr to run to phases 
        // 1- check the node exisit or not 
        //if exsist  => update node
        /*
         if not then in each step update size and height values in the correct side
         */

        public void PutItrative(int key, int value)
        {
            if (Root == null)
            {
                Root = new Node() { Key = key, Value = value };
                Root.RankNo = 0;
                Root.HeightNo = 1;
                return;
            }
            var rootInistance = Root;

            bool isExist = false;
            while (rootInistance != null)
            {
                if (rootInistance.Key > key)
                {
                    rootInistance = rootInistance.Left;
                }
                else if (rootInistance.Key < key)
                {
                    rootInistance = rootInistance.Right;
                }
                else
                {

                    rootInistance.Value = value;
                    isExist = true;
                }
            }


            if (!isExist)
            {
                rootInistance = Root;
                while (rootInistance != null)
                {
                    if (rootInistance.Key > key)
                    {
                        if (rootInistance.Left == null)
                        {
                            rootInistance = new Node() { Key = key, Value = value };
                            return;
                        }
                        else
                        {

                            rootInistance = rootInistance.Left;
                        }
                    }
                    else if (rootInistance.Key < key)
                    {
                        if (rootInistance.Right == null)
                        {
                            rootInistance = new Node() { Key = key, Value = value };
                            return;
                        }
                        else
                        {
                            rootInistance = rootInistance.Right;
                        }
                    }


                    rootInistance.RankNo = rootInistance.RankNo + 1;
                    rootInistance.HeightNo = rootInistance.HeightNo + 1;
                }
            }












        }

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
                root.Left = Put(root.Left, key, value);
            }
            else if (root.Key < key)
            {
                root.Right = Put(root.Right, key, value);
            }
            else
            {
                root.Value = value;
            }
            // to maintain the count of each node
            root.RankNo = Size(root.Left) + Size(root.Right) + 1;
            root.HeightNo = Math.Max(GetHeight(root.Left), GetHeight(root.Right)) + 1;
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
                return Get(root.Left, key);
            }
            else if (root.Key < key)
            {
                return Get(root.Right, key);
            }
            else
            {
                return root;
            }

        }


        public Node GetItrative(int key)
        {
            return GetItrative(Root, key);
        }

        private Node GetItrative(Node root, int key)
        {

            while (root != null)
            {
                if (root.Key > key)
                {
                    root = root.Left;
                }
                else if (root.Key < key)
                {
                    root = root.Right;
                }
                else
                {
                    return root;
                }
            }
            return null;

        }

        // to get the siiiiiiiiiiiiiize oif given node
        private int Size(Node node)
        {
            if (node == null)
                return 0;
            else
            {
                return node.RankNo;
            }
        }


        public Node Min(Node node)
        {
            if (node == null)
            {
                return node;
            }
            return node.Left == null ? node : Min(node.Left);
        }

        public Node MinItrative(Node node)
        {
            if (node == null)
            {
                return node;
            }

            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        public Node Max(Node node)
        {
            if (node == null)
            {
                return node;
            }
            return node.Right == null ? node : Max(node.Right);
        }

        public Node MaxItrative(Node node)
        {
            if (node == null)
            {
                return node;
            }

            while (node.Right != null)
            {
                node = node.Right;
            }

            return node;
        }


        public Node Floor(int key)
        {
            return Floor(Root, key);
        }
        // smalest key <= to the key
        private Node Floor(Node root, int key)
        {
            // case 1
            if (root == null || root.Key == key)
            {
                return root;
            }
            // case 2
            else if (root.Key < key)
            {
                // can be this root or the one one the right
                Node t = Floor(root.Right, key);
                if (t == null)
                {
                    return root;
                }
                else
                {
                    return t;
                }


            }
            // case 3
            else if (root.Key > key)
            {
                // go to left
                return Floor(root.Left, key);
            }

            throw new Exception("dead path");
        }

        // smalest key <= to the key
        public Node FloorItrative(int key)
        {

            Node floorNode = null;
            var inistanceRoot = Root;
            while (inistanceRoot != null)
            {
                // case 1
                if (inistanceRoot.Key == key)
                {
                    floorNode = inistanceRoot;
                    break;
                }

                else if (inistanceRoot.Key < key)
                {
                    // can be this root or the one one the right
                    // in all cases dont return from while loop 

                    floorNode = inistanceRoot;
                    inistanceRoot = inistanceRoot.Right;
                }
                // case 3
                else if (inistanceRoot.Key > key)
                {
                    // go to left
                    inistanceRoot = inistanceRoot.Left;
                }
            }
            return floorNode;
        }


        public Node Ceiling(int key)
        {
            return Ceiling(Root, key);
        }

        private Node Ceiling(Node root, int key)
        {
            // case 1
            if (root == null || root.Key == key)
            {
                return root;
            }
            // case 2
            else if (root.Key > key)
            {
                // can be this root or the one one the left
                Node t = Ceiling(root.Left, key);
                if (t == null)
                {
                    return root;
                }
                else
                {
                    return t;
                }


            }
            // case 3
            else if (root.Key < key)
            {
                // go to left
                return Floor(root.Right, key);
            }

            throw new Exception("dead path");
        }

        // how many keys before this key (
        public int Rank(int key)
        {
            return Rank(Root, key);
        }

        private int Rank(Node root, int key)
        {
            if (root == null)
                return 0;

            if (root.Key > key)
            {
                return Rank(root.Left, key);
            }
            else if (root.Key < key)
            {
                return 1 + Size(root.Left) + Rank(root.Right, key);
            }
            else
            {
                return Size(root.Left);
            }

        }
        // ex3.2.12
        public int RankWithoutInternalFeild(int key)
        {
            return RankWithoutInternalFeild(Root, key);
        }

        private int RankWithoutInternalFeild(Node root, int key)
        {
            if (root == null)
                return 0;

            if (root.Key > key)
            {
                return RankWithoutInternalFeild(root.Left, key);
            }
            else if (root.Key < key)
            {
                return 1 + RankWithoutInternalFeild(root.Left, key) + RankWithoutInternalFeild(root.Right, key);
            }
            else
            {
                return RankWithoutInternalFeild(root.Left, key);
            }

        }

        // Return Node containing key of rank k.
        // there are n element less than returned node
        public Node Select(int n)
        {
            return Select(Root, n);
        }

        private Node Select(Node root, int n)
        {
            if (root == null)
                return null;

            if (Rank(root.Key) > n)
            {
                return Select(root.Left, n);
            }
            else if (Rank(root.Key) < n)
            {
                var t = Select(root.Right, n);
                if (t == null)
                    return root;
                else
                    return t;

            }
            else // Rank(root.Key) ==  n
            {
                return root;
            }

        }


        public Queue<Node> Keys()
        {
            Queue<Node> q = new Queue<Node>();
            InOrder(Root, q);
            return q;
        }

        private void InOrder(Node root, Queue<Node> q)
        {
            if (root == null)
                return;
            InOrder(root.Left, q);
            q.Enqueue(root);
            InOrder(root.Right, q);


        }

        public Queue<Node> Keys(int lo, int hi)
        {
            Queue<Node> q = new Queue<Node>();
            InOrder(Root, q, lo, hi);
            return q;
        }

        private void InOrder(Node root, Queue<Node> q, int lo, int hi)
        {
            if (root == null)
                return;
            if (root.Left != null && root.Left.Key >= lo)
                InOrder(root.Left, q, lo, hi);


            if (root.Key >= lo && root.Key <= hi)
                q.Enqueue(root);

            if (root.Right != null && root.Right.Key <= hi)
                InOrder(root.Right, q, lo, hi);




        }

        public void Delete(int key)
        {
            Root = Delete(Root, key);
        }

        private Node Delete(Node root, int key)
        {
            if (root == null)
            {
                return root;
            }
            if (root.Key > key)
                root.Left = Delete(root.Left, key);
            else if (root.Key < key)
                root.Right = Delete(root.Right, key);
            else // root.key == key
            {

                // case 0,1 // 0child, one child
                if (root.Left == null) return root.Right;
                if (root.Right == null) return root.Left;

                // case 2 two child

                Node successsor = Min(root.Right);

                // delte min in the right
                root.Right = Delete(root.Right, successsor.Key);
                // relace target node with min one
                root.Key = successsor.Key;
                root.Value = successsor.Value;
            }


            // update x.count
            root.RankNo = 1 + Size(root.Left) + Size(root.Right);
            root.HeightNo = Math.Max(GetHeight(root.Left), GetHeight(root.Right)) + 1;
            return root;

        }


        private int GetHeight(Node node)
        {
            if (node == null)
                return 0;
            else
            {
                return node.HeightNo;
            }
        }
        // recersive to get hight in linerar time
        public int Height()
        {
            return Height(Root);
        }

        private int Height(Node root)
        {
            // base case
            if (root == null)
            {
                return 0;
            }

            return Math.Max(Height(root.Left), Height(root.Right)) + 1;
        }
    }



    public class Node
    {
        public int Key { get; set; }
        public int Value { get; set; }

        public Node Left { get; set; }
        public Node Right { get; set; }

        public int RankNo { get; set; }
        public int HeightNo { get; set; }

    }
}
