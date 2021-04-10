using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea_1.DataAccess;
using Tarea_1.Models;

namespace Tarea_1.Services
{
    public class SuppliersServices : NorthWindService
    {
        public IQueryable<Suppliers> GetSuppliers()
        {
            return dataContext.Suppliers.Select(s => s);
        }

        public Suppliers GetSuppliersByCompanyName(string companyName)
        {
            return GetSuppliers().Where(w => w.CompanyName == companyName).FirstOrDefault();
        }

        public void UpdateSupplierByCompanyName(string companyName = "Exotic Liquids")
        {
            Suppliers currentsupp = GetSuppliersByCompanyName(companyName);

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

        //Tarea 3
        public Suppliers GetSuppliersByID(int id)
        {
            var supplier = GetSuppliers().Where(w => w.SupplierId == id).FirstOrDefault();
            if (supplier == null)
                throw new Exception("El id solicitado no existe");
            return supplier;
        }

        public void AddSupplier(SuppliersModel newSupplier)
        {
            var newSupplierRegister = new Suppliers() 
            {
                CompanyName = newSupplier.Comname,
                ContactName = newSupplier.Conname,
                City = newSupplier.Municipal,
                Address = newSupplier.Direction,
                Country = newSupplier.Nation,
                Phone = newSupplier.Telephone
            };
            dataContext.Suppliers.Add(newSupplierRegister);
            dataContext.SaveChanges();
        }

        public void UpdateSupplier(int id, SuppliersModel suppliersForUpdate)
        {
            var currentsupplier = GetSuppliersByID(id);
            currentsupplier.CompanyName = suppliersForUpdate.Comname;
            currentsupplier.ContactName = suppliersForUpdate.Conname;
            currentsupplier.City = suppliersForUpdate.Municipal;
            currentsupplier.Address = suppliersForUpdate.Direction;
            currentsupplier.Country = suppliersForUpdate.Nation;
            currentsupplier.Phone = suppliersForUpdate.Telephone;
            dataContext.SaveChanges();
        }

        public void BorrarSupplierByID(int id)
        {
            var supplier = GetSuppliersByID(id);
            dataContext.Suppliers.Remove(supplier);
            dataContext.SaveChanges();
        }

    }
}
