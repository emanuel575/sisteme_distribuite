using System;
using System.Messaging;
using System.Threading;

namespace Problema_5_MSMQ
{
    public class MyQueue
    {
        public static string name { get; set; }
        public static MessageQueue myQ = new MessageQueue();

        public bool createQueue(string path)
        {
            name = path;
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

        public void sendMsg(Student std)
        {
            try
            {
                string msgToBeSend = std.nume + " " + std.prenume + " " + std.grupa + "\n";
                Message msg = new Message(msgToBeSend);
                myQ.Send(msg);
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't send message to {0} due to error : {1}", myQ.Path, e.GetType());
            }
        }
        public void receiveMsg()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    var messages = myQ.GetAllMessages();
                    foreach (var msg in messages)
                    {
                        msg.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
                        Console.WriteLine("Studentul : {0}",msg.Body.ToString());
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
        public void DestroyQueue()
        {
            try
            {
                MessageQueue.Delete(name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error deleting {0} due to error {1}", myQ.Path, e.Message);
            }
            //name = null;
        }
    }
}
