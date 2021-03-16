using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarea_1.Services
{
    public class OptionsService 
    {
        public static EmployeeService employeeService = new EmployeeService();
        public static OrderService orderService = new OrderService();
        public static ProductsService productsService = new ProductsService();
        public static CustomerService customerService = new CustomerService();
        public static SuppliersServices suppliersServices = new SuppliersServices();

        public void opcion_1()
        {
            var emp = employeeService.GetEmployees();
            var output = emp.ToList();
            employeeService.printAllFromEmployee(output);
        }

        public void opcion_2()
        {
            var cust = customerService.GetCustomersWhereCity();
            var output = cust.ToList();
            customerService.printAllCustomers(output);
        }

        public void opcion_3()
        {
            var emp = employeeService.GetEmployees().Select(s => new
            {
                s.Title,
                s.FirstName,
                s.LastName
            }).Where(w => w.Title == "Sales Representative");
            var output = emp.ToList();
            output.ForEach(f =>
            {
                Console.WriteLine("\nTitle: " + f.Title +
                                    "\nFirstName: " + f.FirstName +
                                    "\nLastName: " + f.LastName +
                                    "\n");
            });
        }

        public void opcion_4()
        {
            var emp = employeeService.GetEmployees().Select(s => new
            {
                Nombre = s.FirstName,
                Apellido = s.LastName,
                Puesto = s.Title,
                City = s.City
            }).Where(w => w.City == "London");
            var output = emp.ToList();
            output.ForEach(f =>
            {
                Console.WriteLine("\nNombre: " + f.Nombre +
                                    "\nApellido: " + f.Apellido +
                                    "\nPuesto: " + f.Puesto +
                                    "\nCity: " + f.City +
                                    "\n");
            });
        }

        public void opcion_5(string customerID = "SPLIR")
        {
            var emp = orderService.GetOrderByCustomerID(customerID).Select(s => new
            {
                Cliente = s.Customer.CompanyName,
                Vendedor = s.Employee.FirstName,
                Productos = s.OrderDetails.Select(se => se.Product.ProductName),
            });
            var output = emp.ToList();
            output.ForEach(f =>
            {
                Console.WriteLine("\nCliente: " + f.Cliente +
                                    "\nVendedor: " + f.Vendedor +
                                    "\nProducto: " + f.Productos +
                                    "\n");
            });
        }

        public void opcion_6(int id = 1)
        {
            employeeService.UpdateEmployeeById(id);
        }

        public void opcion_7()
        {
            productsService.AddProduct("Chocolate", 49.99m, 100, 100);
        }

        public void opcion_8(int id = 2)
        {
            employeeService.BorrarEmployee(id);
        }

        public void opcion_9()
        {
            suppliersServices.UpdateSupplierByCompanyName();
        }
    }
}
