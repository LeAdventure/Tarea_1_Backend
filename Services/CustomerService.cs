using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea_1.DataAccess;

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
    }
}
