using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Problema9
{
    public class Management : WebService
    {
        static List<Employee> managers = new List<Employee>();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public void addManager(Employee e)
        {
            managers.Add(e);
            managers.Last().status = "m";
        }
        [WebMethod]
        public void AddEmployee(Employee m, Employee e)
        {
            managers.Find(x => x == m).emp.Add(e);
        }
        [WebMethod]
        public Employee GetManagerOf(Employee e)
        {
            return managers.Find(x => x.emp.Find(y => y == e) == e);
        }
        public Employee GetEmployeesOf(Employee manager)
        {
            return managers.Find(x => x == manager).emp.Last();
        }
    }
}
