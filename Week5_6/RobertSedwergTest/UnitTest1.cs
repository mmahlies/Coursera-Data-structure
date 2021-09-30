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
            Assert.AreEqual(tree.Get(4).N, 2);
        }
    }
}