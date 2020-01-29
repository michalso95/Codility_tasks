using System;

namespace Zirconium
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { 5, 5, 5 };
            int[] B = new int[] { 5, 5, 5 };
            int F = 2;
            Console.WriteLine(Solution(A,B,F).ToString());
        }

        static int Solution(int[] A, int[] B, int F)
        {
            int[,] AB = new int[A.Length, B.Length];
            int sum = 0;
            int frontTeam = F;
            int backTeam = A.Length - F;
            for(int i=0; i < A.Length; i++)
            {
                AB[i, 0] = A[i];
                AB[i, 1] = B[i];
                AB[i, 2] = Math.Abs(A[i] - B[i]);
            }
            for(int i =0; i<A.Length; i++)
            {
                if (AB[i, 0] == AB[i, 1])
                {
                    sum += AB[i, 0];
                    backTeam--;
                } else
                if ((AB[i,0] > AB[i,1]) && (AB[i,2] <= AB[i, 0]) || ((frontTeam>0)&& (backTeam==0)))
                {
                    sum += AB[i, 0];
                    frontTeam--;
                }
                else if (backTeam > 0)
                {
                    sum += AB[i, 1];
                    backTeam--;
                } 
            }
            
            return sum;
        }
    }
}
