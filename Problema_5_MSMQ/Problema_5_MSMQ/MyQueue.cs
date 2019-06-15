using System;
using System.Messaging;
using System.Threading;

namespace Problema_5_MSMQ
{
    public static class MyQueue
    {
        public static string name { get; set; }
        private static MessageQueue myQ;

        public static bool createQueue()
        {
            try
            {
                if (!MessageQueue.Exists(name))
                {
                    myQ = MessageQueue.Create(name);
                    Console.WriteLine("Message Queue created succefully");
                    return true;
                }
                else
                {
                    Console.WriteLine(name + "already exists");
                    return false;
                }
            }
            catch (MessageQueueException e)
            {
                Console.WriteLine("MSMQ can't be created due to error: {0}", e.Message);
                return false;
            }
            return true;
        }

        public static void sendMsg(Student std)
        {
            try
            {
                string msg = std.nume + " " + std.prenume + " " + std.grupa + "\n";
                myQ.Send(msg);
            }

            catch (Exception e)
            {
                Console.WriteLine("Can't send message due to error : {0}", e.Message);
            }
        }
        public static void receiveMsg()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    var messages = myQ.GetAllMessages();
                    foreach (var msg in messages)
                    {
                        Console.WriteLine( msg.Body.ToString());
                    }
                    Thread.Sleep(30);
                }
            }
            catch (MessageQueueException e)
            {
                Console.WriteLine("MSMQ EXP Can't receive message due to error : {0} type is : {1}", e.Message, e.GetType());
            }
            catch (Exception e)
            {
                Console.WriteLine("Another exp Can't receive message due to error : {0} type is : {1}", e.Message, e.GetType());
            }
        }
        public static void DestroyQueue()
        {
            MessageQueue.Delete(name);
            name = null;
        }
    }
}
