using Problema_5_MSMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiverMSMQ
{
    class MainRecv
    {
        static void Main(string[] args)
        {
            MyQueue.receiveMsg();
        }
    }
}
