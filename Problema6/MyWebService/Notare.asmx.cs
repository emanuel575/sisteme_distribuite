using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyWebService
{
    public class Notare : WebService
    {
        static  int id_materii = 0;
        static int id_studenti = 0;
        List<Materie> materii = new List<Materie>();
        List<Student> studenti = new List<Student>();
        List<Student_Materie> student_nota_materie = new List<Student_Materie>();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int adaugaMaterie(string nume)
        {
            materii.Add(new Materie(nume));
            materii.Last().id = (++id_materii);
            return materii.Last().id;
        }
        [WebMethod]
        public int adaugaStudent(string nume,string grupa)
        {
            studenti.Add(new Student(nume, grupa));
            studenti.Last().id = (++id_studenti);
            return studenti.Last().id;
        }
        [WebMethod]
        public void adaugaNota(int nota,int idStudent, int idMateire)
        {
            student_nota_materie.Add(new Student_Materie(idStudent, idMateire, nota));
        }
        [WebMethod]
        public Dictionary<string,int> returneazaNote(int idMateire)
        {
            Dictionary<string, int> legatura = new Dictionary<string, int>();
            foreach(var x in student_nota_materie)
            {
                if(idMateire == x.materie_id)
                {
                    if(x.student_id == studenti.Find())
                }
            }
            return legatura;
        }
    }
}
