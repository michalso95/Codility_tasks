using System;

namespace Technetium
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] A = new int[,] { { 9, 9, 7 }, { 9, 7, 2 }, { 6, 9, 5 }, { 9, 1, 2 } };

            Console.WriteLine(Solution(A));
        }

        static string Solution(int[,] A)
        {
            
            int rows = A.GetLength(0), cols = A.GetLength(1);
            int i = 0, j = 0;
            string output = A[0,0].ToString();

            while ((i<rows-1)||(j<cols-1))
            {
                if ((j <= cols - 2) && (i<= rows -2)) //if it's possible to move right and down
                {
                    if (A[i+1,j] > A[i, j + 1]) //go down
                    {
                        output += A[i + 1, j];
                        i++;
                    } 
                    else if (A[i, j+1] > A[i+1, j]) //go right
                    {
                        output += A[i, j+1];
                        j++;
                    } 
                    else if (A[i+1,j] == A[i,j+1]) //equal
                    {
                        if ((i < rows - 3) && (A[i+1,j]<A[i,j+1]))
                        {
                            output += A[i, j + 1];
                            j++;
                        } else
                        {
                            output += A[i+1, j];
                            i++;
                        }
                    }
                }
                else
                if ((i <= rows - 1) && (j<=cols-2)) //if it's possible to move only right  ((j < cols - 2) && (i<rows-1))
                {
                    output += A[i, j + 1];
                    j++;
                }
                else
                if ((j <= cols - 1)) //if it's possible to move only down   ((i < rows - 2) && (j<cols-1))
                {
                    output += A[i + 1, j];
                    i++;
                }
            }

            return output;
        }
    }
}
