using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Problema7
{
    public class Notare : WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int adaugaMaterie(string nume)
        {
            return NotareObj.adaugaMaterie(nume);
        }
        [WebMethod]
        public int adaugaStudent(string nume, string grupa)
        {
            return NotareObj.adaugaStudent(nume, grupa);
        }
        [WebMethod]
        public void adaugaNota(int nota,int idStudent, int idMaterie)
        {
            NotareObj.adaugaNota(nota, idStudent, idMaterie);
        }
        [WebMethod]
        public string returneazaNote(int idMaterie)
        {
            return NotareObj.returneazaNote(idMaterie);
        }
        [WebMethod]
        public string returneazaStudenti(string grupa)
        {
            return NotareObj.returneazaStudenti(grupa);
        }
    }
}
