using System.Collections.Generic;
using System.Linq;


namespace Quicksort_Algorigthm
{
    class QuickSort
    {
/*---------------------------------------------------------
* Method: QuickSortAlgo
* Description: Creates L, E, and G queues. In this case,
* the L queue will hold numbes smaller than the current 
* partition point, E will hold numbers equal to the partition
* point, and R will hold numbers greater to the partition point. 
* Calls each method in the class QuickSort
* -------------------------------------------------------*/
        public void QuickSortAlgo(ref Queue<int> S, int p)
        {
            if (S.Count > 1)
            {
                Queue<int> L = new Queue<int>();
                Queue<int> E = new Queue<int>();
                Queue<int> G = new Queue<int>();

                partition(S, p, ref L, ref E, ref G);
                QuickSortAlgo(ref L, findP(L));
                QuickSortAlgo(ref G, findP(G));

                S = mergeQueues(ref L, ref E, ref G);
            }
        }

/*---------------------------------------------------------
* Method: partition
* Description: Dequeues an element from the given queue
* and compares it to the partition point. Depending on the
* result, the number could be added to the L, E, or G queues.
* -------------------------------------------------------*/
        static void partition(Queue<int> S, int p, ref Queue<int> L, ref Queue<int> E, ref Queue<int> G)
        {
            while (S.Count != 0)
            {
                int y = S.Dequeue();
                if (y < p)
                {
                    L.Enqueue(y);
                }
                else if (y == p)
                {
                    E.Enqueue(y);
                }
                else
                    G.Enqueue(y);
            }
        }

/*---------------------------------------------------------
* Method: mergeQueues
* Description: Merges all queues into a new queue
* -------------------------------------------------------*/
        static Queue<int> mergeQueues(ref Queue<int> L, ref Queue<int> E, ref Queue<int> G)
        {
            Queue<int> newQ = new Queue<int>();
            while (L.Count > 0)
            {
                newQ.Enqueue(L.Dequeue());
            }
            while (E.Count > 0)
            {
                newQ.Enqueue(E.Dequeue());
            }
            while (G.Count > 0)
            {
                newQ.Enqueue(G.Dequeue());
            }
            return newQ;
        }

/*---------------------------------------------------------
* Method: findP
* Description: finds the parition point
* -------------------------------------------------------*/
        static int findP(Queue<int> S)
        {
            if (S.Count > 1)
            {
                int p = S.Last();
                return p;
            }
            else
                return 0;
        }
    }
}
