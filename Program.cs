using System;
using System.Linq;
using Tarea_1.DataAccess;

namespace Tarea_1
{
    class Program
    {
        public static NorthwindContext dataContext = new NorthwindContext();

        public static void opcion_1()
        {
            var emp = GetEmployees();
            var output = emp.ToList();
            var i = 0;
            output.ForEach(f =>
            {
                i++;
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

        public static void opcion_2()
        {
            var emp = GetEmployees().Select(s => new
            {
                s.Title,
                s.FirstName,
                s.LastName
            }).Where(w => w.Title == "Sales Representative");
            var output = emp.ToList();
            var i = 0;
            output.ForEach(f =>
            {
                i++;
                Console.WriteLine("Empleado " + (i) +
                                    "\nTitle: " + f.Title +
                                    "\nFirstName: " + f.FirstName +
                                    "\nLastName: " + f.LastName +
                                    "\n");
            });
        }

        public static void opcion_3()
        {
            var emp = GetEmployees().Select(s => new
            {
                Nombre = s.FirstName,
                Apellido = s.LastName,
                Puesto = s.Title,
            }).Where(w => w.Puesto != "Sales Representative");
            var output = emp.ToList();
            var i = 0;
            output.ForEach(f =>
            {
                i++;
                Console.WriteLine("Empleado " + (i) +
                                    "\nNombre: " + f.Nombre +
                                    "\nApellido: " + f.Apellido +
                                    "\nPuesto: " + f.Puesto +
                                    "\n");
            });
        }

        public static void opcion_4(int orderID = 10248)
        {
            var qry = GetOrderByID(orderID).Select(s => new
            {
                Cliente = s.Customer.CompanyName,
                Vendedor = s.Employee.FirstName,
                Productos = s.OrderDetails.Select(se => se.Product.ProductName)
            });
            var output = qry.ToList();
            output.ForEach(f =>
            {
                Console.WriteLine("\nCliente: " + f.Cliente +
                                    "\nVendedor: " + f.Vendedor +
                                    "\nPuesto: " + f.Productos +
                                    "\n");
            });
        }

        

        public static void opcion_5(int id = 1)
        {
            UpdateEmployee(id);
        }

        private static void UpdateEmployee(int id)
        {
            Employees currentemp = GetEmployeeID(id);

            if (currentemp == null)
                throw new Exception("Empleado no encontrado");


            currentemp.FirstName = "Alejandra";
            dataContext.SaveChanges();
        }

        public static void opcion_6()
        {
            AddProduct("Jugo del Valle 1lt", 15.50m);
        }
        
        public static void opcion_7(int id)
        {
            BorrarEmployee(id);
        }


        #region Refector Methods
        private static IQueryable<Employees> GetEmployees()
        {
            return dataContext.Employees.Select(s => s);
        }

        private static Employees GetEmployeeID(int id)
        {
            return GetEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();
        }

        private static void AddProduct(string productName, decimal unitPrice)
        {
            var newProduct = new Products();
            newProduct.ProductName = productName;
            newProduct.UnitPrice = unitPrice;
            dataContext.Products.Add(newProduct);
            dataContext.SaveChanges();
        }

        private static void BorrarEmployee(int id)
        {
            var emp = GetEmployeeID(id);
            dataContext.Employees.Remove(emp);
            dataContext.SaveChanges();
        }

        private static IQueryable<Orders> GetOrderByID(int orderID)
        {
            return dataContext.Orders.Where(w => w.OrderId == orderID);
        }


        #endregion

        static void Main(string[] args)
        {
            Console.Write("Que quiere hacer?\n" + 
                              "1. Select Employee\n" + 
                              "2. Select Employee Where Title == 'Sales Represnetative'\n" +
                              "3. Aliases de Columna con Where Puesto != 'Sales Represnetative'\n" +
                              "4. Obtener los productos, el cliente y el empleado por ID de Order\n" + 
                              "5. Update Employee Where ID = 1\n" + 
                              "6. Insertar Nuevo Producto\n" +
                              "7. Borrar Empleado\n" + 
                              "Opcion: ");
            string a = Console.ReadLine();
            switch (a)
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
                    //opcion_7(); No lo ejecuto porque no quiero afectar a la base actualmente
                    break;
                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }
            
        }
    }
}
