using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Tarea_1.DataAccess;

namespace Tarea_1.Services
{
    public class ProductsService : NorthWindService
    {

        public void AddProduct(string productName, decimal unitPrice, short unitsInStock, short unitsOnOrder)
        {
            var newProduct = new Products();
            newProduct.ProductName = productName;
            newProduct.UnitPrice = unitPrice;
            newProduct.UnitsInStock = unitsInStock;
            newProduct.UnitsOnOrder = unitsOnOrder;
            dataContext.Products.Add(newProduct);
            dataContext.SaveChanges();
        }

    }
}
