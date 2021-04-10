using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea_1.DataAccess;
using Tarea_1.Models;

namespace Tarea_1.Services
{
    public class CustomerService : NorthWindService
    {
        public void printAllCustomers(List<Customers> output)
        {
            output.ForEach(f =>
            {
                Console.WriteLine("\nCustomerID: " + f.CustomerId +
                                    "\nCompanyName: " + f.CompanyName +
                                    "\nContactName: " + f.ContactName +
                                    "\nContactTitle: " + f.ContactTitle +
                                    "\nAdress: " + f.Address +
                                    "\nCity: " + f.City +
                                    "\nRegion: " + f.Region +
                                    "\nPostalCode: " + f.PostalCode +
                                    "\nCountry: " + f.Country +
                                    "\nPhone: " + f.Phone +
                                    "\nFax: " + f.Fax);
            });
        }

        public IQueryable<Customers> GetCustomersWhereCity(string city = "Rio de Janeiro")
        {
            return dataContext.Customers.Select(s => s).Where(w => w.City == city);
        }

        //Tarea_3 
        public IQueryable<Customers> GetCustomers()
        {
            return dataContext.Customers.Select(s => s);
        }

        public Customers GetCustomerByID(string id)
        {
            var customer = GetCustomers().Where(w => w.CustomerId == id).FirstOrDefault();

            if (customer == null)
                throw new Exception("El id solicitado no existe");

            return customer;
        }

        public void AddCustomer(CustomerModel newCustomer)
        {
            var newCustomerRegister = new Customers() { 
                CustomerId = newCustomer.code,
                CompanyName = newCustomer.CName,
                ContactName = newCustomer.ConName,
                Phone = newCustomer.Telephone
            };

            dataContext.Customers.Add(newCustomerRegister);
            dataContext.SaveChanges();
        }

        public void UpdateCustomer(string id, CustomerModel customerForUpdate)
        {
            var currentcustomer = GetCustomerByID(id);
            currentcustomer.CustomerId = customerForUpdate.code;
            currentcustomer.CompanyName = customerForUpdate.CName;
            currentcustomer.ContactName = customerForUpdate.ConName;
            currentcustomer.Phone = customerForUpdate.Telephone;
            dataContext.SaveChanges();
        }

        public void BorrarCustomerByID(string id)
        {
            var customer = GetCustomerByID(id);
            dataContext.Customers.Remove(customer);
            dataContext.SaveChanges();
        }


    }
}