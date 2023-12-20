using System;

namespace Rearrange_Matrix_by_Sorting_First_Column
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of rows :");
            int.TryParse(Console.ReadLine(), out int rows);
            Console.Write("Enter the number of columns :");
            int.TryParse(Console.ReadLine(), out int cols);
            Console.WriteLine();

            Random rng = new Random();

            //Lab3
            //方法一:此種方式會出現重複亂數
            //int[,] M = new int[rows, cols];

            //for (int i = 0; i < M.GetLength(0); i++)
            //{
            //    for (int j = 0; j < M.GetLength(1); j++)
            //    {

            //        M[i, j] = rng.Next(rows * cols);
            //    }
            //}

            //方法二:先創立一個order的array，再透過shuffling打亂，接著再塞進矩陣裡面
            int[] rngArr = new int[rows * cols];
            int[,] M = new int[rows, cols];
            int[,] sort_M = new int[rows, cols];

            for (int i = 0; i < rows * cols; i++)
            {
                rngArr[i] = i;
            }

            //洗牌
            for (int i = 0; i < rngArr.Length; i++)
            {
                int k = rng.Next(rngArr.Length - i) + i;
                int tmp = rngArr[k];
                rngArr[k] = rngArr[i];
                rngArr[i] = tmp;
            }


            //1.雙迴圈寫法

            //填入矩陣訊息
            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        m[i, j] = rngarr[i * cols + j];
            //    }
            //}

            //// 顯示m的矩陣
            //console.writeline("matrix after filling with random values :");
            //for (int i = 0; i < m.getlength(0); i++)
            //{
            //    for (int j = 0; j < m.getlength(1); j++)
            //    {
            //        console.write("{0,3}", m[i, j]);
            //    }
            //    console.writeline();
            //}

            //2.單迴圈寫法(除以cols餘數小於cols的都在同一行)

            //填入矩陣訊息
            for (int i = 0; i < rngArr.Length; i++)
            {

                M[i / cols, i % cols] = rngArr[i];

            }

            // 顯示M的矩陣
            Console.WriteLine("Matrix after filling with random values :");
            for (int i = 0; i < rngArr.Length; i++)
            {

                Console.Write("{0,3}", M[i / cols, i % cols]);

                if (i % cols == cols - 1)
                {
                    Console.WriteLine();
                }
            }


            // 自定義Sort for array of array
            int CompareRows(int[] row1, int[] row2)
            {
                return row1[0].CompareTo(row2[0]);
            }

            // 將每一行排序
            int[][] rowsArray = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                rowsArray[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    rowsArray[i][j] = M[i, j];
                }
            }

            Array.Sort(rowsArray, CompareRows);

            // 將排序後的值回寫至排序後陣列
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sort_M[i, j] = rowsArray[i][j];
                }
            }

            Console.WriteLine("Matrix after performing row exchanges based on the first column :");
            //顯示sort_M的矩陣

            for (int i = 0; i < sort_M.GetLength(0); i++)
            {
                for (int j = 0; j < sort_M.GetLength(1); j++)
                {
                    Console.Write("{0,3}", sort_M[i, j]);
                }
                Console.WriteLine();
            }
            //----------------------------------------------------------------------------------------------
            //Lab3-1轉成List<List<int>>()

            List<List<int>> listM = new List<List<int>>();
            List<List<int>> listSortM = new List<List<int>>();

            for (int i = 0; i < rows; i++)
            {
                List<int> row =new List<int>();
                for (int j = 0;j < cols; j++)
                {
                    row.Add(rngArr[i*rows+j]);
                }

                listM.Add(row);
                listSortM.Add(new List<int>(row)); // 使用 new List<int>(row) 來複製listM
            }

            Console.WriteLine("Matrix after filling with random values by new List :");
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0;j< cols; j++)
                {
                    Console.Write("{0,3}", listM[i][j]);
                }
                Console.WriteLine();
            }

            // 自定義Sort for list of list
            int CompareRowsList(List<int> row1, List<int> row2)
            {
                return row1[0].CompareTo(row2[0]);
            }

            listM.Sort(CompareRowsList);

            // 將排序後的值回寫至排序後陣列
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    listSortM[i][j] = listM[i][j];
                }
            }
            Console.WriteLine("Matrix after sorting based on the first column by new List :");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0,3}", listSortM[i][j]);
                }
                Console.WriteLine();
            }

        }
    }
}
