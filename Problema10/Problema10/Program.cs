using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
namespace Problema10
{
    class Program
    {
        static int result = 0;
        public static void sum(int[] arr, int start)
        {
            Mutex m = new Mutex();
            m.WaitOne();
            result += (arr[start] + arr[start + 1]);
            int partRes = 0;
            partRes = (arr[start] + arr[start + 1]);
            File.WriteAllText(((start+1).ToString() + "and" + (start + 2) + ".txt").ToString(), partRes.ToString());
            if (start < arr.Length-3)
            {
                Mutex n = new Mutex();
                n.WaitOne();
                Thread t = new Thread(() => sum(arr, start + 2));
                t.Start();
                Console.WriteLine(t.ToString());
                n.ReleaseMutex();
            }
            else
            {
                Console.WriteLine("Suma este :" + result);
                return;
            }
            m.ReleaseMutex();
        }
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            Thread t = new Thread(() => sum(arr, 0));
            t.Start();
        }
    }
}
