using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Disjontset_Naive;
using JointSet_NAive;

namespace joinset_NaiveTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            int[] x1 = new int[3] { 1, 2,3};
            int[] x2 = new int[3] { 4, 5, 6 };
            int[] x3 = new int[2] { 7, 8 };

            DisjointNaive disjointNaive = new DisjointNaive(9);
            disjointNaive.AddSet(x1);
            disjointNaive.AddSet(x2);
            disjointNaive.AddSet(x3);

            Assert.AreEqual(disjointNaive.Find(2), 1);
            Assert.AreEqual(disjointNaive.Find(6), 4);
            Assert.AreEqual(disjointNaive.Find(7), 7);

            disjointNaive.Union(7, 1);
            Assert.AreEqual(disjointNaive.Find(8), 1);
        }
        [TestMethod]
        public void TestEfficientDisjointSet()
        {

            int[] x1 = new int[3] { 1, 2, 3 };
            int[] x2 = new int[3] { 4, 5, 6 };
            int[] x3 = new int[2] { 7, 8 };

                EfficientDisjointSet effecientJointSet =new  EfficientDisjointSet(9);

            effecientJointSet.MakeSet(x1);
            effecientJointSet.MakeSet(x2);
            effecientJointSet.MakeSet(x3);


            effecientJointSet.Union(1, 2);
            effecientJointSet.Union(1, 3);

            effecientJointSet.Union(4, 5);
            effecientJointSet.Union(4, 6);

            effecientJointSet.Union(7, 8);

       
            effecientJointSet.Union(7, 1);
            Assert.AreEqual(effecientJointSet.Find(7), effecientJointSet.Find(1));
        }
    }
}
