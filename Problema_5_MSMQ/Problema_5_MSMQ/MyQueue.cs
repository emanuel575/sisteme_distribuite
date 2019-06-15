using System;
using System.Messaging;

namespace Problema_5_MSMQ
{
    public class MyQueue
    {
        private string name;
        private MessageQueue myQ;
        public MyQueue()
        {
        }
        public MyQueue(string name)
        {
            this.name = name;
            try
            {
                if (!MessageQueue.Exists(name))
                {
                    myQ = MessageQueue.Create(name);
                    Console.WriteLine("Message Queue created succefully");
                }
                else
                {
                    Console.WriteLine(name + "already exists");
                }
            }
            catch (MessageQueueException e)
            {
                Console.WriteLine("MSMQ can't be created due to error: {0}", e.Message);
            }
        }

        public void sendMsg(string message)
        {
            try
            {

                myQ.Send(message);
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
                var messages = myQ.GetAllMessages();
                foreach(var msg in messages)
                {
                    Console.WriteLine("I received from queue: {0}",msg.Body);
                }
            }
            catch (MessageQueueException e)
            {
                Console.WriteLine("Can't receive message due to error : {0} type is : {1}", e.Message,e.GetType());
            }
            catch(Exception e)
            {
                Console.WriteLine("Can't receive message due to error : {0} type is : {1}", e.Message, e.GetType());
            }
        }
        public void DestroyQueue()
        {
            MessageQueue.Delete(this.name);
        }
    }
}
