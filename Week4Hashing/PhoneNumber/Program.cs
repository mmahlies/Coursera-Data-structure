using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PhoneBook phoneBook = new PhoneBook(1, 5, 1000);
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                switch (input[0])
                {
                    case "add":
                        phoneBook.Add(int.Parse(input[1]), input[2]);
                        break;
                    case "find":
                        string result = phoneBook.Find(int.Parse(input[1]));
                        Console.WriteLine(result);
                        break;
                    case "del":
                     phoneBook.Delete(int.Parse(input[1]));
                        break;                    
                }
            }
        }


    }
    class PhoneBook
    {
        int a, b, m;
        List<KeyValuePair<int, string>>[] hashTable;
        public PhoneBook(int a, int b, int m)
        {
            this.a = a;
            this.b = b;
            this.m = m;
            hashTable = new List<KeyValuePair<int, string>>[m];
        }
        public  int GetHash(int number)
        {
            int p = 10000019;

            return ((a * number + b) % p) % m;
        }

        public void Add(int number, string name)
        {
            int h = GetHash(number);
            if (hashTable[h] == null)
            {
                hashTable[h] = new List<KeyValuePair<int, string>>();
            }
            else
            {
                int index = hashTable[h].FindIndex(w => w.Key == number);
                if (index != -1)
                {
                    hashTable[h][index]= new KeyValuePair<int, string>(number, name) ;
                    return;
                }
            }
            hashTable[h].Add(new KeyValuePair<int, string>(number, name));
        }

        public void Delete(int number)
        {
            int h = GetHash(number);
            if (hashTable[h] != null)
            {
                int index = hashTable[h].FindIndex(w => w.Key == number);
                if (index != -1)
                {
                    hashTable[h].RemoveAt(index);
                }
            }
        }

        public string Find(int number)
        {
            int h = GetHash(number);
            if (hashTable[h] != null)
            {
                int index = hashTable[h].FindIndex(w => w.Key == number);
                if (index != -1)
                {
                    return hashTable[h][index].Value;
                }
            }
            return "not found";
        }
    }
}
