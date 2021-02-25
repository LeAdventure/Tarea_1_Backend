using System;
using System.Linq;
using Tarea_1.DataAccess;

namespace Tarea_1
{
    class Program
    {
        public static void tarea_1()
        {
            NorthwindContext dataContext = new NorthwindContext();

            //var empQuery = dataContext.Employees.Select(s => s).AsQueryable();

            //var output = empQuery.ToList();
        }
        static void Main(string[] args)
        {
            tarea_1();
        }
    }
}
