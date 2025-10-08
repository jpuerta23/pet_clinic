using System;
using System.Collections.Generic;
using HealthClinic.Models;
using HealthClinic.Services;

namespace HealthClinic.Utils
{
    public static class ConsolaUI
    {
        public static void MostrarMenu(
            List<Customer> customers,
            CustomerService customerService,
            VeterinaryService veterinaryService)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== 🏥 Health Clinic Main Menu ===");
                Console.WriteLine("1. Register customer");
                Console.WriteLine("2. List customers");
                Console.WriteLine("3. Search customer by name");
                Console.WriteLine("4. Add pet to existing customer");
                Console.WriteLine("5. Schedule appointment");
                Console.WriteLine("6. View all appointments");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string option = Console.ReadLine() ?? "";

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        customerService.Registercustomer(customers);
                        break;

                    case "2":
                        Console.Clear();
                        CustomerService.Listcustomers(customers);
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Enter name to search: ");
                        var name = Console.ReadLine() ?? "";
                        CustomerService.SearchcustomerByName(customers, name);
                        break;

                    case "4":
                        Console.Clear();
                        CustomerService.AddPetToCustomer(customers);
                        break;

                    case "5":
                        Console.Clear();
                        veterinaryService.ScheduleAppointment(customers);
                        break;

                    case "6":
                        Console.Clear();
                        veterinaryService.ListAppointments();
                        break;

                    case "0":
                        Console.Clear();
                        exit = true;
                        Console.WriteLine("\n👋 Exiting... Have a great day!");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("❌ Invalid option, please try again.");
                        break;
                }

                // Esperar una tecla antes de mostrar el menú otra vez
                if (!exit)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
