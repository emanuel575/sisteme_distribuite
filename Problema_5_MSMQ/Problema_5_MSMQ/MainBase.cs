using System;

namespace Problema_5_MSMQ
{
    class MainBase
    {
        static void Main(string[] args)
        {
            MyQueue q = new MyQueue();
            q.createQueue(@".\private$\plm");
        }
    }
}
