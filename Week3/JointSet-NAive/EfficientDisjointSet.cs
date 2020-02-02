using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JointSet_NAive
{
    public class EfficientDisjointSet
    {
        int[] parent;
        int[] rank;
        public EfficientDisjointSet(int n)
        {
            parent = new int[n];
            rank = new int[n];
        }

        public void MakeSet(int i)
        {
         
                parent[i] = i;
            // inital rank value
            rank[i] = 0;
         
        }

        public void MakeSet(int[] set)
        {
            for (int i = 0; i < set.Length; i++)
            {
                MakeSet(set[i]);
            }
        }

        public int Find(int id)
        {
            while (id != parent[id])
            {
                id = parent[id];
            }
            return id;
        }

        public void Union(int x, int y)
        {
            int xParent = Find(x);
            int yParent = Find(y);

            if (xParent == yParent)
            {
                return;
            }

            if (rank[xParent] > rank[yParent])
            {
                parent[yParent] = xParent;
            }
            if (rank[xParent] < rank[yParent])
            {
                parent[xParent] = yParent;
            }
            if (rank[xParent] == rank[yParent])
            {
                // put x under y
                parent[xParent] = yParent;
                rank[yParent]++;

            }
           
        }

    }
}
