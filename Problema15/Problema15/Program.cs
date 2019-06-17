using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Problema15
{
    public delegate void read(string fileFromRead, string fileToWrite);
    class Program
    {
        static void readDelegate(string fileFromRead, string fileToWrite)
        {
            Mutex m = new Mutex();
            m.WaitOne();
            //Console.WriteLine(File.ReadAllText(fileFromRead) + " -> " + Thread.CurrentThread.ManagedThreadId + "\n");
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

            read r = new read(readDelegate);
            for (int i = 0; i < n; i++)
            {
                var asyncRes = r.BeginInvoke(i.ToString(), fileToWr, null, null);
            }
        }
    }
}
