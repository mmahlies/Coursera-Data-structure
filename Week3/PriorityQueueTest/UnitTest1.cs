using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityQueue;

namespace PriorityQueueTest
{
    [TestClass]
    public class TestPriorityQueue
    {
        [TestMethod]
        public void ShouldReturnMin()
        {
            int[] array = new int[10] { 7, 6, 4, 3, 1 ,10,2,9,8,5 };
            PiriortyQueue priority = new PiriortyQueue(array);

            //foreach (var item in array)
            //{
            //    priority.Insert(item);
            //}

            int max = priority.ExtractMax();
            Assert.AreEqual (max, 7);
        }

        [TestMethod]
        public void ShouldReturnAfterDelete()
        {
            int[] array = new int[5] { 7, 6, 4, 3, 1 };
            PiriortyQueue priority = new PiriortyQueue();
       

            foreach (var item in array)
            {
                priority.Insert(item);
            }

   
            Assert.AreEqual(7, priority.ExtractMax());           
            Assert.AreEqual(6, priority.ExtractMax());
            Assert.AreEqual(4, priority.ExtractMax());
            Assert.AreEqual(3, priority.ExtractMax());
            Assert.AreEqual(1, priority.ExtractMax());
           
        }
        [TestMethod]
        public void TestRemove()
        {
            int[] array = new int[5] { 7, 6, 4, 3, 1 };
            PiriortyQueue priority = new PiriortyQueue();


            foreach (var item in array)
            {
                priority.Insert(item);
            }
            priority.RemoveElement(6);
            priority.RemoveElement(4);
            Assert.AreEqual(7, priority.ExtractMax());
            Assert.AreEqual(3, priority.ExtractMax());
            Assert.AreEqual(1, priority.ExtractMax());

        }

        [TestMethod]
        public void ChangePriority()
        {
            int[] array = new int[5] { 7, 6, 4, 3, 1 };
            PiriortyQueue priority = new PiriortyQueue();


            foreach (var item in array)
            {
                priority.Insert(item);
            }
            priority.RemoveElement(6);
            priority.RemoveElement(4);
            priority.ChangePirorty(1, 10);
            Assert.AreEqual(10, priority.ExtractMax());
            Assert.AreEqual(7, priority.ExtractMax());
            Assert.AreEqual(1, priority.ExtractMax());

        }
    }
}
