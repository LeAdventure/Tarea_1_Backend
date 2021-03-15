using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea_1.DataAccess;

namespace Tarea_1.Services
{
    public class OrderService : NorthWindService
    {
        

        public IQueryable<Orders> GetOrderByCustomerID(string customerID)
        {
            return dataContext.Orders.Where(w => w.CustomerId == customerID);
        }
    }
}
