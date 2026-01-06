using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace day36_1_2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           
            //Section 1: Multidimensional Arrays
            //Task 1
            int[,] array =  new int[3, 3];
            Console.WriteLine("add 9 values");
            //int array_value = Convert.ToInt32(Console.Readline());
            for (int i = 0; i < array.GetLength(0); i++) // the row
            {
                for (int j = 0; j < array.GetLength(1); j++) // the column
                {
                    array[i, j]=Convert.ToInt32(Console.ReadLine());
                    Console.Write( array[i, j] , "\t");
                }
                
            }
            Console.WriteLine();

            //Task 2 
            int[,] array = new int[4, 4]
            {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 16 }
             };

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int rowSum = 0;
                for (int j = 0; j < array.GetLength(1) ; j++)
                {
                    rowSum += array[i, j];
                }
                Console.WriteLine($"Row {i + 1} sum = {rowSum}");
            }
            for (int j = 0; j < array.GetLength(1); j++)
            {
                int colSum = 0;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    colSum += array[i, j];
                }
                Console.WriteLine($"Column {j + 1} sum = {colSum}");
            }

            //Task 3
           
            int[,] array = new int[5, 5];
            Random rand = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int maxRow = array[i, 0];
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > maxRow)
                        maxRow = array[i, j];
                }
                Console.WriteLine($"Row {i + 1}: {maxRow}");
            }
           
            for (int j = 0; j < array.GetLength(1); j++)
            {
                int minCol = array[0, j];
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (array[i, j] < minCol)
                        minCol = array[i, j];
                }
                Console.WriteLine($"Column {j + 1}: {minCol}");
            }


            
            for (int i = 0; i < array.GetLength(0); i++) // rows
            {
                for (int j = 0; j < array.GetLength(1); j++) // columns
                {
                    array[i, j] = rand.Next(1, 51); 
                }
            }


            // ===== 2. Jagged Array =====

            //Section 2: Jagged Arrays
            //Task 4 :
            //int[][] jagged = new int[3][];

            //    jagged[0] = new int[2]; // Row 1: 2 elements
            //    jagged[1] = new int[3]; // Row 2: 3 elements
            //    jagged[2] = new int[4]; // Row 3: 4 elements


            //foreach (int i = 0 ; i < jagged.Length; i++)
            //{
            //    for (int j = 0; j < jagged[i].Length; j++)
            //    {
            //        Console.Write($"Enter element for row {i}, col {j}: ");
            //        jagged[i][j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}
            //Console.WriteLine("\nJagged Array:");
            //foreach (int[] row in jagged)
            //{
            //    foreach (int num in row)
            //    {
            //        Console.Write(num + " ");
            //    }
            //    Console.WriteLine();
            //}


            //Task 5 :
            Console.WriteLine("enter the number of rows u wanted :")
            int row= Convert.ToInt32(Console.ReadLine());
            // Step 2: Create jagged array with that many rows
            int[][] jagged = new int[row][];

            // Step 3: Fill each row
            for (int i = 0; i < row; i++)
            {
                Console.Write($"Enter number of elements for row {i}: ");
                int cols = Convert.ToInt32(Console.ReadLine());

                jagged[i] = new int[cols]; // define row length

                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Enter element for row {i}, col {j}: ");
                    jagged[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            // Step 4: Print the jagged array
            Console.WriteLine("\nJagged Array:");
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j] + " ");
                }
                Console.WriteLine();
            }

            //Task 6
            // Step 1: Create jagged array with 5 rows
            int[][] jagged = new int[5][];

            // Step 2: Initialize each row length as multiple of row number
            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = new int[i + 1]; // Row 1 → 1 element, Row 2 → 2 elements, etc.
            }

            Random rand = new Random();

            // Step 3: Fill with random numbers (1–100)
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    jagged[i][j] = rand.Next(1, 101); // inclusive 1, exclusive 101
                }
            }
            // Step 4: Print jagged array and row sums
            Console.WriteLine("Jagged Array with Row Sums:");
            for (int i = 0; i < jagged.Length; i++)
            {
                int rowSum = 0;
                Console.Write($"Row {i + 1}: ");
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j] + " ");
                    rowSum += jagged[i][j];
                }
                Console.WriteLine($" | Sum = {rowSum}");
            }
        }



        // Section 3: Lists
        //Task 7 :
        List<int> numbers = new List<int>() ;

            Console.WriteLine("enter 5 numbers :");
            for (int i = 0; i < numbers.Count; i++)
            {

                int x = Convert.ToInt32(Console.ReadLine() ;
                Console.WriteLine(x);
            }


            //Task 8 :
            List<string> names = new List<string>() { "Charlie", "Alice", "Bob", "David", "Eve" };
            names.Sort();

            foreach (string name in names)
            {
                Console.WriteLine(name); 
            }

            // Task 9 :
            List<int> empty_list = new List<int>();
            Console.WriteLine(" Add numbers , to exit add -1 ");
           while(true)
            {
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num == -1)
                        break;
                    empty_list.Add(num);
            }
                Console.Write("List : ");
                foreach(int element in empty_list)
                {
                    Console.Write(element + ",");
                }
                Console.WriteLine();
            int avg = 0;
            if(empty_list.Count > 0)
            {
                avg = empty_list.Sum();
                Console.WriteLine("larget : " + empty_list.Max());
                Console.WriteLine("smallest : " + empty_list.Min());
            }
            Console.WriteLine(" the avg is = " + avg);

            empty_list.Sort();
            foreach(int element in empty_list)
            {  
                Console.Write(element + ",");
            }

            }
        }
}
