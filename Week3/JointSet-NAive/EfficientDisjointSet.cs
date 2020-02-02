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
        public EfficientDisjointSet(int n)
        {
                   parent = new int[n];
        }

        public void MakeSet(int[] set)
        {
            // take first element of set
            int firstEl = set[0];

            for (int i = 0; i < set.Length; i++)
            {
                parent[set[i]] = firstEl;
            }
        }

        public int Find(int id)
        {            
            while (id != parent[id]){
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
            // convert all yParent to xParent
            for (int i = 0; i < parent.Length; i++)
            {
                if (parent[i] == yParent)
                {
                    parent[i] = xParent;
                }
            }
        }

    }
}
