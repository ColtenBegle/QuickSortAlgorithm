using System;
using System.Collections.Generic;
using System.Linq;


namespace Quicksort_Algorigthm
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            char[] responses = new char[] { 'Y', 'y', 'N', 'n' };
            char cont = responses[0];
            while (cont == responses[0] || cont == responses[1])
            {
                Console.Write("How many numbers do you want to sort: ");
                string ans = Console.ReadLine();
                bool ansCheck = int.TryParse(ans, out int value);
                if (value == 0 || ansCheck == false)
                {
                    Console.WriteLine("Invalid amount.");
                }
                else
                {
                    Queue<int> quickQueue = new Queue<int>();
                    QuickSort oldSort = new QuickSort();
                    for (int i = 0; i < value; i++)
                    {
                        quickQueue.Enqueue(rand.Next(0, 1000));
                    }
                    Console.Write("Unsorted:");
                    printQueueu(quickQueue);

                    Console.WriteLine("\n");

                    QuickSort newSort = new QuickSort();
                    newSort.QuickSortAlgo(ref quickQueue, quickQueue.Last());
                    Console.Write("Sorted: ");
                    printQueueu(quickQueue);
                    Console.WriteLine();
                }
                Console.Write("Would you like to sort again (Y/N): ");
                string returned = Console.ReadLine();
                while (Char.TryParse(returned, out char result) == false || inResponses(responses, result) == false)
                {
                    Console.Write("Incorrect input! Enter Y/N: ");
                    returned = Console.ReadLine();
                }
                Char.TryParse(returned, out char newAns);
                cont = newAns;
                Console.WriteLine();
            }
        }

        static bool inResponses(char[] responses, char input)
        {
            bool test = responses.Contains(input);
            return test;
        }

        static void printQueueu(Queue<int> S)
        {
            foreach (Object obj in S)
            {
                Console.Write("|{0}|", obj);
            }
        }
    }
}
