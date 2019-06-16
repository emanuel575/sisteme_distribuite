using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Problema8
{
    public class Student_Materie
    {
        public int student_id { get; set; }
        public int materie_id { get; set; }
        public int nota { get; set; }

        public Student_Materie(int std_id,int mtr_id, int nota)
        {
            this.student_id = std_id;
            this.materie_id = mtr_id;
            this.nota = nota;
        }
    }
}