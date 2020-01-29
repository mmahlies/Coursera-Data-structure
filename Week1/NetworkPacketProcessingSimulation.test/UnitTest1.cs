using Microsoft.VisualStudio.TestTools.UnitTesting;
using Network_packet_processing_simulation;
using System.Collections.Generic;

namespace NetworkPacketProcessingSimulation.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SimulatePacketProcessing_1()
        {
            List<Packet> list = new List<Packet>();
            list.Add(new Packet(0, 0));

            List<int> expected = new List<int>();
            expected.Add(0);
            List<int> actual =    Program.NetworkProcessor(1, 1, list);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(actual[i], expected[i]);
            }
        }
        [TestMethod]
        public void SimulatePacketProcessing_2()
        {
            List<Packet> list = new List<Packet>();
            list.Add(new Packet(0, 1));
            list.Add(new Packet(0, 1));

            List<int> expected = new List<int>();
            expected.Add(0);
            expected.Add(-1);
            List<int> actual = Program.NetworkProcessor(1, 2, list);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual( expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void SimulatePacketProcessing_3()
        {
            List<Packet> list = new List<Packet>();
            list.Add(new Packet(0, 1));
            list.Add(new Packet(1, 1));

            List<int> expected = new List<int>();
            expected.Add(0);
            expected.Add(1);
            List<int> actual = Program.NetworkProcessor(1, 2, list);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(actual[i], expected[i]);
            }
        }
    }
}
