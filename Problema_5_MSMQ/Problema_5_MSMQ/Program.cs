using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Problema_5_MSMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue q = new MyQueue(@".\Private$\matai");
            q.createQueue();
            Student ionel = new Student("ionel", "marcel", "1308");
            Console.WriteLine("Ionel este: {0}", ionel.ToString());
            q.sendMsg(ionel);
            q.receiveMsg();
            q.DestroyQueue();
        }
    }
}
