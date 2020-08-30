/* Programmer: Colten Begle     Date: 8/30/2020
 * Description: This program sorts a random amount of numbers 
 * using a QuickSort algorithm. The user enters an amount of 
 * numbers to be sorted. The user enters the amount of numbers to
 * be sorted. Then, the program sorts the numbers, displays the sorted 
 * queue, and displays the execution time of the algorithm
 */
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
            char[] responses = new char[] { 'Y', 'y', 'N', 'n' }; //Allowed responses
            char cont = responses[0];
            while (cont == responses[0] || cont == responses[1]) //If user enters 'Y' or 'y'
            {
                //Getting and validating user response for amount of numbers
                Console.Write("How many numbers do you want to sort: ");
                string ans = Console.ReadLine();
                bool ansCheck = int.TryParse(ans, out int value);
                if (value == 0 || ansCheck == false)
                {
                    Console.WriteLine("Invalid amount.");
                }
                else
                {
                    //Generate unsorted queue
                    Queue<int> quickQueue = new Queue<int>();
                    for (int i = 0; i < value; i++)
                    {
                        quickQueue.Enqueue(rand.Next(0, 1000));
                    }
                    //Print unsorted queue
                    Console.Write("Unsorted:");
                    printQueueu(quickQueue);

                    Console.WriteLine("\n");

                    //Generate sorted queue
                    QuickSort newSort = new QuickSort();
                    int start = DateTime.Now.Millisecond; //Start time

                    newSort.QuickSortAlgo(ref quickQueue, quickQueue.Last());

                    int end = DateTime.Now.Millisecond; //End time
                    int executionTime = end - start; //Execution time

                    //Print sorted queue
                    Console.Write("Sorted: ");
                    printQueueu(quickQueue);

                    Console.WriteLine();
                    Console.WriteLine("Execution time: {0}", executionTime);
                    Console.WriteLine();
                }
                //Getting and validating user input
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

/*---------------------------------------------------------
* Method: inResponses
* Description: Checks to see if the user's response is in 
* the given char array
* -------------------------------------------------------*/
        static bool inResponses(char[] responses, char input)
        {
            bool test = responses.Contains(input);
            return test;
        }

/*---------------------------------------------------------
 * Method: printQueue
 * Description: Prints all objects in a given queue
 * -------------------------------------------------------*/
        static void printQueueu(Queue<int> S)
        {
            foreach (Object obj in S)
            {
                Console.Write("|{0}|", obj);
            }
        }
    }
}
