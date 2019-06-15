using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_5_MSMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue q = new MyQueue(@".\Private$\matai");
            q.sendMsg("salCmf");
            q.sendMsg("salut din nou ");
            q.sendMsg("morti mati ");
            q.receiveMsg();
            q.DestroyQueue();
        }
    }
}
