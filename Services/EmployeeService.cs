using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea_1.DataAccess;
using Tarea_1.Models;

namespace Tarea_1.Services
{
    public class EmployeeService : NorthWindService
    {
        public void printAllFromEmployee(List<Employees> output)
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

        public Employees GetEmployeeByID(int id)
        {
            var employee = GetEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();

            if (employee == null)
                throw new Exception("El id solicitado no existe");

            return employee;
        }

        public void BorrarEmployeeByID(int id)
        {
            var emp = GetEmployeeByID(id);

            dataContext.Employees.Remove(emp);
            dataContext.SaveChanges();
        }

        public void UpdateEmployeeById(int id)
        {
            Employees currentemp = GetEmployeeByID(id);

            if (currentemp == null)
                throw new Exception("Empleado no encontrado");

            currentemp.FirstName = "Sebastian";
            currentemp.LastName = "Terrazas";
            currentemp.Title = "CEO";
            currentemp.TitleOfCourtesy = "Mr.";
            dataContext.SaveChanges();
        }




        //Tarea_3
        public void AddEmployee(EmployeeModel newEmployee)
        {
            var newEmployeeRegister = new Employees()
            {
                FirstName = newEmployee.Name,
                LastName = newEmployee.Surname
            };

            dataContext.Employees.Add(newEmployeeRegister);
            dataContext.SaveChanges();
        }

        public void UpdateEmployee(int id, EmployeeModel employeeForUpdate)
        {
            var currentemployee = GetEmployeeByID(id);
            currentemployee.FirstName = employeeForUpdate.Name;
            currentemployee.LastName = employeeForUpdate.Surname;
            dataContext.SaveChanges();
        }
        
    }
}
