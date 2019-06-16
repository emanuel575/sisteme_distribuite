using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Problema13
{
    class Program
    {
        public static void swap(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
        public static void sortare(int[] arr, int size)
        {
            for (int i = 0; i < size - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    Mutex m = new Mutex();
                    m.WaitOne();
                    swap(ref arr[i], ref arr[i + 1]);
                    m.ReleaseMutex();
                }
            }
            if (size > 0)
            {
                Thread t = new Thread(() => sortare(arr, --size));
                t.Start();
                t.Join();
                Console.WriteLine("Thread number is : " + t.ManagedThreadId);
            }
            else
            {
                return;
            }
        }

        public static void printArr(int[] arr)
        {
            foreach(var el in arr)
            {
                Console.Write(el + " ");
            }
        }
        static void Main(string[] args)
        {
            Mutex m = new Mutex();
            m.WaitOne();
            int[] arr = new int[] { 312, 1, 3, 7, 21, 7465, 12};
            m.ReleaseMutex();
            try
            {
                sortare(arr, arr.Length);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            printArr(arr);
        }
    }
}
