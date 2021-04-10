using System;
using System.Collections.Generic;
using Tarea_1.Services;

namespace Tarea_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var opcSelector = new OptionsService();
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
                    opcSelector.opcion_1();
                    break;

                case "2":
                    opcSelector.opcion_2();
                    break;

                case "3":
                    opcSelector.opcion_3();
                    break;

                case "4":
                    opcSelector.opcion_4();
                    break;

                case "5":
                    opcSelector.opcion_5();
                    break;

                case "6":
                    opcSelector.opcion_6();
                    break;

                case "7":
                    opcSelector.opcion_7();
                    break;

                case "8":
                    //opcSelector.opcion_7(); No lo ejecuto porque no quiero afectar a la base actualmente que tengo
                    break;

                case "9":
                    opcSelector.opcion_9();
                    break;

                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }
            
        }
    }
}
