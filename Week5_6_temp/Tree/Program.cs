using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(5);
            Tree.AVLInsert( 10, root);
            Tree.AVLInsert(11, root);
            Tree.AVLInsert(12, root);
            Tree.AVLInsert(13, root);

        }
    }
    abstract class Tree
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
                    GetRightAncestor(n.Parent);
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
            Node newNode = new Node(k);
            newNode.Parent = p;
            if (p.key > k)
            {
                p.LeftNode = newNode;
            }
            else
            {
                p.RightNode = newNode;
            }
        }

        /// <summary>
        ///  Delete node n and fill RepalanceNood
        /// </summary>
        /// <param name="n"></param>
        /// <param name="NodeNeedToRepalance"></param>
        public static void Delete(Node n, out Node NodeNeedToRepalance)
        {
            if (n.RightNode == null)
            {
                PromoteNode(n.LeftNode, n);
                NodeNeedToRepalance = n.Parent;
            }
            else
            {

                Node nextNode = Tree.Next(n);
                NodeNeedToRepalance = nextNode.Parent;
                // replace n by next node;
                nextNode.Parent = n.Parent;
                nextNode.LeftNode = n.LeftNode;
                nextNode.RightNode = n.RightNode;

                PromoteNode(nextNode, nextNode.RightNode);
            }
        }

        public static void AVLDelete(Node n)
        {
            Node NodeNeedToRepalance = null;
            Tree.Delete(n, out NodeNeedToRepalance);
            if (NodeNeedToRepalance != null)
            {
                Rebalance(NodeNeedToRepalance);
            }

        }

        /// <summary>
        ///  promote 
        /// </summary>
        /// <param name="leftNode"></param>
        /// <param name="n"></param>
        private static void PromoteNode(Node promotedNode, Node TargetNode)
        {
            if (TargetNode != null)
            {
                promotedNode.Parent = TargetNode.Parent;
            }
        }

        //public static void AdjustHeight(Node n)
        //{
        //    n.Height = 
        //}

        public static void AVLInsert(int k, Node r)
        {
            Insert(k, r);
            Node n = Find(k, r);
            Rebalance(n);
        }

        private static void Rebalance(Node n)
        {
            Node p = n.Parent;
            int leftNodeHeight = n.LeftNode == null ? 0 : n.LeftNode.Height;
            int rightNodeHeight = n.RightNode == null ? 0 : n.RightNode.Height;
            if (leftNodeHeight > rightNodeHeight + 1)
            {
                RebalanceRight(n);
            }
            if (leftNodeHeight +1  < rightNodeHeight )
            {
                RebalanceLeft(n);
            }
            if (p != null)
            {
                Rebalance(p);
            }
        }

        private static void RebalanceLeft(Node n)
        {
            Node rightNode = n.RightNode;
            int leftNodeHeight = rightNode.LeftNode == null ? 0 : rightNode.LeftNode.Height;
            int rightNodeHeight = rightNode.RightNode == null ? 0 : rightNode.RightNode.Height;
            if (leftNodeHeight > rightNodeHeight)
            {
                RotateRight(rightNode);
            }
            RotateLeft(n);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        private static void RebalanceRight(Node n)
        {
            Node leftNode = n.LeftNode;
            if (leftNode.LeftNode.Height < leftNode.RightNode.Height)
            {
                RotateLeft(leftNode);
            }
            RotateRight(n);
        }

        /// <summary>
        /// ///////////////////////(P)//////////////
        /// ///////////////////////(Y)/////////////
        /// //////////////////(A)///////(x)////////
        /// ///////////////////////////(B)//(C)////
        /// ///////////////////////////////////////
        /// </summary>
        /// <param name="y"></param>
        private static void RotateLeft(Node y)
        {
            Node P = y.Parent;
            Node x = y.RightNode; // right node of n
            Node b = x.LeftNode; // left  node of y

            x.Parent = P;
            if (P != null)
            {
                ReplaceChild(P, y, x);
            }
           

            y.Parent = x;
            x.LeftNode = y;

            y.RightNode = b;
            b.Parent = y;
        }
        /// <summary>
        /// ///////////////////////////////////////
        /// ///////////////////////(X)/////////////
        /// //////////////////(Y)///////(C)////////
        /// ///////////////(A)//(B)////////////////
        /// ///////////////////////////////////////
        /// </summary>
        /// <param name="y"></param>
        private static void RotateRight(Node x)
        {
            Node P = x.Parent;
            Node y = x.LeftNode; // left node of n
            Node b = y.RightNode; // right node of y
            y.Parent = P;
            ReplaceChild(P, x, y);

            b.Parent = x;
            x.LeftNode = b;

            y.RightNode = x;
            x.Parent = y;
        }

        /// <summary>
        /// replace child for the given node by node
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="oldNode"></param>
        /// <param name="NewNode"></param>
        private static void ReplaceChild(Node parentNode, Node oldNode, Node NewNode)
        {
            if (parentNode.LeftNode != null && parentNode.LeftNode == oldNode)
            {
                parentNode.LeftNode = NewNode;
            }
            else if (parentNode.RightNode != null && parentNode.RightNode == oldNode)
            {
                parentNode.RightNode = NewNode;
            }
        }

        /// <summary>
        /// assume all r1 nodes is smaller than r2 nodes
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <param name="t"></param>
        public static void Merge(Node r1, Node r2, Node t)
        {
            t.LeftNode = r1;
            r1.Parent = t;

            t.RightNode = r2;
            r2.Parent = t;

        }

        /// <summary>
        /// merge two tree with biggest node in first tree
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns></returns>
        public static Node Merge(Node r1, Node r2)
        {
            Node t =Tree.Find(int.MaxValue, r1);
            Tree.AVLDelete(t);
            Merge(r1, r2, t);
            return t;
        }

        public static Node AVLTreeMWR(Node r1, Node r2, Node t)
        {
            if (Math.Abs(r1.Height - r2.Height) <= 1)
            {
                Merge(r1, r2, t);
#warning need to adjust height if needed
                return t;
            }
            else if (r1.Height > r2.Height)
            {
                Node r3 = AVLTreeMWR(r1.RightNode, r2, t);
                r3.Parent = r1;
                Rebalance(r1);
                return r1;
            }
            else //if(r2.Height > r1.Height)
            {
                Node r3 = AVLTreeMWR(r1, r2.LeftNode, t);
                r3.Parent = r2;
                Rebalance(r2);
                return r2;
            }
        }

        public static KeyValuePair<Node,Node> Split(Node r, int x)
        {
            KeyValuePair<Node, Node> spilitedTree = new KeyValuePair<Node, Node>();
            if (r == null)
            {

                throw new Exception();
            }
            if (x < r.key)
            {
                spilitedTree = Split(r.LeftNode, x);
                Node r3 = AVLTreeMWR(spilitedTree.Value, r.RightNode, r);
                return new KeyValuePair<Node, Node>(spilitedTree.Key, r3);
            }
            else
            {
                spilitedTree = Split(r.RightNode, x);
                Node r3 = AVLTreeMWR(r.LeftNode, spilitedTree.Key, r);
                return new KeyValuePair<Node, Node>( r3, spilitedTree.Value);
            }
        }
    }

    class Node
    {
        public int key;
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public Node Parent { get; set; }
        private int height;

        public int Height
        {
            get
            {
                if (LeftNode == null && RightNode == null)
                {
                    return 1;
                }
                else
                {
                    return 1 + Math.Max((LeftNode == null) ? 0 : LeftNode.Height , (RightNode == null) ?  0 : RightNode.Height);
                }

            }
            set { height = value; }
        }

        public Node(int k)
        {
            this.key = k;
        }
    }
}
