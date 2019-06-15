using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebService
{
    public class Student
    {
        public int id { get; set; }
        public string nume { get; set; }
        public string grupa { get; set; }

        public Student(string nume, string grupa)
        {
            id += 1;
            this.nume = nume;
            this.grupa = grupa;
        }

        public string findStudent(int id)
        {
            if(this.id == id)
            {
                return this.nume;
            }
            return "not_found";
        }
    }
}