using System;
using System.Messaging;

namespace Problema_5_MSMQ
{
    public class MyQueue
    {
        private int name;
        static private MessageQueue myQ;
        public MyQueue()
        {
            myQ.Formatter = new BinaryMesageFormatter();
        }
        public MyQueue(string name)
        {
            this.name = name;
            try
            {
                if (!MessageQueue(name).Exist)
                {
                    myQ = MessageQueue.Create(name);
                }
                else
                {
                    Console.WriteLine(name + "already exists");
                }
            }
            catch (MessageQueueException e)
            {
                Console.WriteLine("MSMQ can't be created due to error: {0}", e.Mesage);
            }
        }

        public void sendMsg(string message)
        {
            try
            {
                Message msgtoSend = new Message(message, new BinaryMessageFormatter());
                myQ.Send(msgtoSend);
            }

            catch (Exception e)
            {
                Console.WriteLine("Can't send message due to error : {0}", e.Message);
            }
        }
        public void receiveMsg()
        {
            try
            {
                var msgReceived = myQ.Receive();
                Console.WriteLine("I received: {0]", msgReceived.toString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't receive message due to error : {0}", e.Message);
            }
        }
    }
}
