using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebService
{
    public class Materie
    {
        public int id { get; set; }
        public string nume { get; set; }

        public Materie(string nume)
        {
            id += 1;
            this.nume = nume;
        }
    }
}