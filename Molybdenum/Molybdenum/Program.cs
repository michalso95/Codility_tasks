using System;
using System.Collections.Generic;

namespace Molybdenum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { 2, 1, 3, 1, 2, 2, 3};
            int K = 3;
            int M = 5;
            int?[] output = Solution(K, M, A);
            foreach (int? obj in output)
            {
                if (obj == null)
                    continue;
                else
                    Console.Write(string.Format("{0} ", obj));
            }
        }

        static int?[] Solution(int K, int M, int[] A)
        {
            int[] modifyA = new int[A.Length];
            int? leader;
            List<int?> leaderList = new List<int?>();

            leader = GetLeader(M, A);
            leaderList.Add(leader);

            for (int i = 0; i < A.Length-K; i++)
            {
                for (int l=0; l<A.Length; l++)
                {
                    modifyA[l] = A[l];
                }
                for (int j = i; j < K+i; j++)
                {
                    modifyA[j] = modifyA[j] + 1;
                }
                leaderList.Add(GetLeader(M, modifyA));
            }
            return leaderList.ToArray();
        }

        static int? GetLeader(int M, int[] A)
        {
            int[,] count;
            int? leader = 0;

            count = GetArray(M, A);

            for (int i = 0; i < count.GetLength(0); i++)
            {
                if (count[i, 1] > A.Length / 2)
                {
                    leader = count[i, 0]; //leader
                }
            }
            if (leader == 0)
                return null;
            return leader;
        }

        static int[,] GetArray(int M, int[] A)
        {
            int[,] count = new int[M, 2];
            for (int i = 0; i < M; i++)
            {
                count[i, 0] = i;
            }

            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < count.GetLength(0); j++)
                {
                    if (A[i] == count[j, 0])
                        count[j, 1]++;
                }
            }
            return count;
        }
    }
}
