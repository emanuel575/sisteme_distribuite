using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


/*
 * back-up : 
 * threads[0] = new Thread(() => arrSum(new List<int>(arr).GetRange(0, (n / 4) - 1).ToArray()));
    threads[1] = new Thread(() => arrSum(new List<int>(arr).GetRange((n / 4), (n / 2) - 1).ToArray()));
    threads[2] = new Thread(() => arrSum(new List<int>(arr).GetRange((n / 2), ((3 * n) / 4) - 1).ToArray()));
    threads[3] = new Thread(() => arrSum(new List<int>(arr).GetRange(((3 * n) / 4), n - 1).ToArray()));
*/
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
        public static int[] getArr(int[] arr, int begin, int end)
        {
            int[] res = new int[(end - begin) + 1];
            for (int i = begin; i <= end; i++)
            {
                res[i] = arr[i];
            }
            return res;
        }
        static void Main(string[] args)
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int n = arr.Length;
            Console.WriteLine("Length is {0}", n);
            Thread[] threads = new Thread[5];
            //threads[0] = new Thread(() => arrSum(getArr(arr, 0, (n / 4) - 1)));
            //threads[1] = new Thread(() => arrSum(getArr(arr, (n / 4), (n / 2) - 1)));
            //threads[2] = new Thread(() => arrSum(getArr(arr, (n / 2), ((3 * n) / 4) - 1)));
            //threads[3] = new Thread(() => arrSum(getArr(arr, ((3 * n) / 4), n - 1)));

            threads[0] = new Thread(() => arrSum(new List<int>(arr).GetRange(0, (n / 4) - 1).ToArray()));
            threads[1] = new Thread(() => arrSum(new List<int>(arr).GetRange((n / 4), (n / 2) - 1).ToArray()));
            //threads[2] = new Thread(() => arrSum(new List<int>(arr).GetRange((n / 2), ((3 * n) / 4) - 1).ToArray()));
            //threads[3] = new Thread(() => arrSum(new List<int>(arr).GetRange(((3 * n) / 4), n - 1).ToArray()));

            foreach (var t in threads)
            {
                t.Start();
                t.Join();
            }

        }
    }
}
