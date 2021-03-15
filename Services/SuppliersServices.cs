using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea_1.DataAccess;

namespace Tarea_1.Services
{
    public class SuppliersServices : NorthWindService
    {
        public IQueryable<Suppliers> GetSuppliers()
        {
            return dataContext.Suppliers.Select(s => s);
        }

        public Suppliers GetSuppliersCompanyName(string companyName)
        {
            return GetSuppliers().Where(w => w.CompanyName == companyName).FirstOrDefault();
        }

        public void UpdateSupplierByCompanyName(string companyName = "Exotic Liquids")
        {
            Suppliers currentsupp = GetSuppliersCompanyName(companyName);

            if (currentsupp == null)
                throw new Exception("Supplier no encontrado");

            currentsupp.CompanyName = "UANL Inc.";
            currentsupp.ContactName = "Rogelio Garza Rivera";
            currentsupp.ContactTitle = "Rector";
            currentsupp.City = "Monterrey";
            currentsupp.Address = "Av. Pedro de Alba S/N, Ciudad Universitaria";
            currentsupp.Country = "MX";
            currentsupp.Phone = "(81) 8329-4001";
            currentsupp.PostalCode = "66455";

            dataContext.SaveChanges();
        }

    }
}
