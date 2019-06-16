using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Problema7
{
    public static class NotareObj
    {
        static int id_materii = 0;
        static int id_studenti = 0;
        static List<Materie> materii = new List<Materie>();
        static List<Student> studenti = new List<Student>();
        static List<Student_Materie> student_nota_materie = new List<Student_Materie>();
        public static int adaugaMaterie(string nume)
        {
            materii.Add(new Materie(nume));
            materii.Last().id = (++id_materii);
            return materii.Last().id;
        }
        public static int adaugaStudent(string nume, string grupa)
        {
            studenti.Add(new Student(nume, grupa));
            studenti.Last().id = (++id_studenti);
            return studenti.Last().id;
        }
        public static void adaugaNota(int nota, int idStudent, int idMateire)
        {
            student_nota_materie.Add(new Student_Materie(idStudent, idMateire, nota));
        }
        public static string returneazaNote(int idMateire)
        {
            Dictionary<string, int> legatura = new Dictionary<string, int>();
            foreach (var x in student_nota_materie)
            {
                if (idMateire == x.materie_id)
                {
                    foreach (var std in studenti)
                    {
                        if (x.student_id == std.id)
                        {
                            legatura.Add(std.nume, x.nota);
                        }
                    }
                }
            }
            string res = "";
            foreach (var x in legatura)
            {
                res += "Studentul : " + x.Key + " are nota : " + x.Value + "\r\n";
            }
            return res;
        }
        public static string returneazaStudenti(string grupa)
        {
            string res = "";
            foreach (var std in studenti)
            {
                if (std.grupa == grupa)
                {
                    res += std.nume + " " + "\r\n";
                }
            }
            return res;
        }
    }
}