using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Problema8
{
    public class Notare : WebService
    {
        static NotareObj myObj;
        [WebMethod]
        public string startClient()
        {
            myObj = new NotareObj();
            return "Object can be used now";
        }
        [WebMethod]
        public int adaugaMaterie(string nume)
        {
            return myObj.adaugaMaterie(nume);
        }
        [WebMethod]
        public int adaugaStudent(string nume, string grupa)
        {
            return myObj.adaugaStudent(nume, grupa);
        }
        [WebMethod]
        public void adaugaNota(int nota, int idStudent, int idMaterie)
        {
            myObj.adaugaNota(nota, idStudent, idMaterie);
        }
        [WebMethod]
        public string returneazaNote(int idMaterie)
        {
            return myObj.returneazaNote(idMaterie);
        }
        [WebMethod]
        public string returneazaStudenti(string grupa)
        {
            return myObj.returneazaStudenti(grupa);
        }
        [WebMethod]
        public string destroyObject()
        {
            myObj = null;
            return "Object can't be used anymore";
        }
    }
}
