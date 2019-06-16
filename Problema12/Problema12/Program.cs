using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Problema12
{
    class Program
    {
        public static void multiply(int[] arr, int alpha)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                arr[i] *= alpha;
            }
        }

        public static void sort(int[] arr)
        {
            Array.Sort(arr);
        }

        public static void print(int[] arr)
        {
            foreach (var el in arr)
            {
                Console.Write(el + " ");
            }
        }
        static void Main(string[] args)
        {
            Mutex m = new Mutex();
            m.WaitOne();
            int[] arr = new int[] { 2, 104, 1, 8762, 64531, 12, 375, 31531, 763, 23 };
            m.ReleaseMutex();

            Thread[] threads = new Thread[3];
            threads[0] = new Thread(() => multiply(arr, 3));
            threads[1] = new Thread(() => sort(arr));
            threads[2] = new Thread(() => print(arr));

            foreach(var t in threads)
            {
                t.Start();
                t.Join();
            }
        }
    }
}
