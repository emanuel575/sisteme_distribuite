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
            File.AppendAllText(fileToWrite, File.ReadAllText(fileFromRead) + " -> " + Thread.CurrentThread.ManagedThreadId + "\n");
            m.ReleaseMutex();
        }
        static void Main(string[] args)
        {
            read r = new read(readDelegate);
        }
    }
}
