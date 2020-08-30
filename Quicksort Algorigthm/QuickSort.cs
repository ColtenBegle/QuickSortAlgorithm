using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort_Algorigthm
{
    class QuickSort
    {
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
