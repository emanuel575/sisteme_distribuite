using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Problema11
{
    class Program
    {
        static int sum = 0;
        public static void arrSum(int[] arr)
        {
            Mutex m = new Mutex();
            m.WaitOne();
            int sumaS = 0;
            foreach (var x in arr)
            {
                sumaS += x;
            }
            Console.WriteLine("Suma secundara : " + sumaS);
            sum += sumaS;
            m.ReleaseMutex();
        }

        public static void printArr(int[] arr)
        {
            foreach (var x in arr)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }

        public static int[] getSubArr(int[] arr, int begin, int end)
        {
            Mutex m = new Mutex();
            m.WaitOne();
            List<int> res = new List<int>();
            for (int i = begin; i <= end; i++)
            {
                res.Add(arr[i]);
            }
            m.ReleaseMutex();
            return res.ToArray();
        }
        static void Main(string[] args)
        {
            var arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            List<int> asta = new List<int>(arr);

            int n = arr.Length;

            Thread[] threads = new Thread[4];
            threads[0] = new Thread(() => arrSum(getSubArr(arr, 0, (n / 4) - 1)));
            printArr(getSubArr(arr, 0, (n / 4) - 1));
            threads[1] = new Thread(() => arrSum(getSubArr(arr, (n / 4), (n / 2) - 1)));
            printArr(getSubArr(arr, (n / 4), (n / 2) - 1).ToArray());
            threads[2] = new Thread(() => arrSum(getSubArr(arr, (n / 2), ((3 * n) / 4) - 1)));
            printArr(getSubArr(arr, (n / 2), ((3 * n) / 4) - 1).ToArray());
            threads[3] = new Thread(() => arrSum(getSubArr(arr, ((3 * n) / 4), n - 1)));
            printArr(getSubArr(arr, ((3 * n) / 4), n - 1).ToArray());

            try
            {
                foreach (var t in threads)
                {
                    t.Start();
                    t.Join();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Suma finala : " + sum);
        }
    }
}
