using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JointSet_NAive
{
    public class DisjointNaive
    {
        public int[] SmallestIds { get; set; }
        public DisjointNaive(int arrayLength)
        {
            this.SmallestIds = new int[arrayLength];
        }

        public void AddSet(int[] set)
        {
            Array.Sort(set);
            // get min element
            int min = set[0];

            for (int i = 0; i < set.Length; i++)
            {
                SmallestIds[set[i]] = min;
            }
        }

        public int Find(int id)
        {
            return SmallestIds[id];
        }


        public void Union(int x, int y)
        {
            int xId = Find(x);
            int yId = Find(y);

            if (xId == yId)
            {
                return;
            }

            int minID = Math.Min(xId, yId);
            // union all 
            for (int i = 0; i < SmallestIds.Length; i++)
            {
                if (SmallestIds[i] == xId || SmallestIds[i] == yId)
                {
                    SmallestIds[i] = minID;
                }
            }
        }
    }
}
