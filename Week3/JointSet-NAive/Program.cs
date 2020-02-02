using JointSet_NAive;
using System;
using System.Collections;
namespace Disjontset_Naive
{
    class Program
    {                 /// <summary>
    /// find take o(1)
    /// union O(n)
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] x1 = new int[3] { 1, 2, 3 };
            int[] x2 = new int[3] { 4, 5, 6 };
            int[] x3 = new int[2] { 7, 8 };

            DisjointNaive disjointNaive = new DisjointNaive(8);
            disjointNaive.AddSet(x1);
            disjointNaive.AddSet(x2);
            disjointNaive.AddSet(x3);
        }
    }

  
}
