using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Network_packet_processing_simulation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Packet> list = new List<Packet>();
            list.Add(new Packet(0, 0));

            List<int> result = new List<int>();

            result = NetworkProcessor(1, 1, list);
        }

        public static List<int> NetworkProcessor(int bufferSize, int noOfPacket, List<Packet> packets)
        {
            List<int> result = new List<int>();
            //   int[] arrayInput = Console.ReadLine().Split(' ').Select(w => int.Parse(w)).ToArray();
            // int bufferSize = arrayInput[0];
            //  int noOfPacket = arrayInput[1];
            int workingTime = 0;


            Queue<Packet> queue = new Queue<Packet>();
            for (int i = 0; i < packets.Count; i++)
            {
                Packet packet = packets[i];
                // remove procced packed
                while (queue.Count > 0 && packet.ArrivalTime >= queue.Peek().EndTime)
                {
                    queue.Dequeue();
                }


                // read packet data
                //int[] packetData = Console.ReadLine().Split(' ').Select(w => int.Parse(w)).ToArray();


                // condition for drop the packet
                if (bufferSize == queue.Count)
                {
                    //Console.WriteLine("-1");
                    result.Add(-1);
                    continue;
                }

                // store packet in buffer
                queue.Enqueue(packet);

                // see to process
                Packet currentPacket = queue.Peek();
                //workingTime += currentPacket.ArrivalTime;



                // in case of hold processor without work
                if (currentPacket.ArrivalTime > workingTime)
                {
                    workingTime = currentPacket.ArrivalTime;
                }
                //Console.WriteLine(workingTime);
                // set working time
                currentPacket.StartTime = workingTime;
                currentPacket.EndTime = currentPacket.StartTime + currentPacket.ProcessingTime;
                result.Add(workingTime);
                workingTime += currentPacket.ProcessingTime;
            }
            return result;
        }
    }
}



public class Packet
{
    public int ArrivalTime { get; set; }
    public int ProcessingTime { get; set; }
    public int StartTime { get; set; }
    public int EndTime { get; internal set; }

    public Packet(int arrivalTime, int processingTime)
    {
        this.ArrivalTime = arrivalTime;
        this.ProcessingTime = processingTime;

    }
}

