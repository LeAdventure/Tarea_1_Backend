using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea_1.DataAccess;

namespace Tarea_1.Services
{
    public class EmployeeService : NorthWindService
    {
        public void printAllEmployee(List<Employees> output)
        {
            output.ForEach(f =>
            {
                Console.WriteLine("\nEmployeeID: " + f.EmployeeId +
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

        public IQueryable<Employees> GetEmployees()
        {
            return dataContext.Employees.Select(s => s);
        }

        public Employees GetEmployeeID(int id)
        {
            return GetEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();
        }

        public void BorrarEmployee(int id)
        {
            var emp = GetEmployeeID(id);

            dataContext.Employees.Remove(emp);
            dataContext.SaveChanges();
        }

        public void UpdateEmployeeById(int id)
        {
            Employees currentemp = GetEmployeeID(id);

            if (currentemp == null)
                throw new Exception("Empleado no encontrado");

            currentemp.FirstName = "Sebastian";
            currentemp.LastName = "Terrazas";
            currentemp.Title = "CEO";
            currentemp.TitleOfCourtesy = "Mr.";
            dataContext.SaveChanges();
        }

        

    }
}
