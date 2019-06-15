namespace Problema_5_MSMQ
{
    public class Student
    {
        public string nume;
        public string prenume;
        public string grupa;
        public Student(string nume, string prenume, string grupa)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.grupa = grupa;
        }
        ~Student()
        {
            nume = prenume = grupa = null;
        }
    }
}
