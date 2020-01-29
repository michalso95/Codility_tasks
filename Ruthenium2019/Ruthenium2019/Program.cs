using System;


namespace Ruthenium2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[7] { 1, 1, 3, 1, 1, 1, 4 } ;
            int K = 2;
            Console.WriteLine(Solution(A, K));
        }

        static int Solution(int[] a, int k)
        {
            int maxrow = 1;
            for (int i = 0; i < a.Length-1; i++)
            {
                int row = 0;
                int maxdist = 1;
                int kk = k;
                for (int j = i; j< a.Length; j++)
                {
                    if ((((a[i] == a[j]) && (Math.Abs(j-i)<maxdist))) || (kk>0))
                    {
                        row++;
                        maxdist++;
                        if (a[i]!=a[j])
                            kk--;
                        if (row > maxrow)
                            maxrow = row;
                    }
                }
            }
            return maxrow;
        }
    }
}
