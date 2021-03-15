using System;
using System.Linq;
using Tarea_1.DataAccess;

namespace Tarea_1
{
    class Program
    {
        public static void select_emp()
        {
            NorthwindContext dataContext = new NorthwindContext();
            var emp = dataContext.Employees.Select(s => s).AsQueryable();
            var output = emp.ToList();
            var i = 0;
            output.ForEach(f =>
            {
                i++;
                Console.WriteLine(  "Empleado " + (i) +
                                    "\nEmployeeID: " + f.EmployeeId + 
                                    "\nLastName: " + f.LastName +
                                    "\nFirstName: " + f.FirstName +
                                    "\nTitle: " + f.Title +
                                    "\nTitleOfCourtesy: " + f.TitleOfCourtesy +
                                    "\nBirthDate: " + f.BirthDate +
                                    "\nHireDate: " + f.HireDate +
                                    "\nAddress: " + f.Address +
                                    "\nCity: " + f.City +
                                    "\nRegion: " + f.Region +
                                    "\nPostalCode: " + f.PostalCode +
                                    "\nCountry: " + f.Country +
                                    "\nHomePhone: " + f.HomePhone +
                                    "\nExtension: " + f.Extension +
                                    "\nPhoto: " + f.Photo +
                                    "\nNotes: " + f.Notes +
                                    "\nReportsTo: " + f.ReportsTo +
                                    "\nPhotoPath: " + f.PhotoPath + 
                                    "\n");
            });
        }
        static void Main(string[] args)
        {
            select_emp();
        }
    }
}
