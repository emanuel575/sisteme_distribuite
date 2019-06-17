using System;
using System.IO;
using System.Threading;
namespace Problema14
{
    class Program
    {
        public static void read(string fileFromRead, string fileToWrite)
        {
            Mutex m = new Mutex();
            m.WaitOne();
            File.AppendAllText(fileToWrite, File.ReadAllText(fileFromRead) + " -> " + Thread.CurrentThread.ManagedThreadId + "\n");
            m.ReleaseMutex();
        }
        static void Main(string[] args)
        {
            Console.Write("Introduceti n = ");
            var n = Int32.Parse(Console.ReadLine());

            Mutex m = new Mutex();
            m.WaitOne();
            const string fileToWr = "result.txt";
            m.ReleaseMutex();

            for (int i = 0; i <= n; ++i)
            {
                File.WriteAllText(i.ToString(), (new Random().Next()).ToString());
            }
            Thread.Sleep(10);
            Thread[] threads = new Thread[n];
            for (int i = 0; i < n; i++)
            {
                threads[i] = new Thread(() => read(i.ToString(), fileToWr));
                threads[i].Start();
                threads[i].Join();
            }
        }
    }
}
