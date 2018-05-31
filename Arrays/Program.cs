using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rotate Matrix;

            //int[,] matrix = new int[4,4] { { 1, 2,3,4}, { 5,6,7,8 },{ 9,10,11,12},{ 13,14,15,16} }; 

            //matrix=RotateMatrix(matrix);

            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++) {
            //        Console.Write(matrix[i,j].ToString()+"\t");
            //    }
            //    Console.WriteLine();
            //}

            //Sort Colors

            //char[] colors = new char[] { 'R','G','R','G','R','G'};
            //colors = SortColors(colors);

            //foreach (char ch in colors) {
            //    Console.WriteLine(ch.ToString());
            //}

            int[] arr = new int[] { 7, 10, 4, 3, 20, 15 };
            QuickSelectResult result = new QuickSelectResult();
            result.stop = false;

            Console.WriteLine(QuickSelect(arr, 0, arr.Length - 1, 3,result).number.ToString());

            Console.Read();
        }

        public static QuickSelectResult QuickSelect(int[] arr, int left, int right, int k,QuickSelectResult result)
        {
            if (left < right)
            {
                int pi = Partition(arr, left, right);

                if (pi + 1 == k)
                {
                    result = new QuickSelectResult();
                    result.stop = true;
                    result.number = arr[pi];
                }

                if(!result.stop)                
                    result=QuickSelect(arr, left, pi - 1, k,result);
                if (!result.stop)
                    result =QuickSelect(arr, pi + 1, right, k,result);                

                return result;
            }
            return result;
        }

        public static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left-1;

            for (int j = left; j <= right - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, (i + 1), right);
            return (i + 1);
        }

        public static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static int[,] RotateMatrix(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return matrix;

            int n = matrix.GetLength(0);
            int top = 0;

            for (int layer = 0; layer < n / 2; layer++) {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; i++) {
                    int offset = i - first;
                    top = matrix[first,i];
                    matrix[first, i] = matrix[last - offset, first];
                    matrix[last - offset, first] = matrix[last, last - offset];
                    matrix[last, last - offset] = matrix[i, last];
                    matrix[i, last] = top;
                }
            }

            return matrix;
        }

        public static char[] SortColors(char[] colors) {

            int i = 0;
            int j = colors.Length - 1;
            char temp;

            while (i < j)
            {
                if (colors[i] == 'G' && colors[j] == 'R')
                {
                    temp = colors[i];
                    colors[i] = colors[j];
                    colors[j] = temp;
                }
                if (colors[i] == 'R')
                    i++;
                if (colors[j] == 'G')
                    j--;
            }

            return colors;
        }
    }

    public class QuickSelectResult
    {
        public int number { get; set; }
        public bool stop { get; set; }
    }
}
