using System;

namespace Problema_5_MSMQ
{
    class MainBase
    {
        static void Main(string[] args)
        {
            MyQueue.name = @".\Private$\testtam";
            MyQueue.createQueue();
        }
    }
}
