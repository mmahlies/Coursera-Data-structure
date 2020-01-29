using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashingwithchains
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            PhoneBook phoneBook = new PhoneBook(263, m);
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                switch (input[0])
                {
                    case "add":
                        phoneBook.Add(input[1]);
                        break;
                    case "find":
                        string result = phoneBook.Find(input[1]);
                        Console.WriteLine(result);
                        break;
                    case "del":
                        phoneBook.Delete((input[1]));
                        break;
                    case "check":
                       List<string> resultBucket = phoneBook.Check(int.Parse(input[1]));
                        if (resultBucket == null)
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            for (int j = resultBucket.Count-1; j >= 0 ; j--)                            
                            {
                                Console.Write(resultBucket[j] + " ");
                            }
                            Console.WriteLine();
                        }
                        break;
                }
            }
        }
    }
    class PhoneBook
    {
        int x, m;
        List<string>[] hashTable;
        public PhoneBook(int x, int m)
        {
            this.x = x;
            this.m = m;
            hashTable = new List<string>[m];
        }


        /// <summary>
        /// hash function 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetHash(string value)
        {
            int p = 1000000007;
            double hash = 0;
            for (int i = value.Length - 1; i >= 0 ;  i--)           
            {
                hash = (double)(hash * x  + (int)value[i] ) %p;
            }
            return (int)(hash  % m);
        }

        public void Add(string value)
        {
            int h = GetHash(value);
            if (hashTable[h] == null)
            {
                hashTable[h] = new List<string>();
            }
            else
            {
                int index = hashTable[h].FindIndex(w => w == value);
                if (index != -1)
                {
                    return;
                }
            }
            hashTable[h].Add(value);
        }

        public void Delete(string value)
        {
            int h = GetHash(value);
            if (hashTable[h] != null)
            {
                hashTable[h].Remove(value);
            }
        }

        public string Find(string value)
        {
            int h = GetHash(value);
            if (hashTable[h] != null)
            {
                bool exsitance = hashTable[h].Exists(w => w == value);
                if (exsitance)
                {
                    return "yes";
                }
            }
            return "no";
        }

        public List<string> Check(int i)
        {
            return hashTable[i];
        }
    }
}
