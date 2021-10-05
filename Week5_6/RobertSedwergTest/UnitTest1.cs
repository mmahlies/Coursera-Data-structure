using NUnit.Framework;
using TreeRobertSedwarg;

namespace RobertSedwergTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Tree tree = new Tree();
            tree.Put(5, 1);
            tree.Put(4, 1);
            tree.Put(6, 1);
            tree.Put(2, 1);

            Assert.AreEqual(tree.Get(2).Value,1) ;
            Assert.AreEqual(tree.Get(4).RankNo, 2);
        }

        [Test]
        public void Min()
        {
            Tree tree = new Tree();
            tree.Put(5, 1);
            tree.Put(4, 2);
            tree.Put(6, 3);
            tree.Put(2, 4);

            Assert.AreEqual(tree.Min(tree.Root).Key, 2);
            
        }

        [Test]
        public void Max()
        {
            Tree tree = new Tree();
            tree.Put(5, 1);
            tree.Put(4, 2);
            tree.Put(6, 3);
            tree.Put(2, 4);

            Assert.AreEqual(tree.Max(tree.Root).Key, 6);

        }



        [Test]
        public void Floor()
        {
            Tree tree = new Tree();
            tree.Put(5, 1);
            tree.Put(4, 2);
            tree.Put(6, 3);
            tree.Put(2, 4);

            Assert.AreEqual(tree.Floor(6).Key, 6);
            Assert.AreEqual(tree.Floor(3).Key, 2);

        }


        [Test]
        public void Ceiling()
        {
            Tree tree = new Tree();
            tree.Put(5, 1);
            tree.Put(4, 2);
            tree.Put(6, 3);
            tree.Put(2, 4);
            Assert.AreEqual(tree.Ceiling(6).Key, 6);
            Assert.AreEqual(tree.Ceiling(3).Key, 4);

        }

        [Test]
        public void Rank()
        {
            Tree tree = new Tree();
            tree.Put(5, 1);
            tree.Put(4, 2);
            tree.Put(6, 3);
            tree.Put(2, 4);
            Assert.AreEqual(tree.Rank(6), 3);
            Assert.AreEqual(tree.Rank(3), 1);

            Assert.AreEqual(tree.RankWithoutInternalFeild(6), 3);
            Assert.AreEqual(tree.RankWithoutInternalFeild(3), 1);


        }


        [Test]
        public void Select()
        {
            Tree tree = new Tree();
            tree.Put(5, 1);
            tree.Put(4, 2);
            tree.Put(6, 3);
            tree.Put(2, 4);
            Assert.AreEqual(tree.Select(2).Key, 5);
            Assert.AreEqual(tree.Select(3).Key, 6);

        }


        [Test]
        public void Keys()
        {
            Tree tree = new Tree();
            tree.Put(5, 1);
            tree.Put(4, 2);
            tree.Put(6, 3);
            tree.Put(2, 4);
            var q = tree.Keys();
            var n = q.Count;
                
                Assert.AreEqual(q.Dequeue().Key, 2);
                Assert.AreEqual(q.Dequeue().Key, 4);
                Assert.AreEqual(q.Dequeue().Key, 5);
                Assert.AreEqual(q.Dequeue().Key, 6);
            
            
            
            

        }
        [Test]
        public void RangeKeys()
        {
            Tree tree = new Tree();
            tree.Put(5, 1);
            tree.Put(4, 2);
            tree.Put(6, 3);
            tree.Put(2, 4);
            tree.Put(1, 4);
            tree.Put(7, 4);
            tree.Put(8, 4);


            var q = tree.Keys(4,7);
            var n = q.Count;

            Assert.AreEqual(q.Dequeue().Key, 4);
            Assert.AreEqual(q.Dequeue().Key, 5);
            Assert.AreEqual(q.Dequeue().Key, 6);
            Assert.AreEqual(q.Dequeue().Key, 7);
        }

        [Test]
        public void Delete ()
        {
            Tree tree = new Tree();
            tree.Put(5, 1);
            tree.Put(4, 2);
            tree.Put(6, 3);
            tree.Put(2, 4);
            tree.Put(1, 4);
            tree.Put(7, 4);
            tree.Put(8, 4);


            var q = tree.Keys();
            Assert.AreEqual(q.Count, 7);
            tree.Delete(7);
            tree.Delete(6);
            q = tree.Keys();
            Assert.AreEqual(q.Count, 5);

            tree.Delete(6);
            q = tree.Keys();
            Assert.AreEqual(q.Count, 5);

            tree.Delete(4);
            q = tree.Keys();
            Assert.AreEqual(q.Count, 4);

        }


        [Test]
        public void Hight()
        {
            Tree tree = new Tree();
            tree.Put(5, 1);
            Assert.AreEqual(tree.Height(), 1);

            tree.Put(4  , 2);
            Assert.AreEqual(tree.Height(), 2);
            tree.Put(6, 3);
            Assert.AreEqual(tree.Height(), 2);
            tree.Put(2, 4);                     
            Assert.AreEqual(tree.Height(), 3);

            tree.Put(3, 3);
            Assert.AreEqual(tree.Height(), 4);

            tree.Put(1, 1);
            Assert.AreEqual(tree.Height(), 4);

            Assert.AreEqual(tree.Root.HeightNo, 4);
        }

    }
}