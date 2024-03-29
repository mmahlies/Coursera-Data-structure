﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5] { 7, 6, 4, 3, 1 };
            PiriortyQueue piriorty = new PiriortyQueue(array);
            piriorty.Insert(2);
            piriorty.Insert(5);

            int min = piriorty.ExtractMax();
            while (min != -1)
            {

                Console.WriteLine(min);
                min = piriorty.ExtractMax();                                                        
            }


            Console.Read();
        }
    }

   public class PiriortyQueue
    {
        int[] array;
        public int size;

        public PiriortyQueue()
        {
            this.array = new int[0];
        }
        public PiriortyQueue(int[] array)
        {
            this.array = array;
            size = array.Length;
            BuildArray();
        }

        /// <summary>
        ///  bottom up method for build heab from array
        /// </summary>
        private void BuildArray()
        {
            int midNode = (array.Length - 1) / 2;
            for (int i = midNode; i >= 0; i--)
            {
                SwiftDown(i);
            }
        }

        public void Insert(int i)
        {
            // resize array if needed
            if (array.Count() == size)
            {
                Array.Resize(ref array, size == 0 ? 2 : size * 2);
            }
                                                      

            // insert the new element
            array[size] = i;

            SwiftUp(size);

            // increase the size
            size++;
            
        }


       

        /// <summary>
        /// Get max piroity
        /// by get last leaf and put in the front of tree and call swiftDown
        /// </summary>
        /// <returns></returns>
        public int ExtractMax()
        {
            if (size != 0)
            {
                int max = array[0];
                array[0] = array[size - 1];
                // to do set           array[size - 1] = null
                SwiftDown(0);
                size--;
                return max;
            }
            return -1;
        }

        /// <summary>
        /// remove elment by maxing it bigger piriorty and the extract this elment after bubled up
        /// </summary>
        /// <param name="i"></param>
        public void RemoveElement(int i)
        {
            array[i] = int.MaxValue;
            SwiftUp(i);
            ExtractMax();
        }

        private void Swap(int v1, int v2)
        {
            int temp;
            temp = array[v1];
            array[v1] = array[v2];
            array[v2] = temp;
        }

        /// <summary>
        /// change pirioty of an element 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="p"></param>
        public void ChangePirorty(int i, int p)
        {
            int OldP = array[i];
            array[i] = p;
            if (p > OldP)
            {
                SwiftUp(i);
            }
            if (p < OldP)
            {
                SwiftDown(i);
            }


        }
        /// <summary> 
        /// return rightChild
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int RightChild(int i)
        {
            return (2 * i) + 2;
        }

        /// <summary>
        /// return leftChild
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int LeftChild(int i)
        {
            return (2 * i) + 1;
        }

        /// <summary>
        /// return parent index for 0 based array
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int Parent(int i)
        {
            return (i - 1) / 2;
        }



        /// <summary>
        /// used to make parent min node in it's subtree       
        /// </summary>
        /// <param name="i"></param>
        private void SwiftDown(int i)
        {
            int maxI = i;
            int left = LeftChild(i);
            int right = RightChild(i);
            if (left < size && array[left] > array[maxI])
            {
                maxI = left;
            }
            if (right < size && array[right] > array[maxI])
            {
                maxI = right;
            }
            if (maxI != i)
            {
                Swap(i, maxI);
                SwiftDown(maxI);
            }

        }

        /// <summary>
        /// used to ensure from this node is min one in thier tree by bubble up
        /// </summary>
        /// <param name="i"></param>
        private void SwiftUp(int i)
        {
            if (i < 1) return; // base case
            if (array[i] > array[Parent(i)])
            {
                Swap(i, Parent(i));
            }
            SwiftUp(Parent(i));
        }
    }
}
