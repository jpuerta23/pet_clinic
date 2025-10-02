using System;
using System.Collections.Generic;
using HealthClinic.Models;
using HealthClinic.Services;

namespace HealthClinic.Utils
{
    public static class ConsolaUI
    {
        public static void MostrarMenu(List<Customer> customers, CustomerService service)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== Health Clinic Main Menu ===");
                Console.WriteLine("1. Register customer");
                Console.WriteLine("2. List customers");
                Console.WriteLine("3. Search customer by name");
                Console.WriteLine("4. Veterinary services"); // 
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string option = Console.ReadLine() ?? "";

                switch (option)
                {
                    case "1":
                        service.Registercustomer(customers);
                        break;

                    case "2":
                        CustomerService.Listcustomers(customers);
                        break;

                    case "3":
                        Console.Write("Enter name to search: ");
                        var name = Console.ReadLine() ?? "";
                        CustomerService.SearchcustomerByName(customers, name);
                        break;

                    case "4":
                        if (customers.Count == 0)
                        {
                            Console.WriteLine("⚠️ No customers registered yet.");
                            break;
                        }

                        Console.Write("Enter veterinarian name: ");
                        string vetName = Console.ReadLine() ?? "Unknown Vet";

                        var vetService = new VeterinaryService
                        {
                            Veterinarian = vetName
                        };

                        // Tomamos al primer cliente como ejemplo
                        var customer = customers[0];

                        // Atender
                        vetService.Attend(customer);

                        // Vacunación
                        Console.Write("Enter vaccine name: ");
                        string vaccine = Console.ReadLine() ?? "General Vaccine";
                        vetService.Vaccinationpet(customer, vaccine);
                        break;

                    case "5":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("❌ Invalid option, try again.");
                        break;
                }
            }
        }
    }
}
