using System;
using System.Collections.Generic;
using System.Linq;
using Tarea_1.DataAccess;
using Tarea_1.Services;

namespace Tarea_1
{
    class Program
    {
        #region Services
        public static EmployeeService employeeService = new EmployeeService();
        public static OrderService orderService = new OrderService();
        public static ProductsService productsService = new ProductsService();
        public static CustomerService customerService = new CustomerService();
        public static SuppliersServices suppliersServices = new SuppliersServices();
        #endregion

        #region Opciones

        public static void opcion_1()
        {
            var emp = employeeService.GetEmployees();
            var output = emp.ToList();
            employeeService.printAllEmployee(output);
        }

        public static void opcion_2()
        {
            var cust = customerService.GetCustomersWhereCity();
            var output = cust.ToList();
            customerService.printAllCustomers(output);
        }

        public static void opcion_3()
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
                Console.WriteLine(  "\nTitle: " + f.Title +
                                    "\nFirstName: " + f.FirstName +
                                    "\nLastName: " + f.LastName +
                                    "\n");
            });
        }

        public static void opcion_4()
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
                Console.WriteLine(  "\nNombre: " + f.Nombre +
                                    "\nApellido: " + f.Apellido +
                                    "\nPuesto: " + f.Puesto +
                                    "\nCity: " + f.City + 
                                    "\n");
            });
        }

        public static void opcion_5(string customerID = "SPLIR")
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
                Console.WriteLine(  "\nCliente: " + f.Cliente +
                                    "\nVendedor: " + f.Vendedor +
                                    "\nProducto: " + f.Productos +
                                    "\n");
            });
        }

        public static void opcion_6(int id = 1)
        {
            employeeService.UpdateEmployeeById(id);
        }

        public static void opcion_7()
        {
            productsService.AddProduct("Chocolate", 49.99m, 100, 100);
        }
        
        public static void opcion_8(int id = 2)
        {
            employeeService.BorrarEmployee(id);
        }
        
        public static void opcion_9()
        {
            suppliersServices.UpdateSupplierByCompanyName();
        }
        #endregion


        static void Main(string[] args)
        {
            Console.Write("Que quiere hacer?\n" + 
                              "1. Select Employee\n" +
                              "2. Select Customer Where City == Rio de Janeiro\n" + 
                              "3. Select Employee Where Title == 'Sales Represnetative'\n" +
                              "4. Aliases de Columna con Where Puesto != 'Sales Represnetative'\n" +
                              "5. Obtener los productos, el cliente y el empleado por ID de Cliente\n" + 
                              "6. Update Employee Where ID = 1\n" + 
                              "7. Insertar Nuevo Producto\n" +
                              "8. Borrar Empleado\n" + 
                              "9. Update SupplierCompanyName\n" +
                              "Opcion: ");
            string opc = Console.ReadLine();
            switch (opc)
            {
                case "1":
                    opcion_1();
                    break;

                case "2":
                    opcion_2();
                    break;

                case "3":
                    opcion_3();
                    break;

                case "4":
                    opcion_4();
                    break;

                case "5":
                    opcion_5();
                    break;

                case "6":
                    opcion_6();
                    break;

                case "7":
                    opcion_7();
                    break;

                case "8":
                    //opcion_7(); No lo ejecuto porque no quiero afectar a la base actualmente que tengo
                    break;

                case "9":
                    opcion_9();
                    break;

                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }
            
        }
    }
}
