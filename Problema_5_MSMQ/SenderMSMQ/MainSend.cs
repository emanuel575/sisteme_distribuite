using Problema_5_MSMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderMSMQ
{
    class MainSend
    {
        public static Student createStudent()
        {
            string nume, prenume, grupa;
            Console.WriteLine("Nume student : ");
            nume = Console.ReadLine();
            Console.WriteLine("Prenume student : ");
            prenume = Console.ReadLine();
            Console.WriteLine("Grupa student : ");
            grupa = Console.ReadLine();
            return new Student(nume, prenume, grupa);
        }

        static int Main(string[] args)
        {
            MyQueue q = new MyQueue();
            MyQueue.name = @".\private$\plm";
            MyQueue.myQ.Path = @".\private$\plm";
            bool menuOpt = true;
            while (menuOpt)
            {
                int choose = 1;
                Console.WriteLine("Introduceti optiune : \n1.Trimite student nou\n2.Inchide aplicatia\n");
                choose = Int32.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        {
                            var std = createStudent();
                            q.sendMsg(std);
                            break;
                        }
                    case 2:
                        {
                            q.DestroyQueue();
                            menuOpt = false;
                            break;
                        }
                    default:
                        break;
                }
            }
            return 0;
        }
    }
}
