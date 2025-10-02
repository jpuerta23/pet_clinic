using System;
using System.Collections.Generic;

namespace HealthClinic.Models
{
    public class Animal : IRegister
    {
        // Nombre del animal, inicializado para evitar null
        public string Name { get; set; } = string.Empty;

        // Tipo de animal (ej: perro, gato, ave)
        public string Type { get; set; } = string.Empty;

        // Edad inicial en 0
        public int Age { get; set; } = 0;

        public virtual string Emitsound()
        {
            return "Sound generic animal";
        }

        // Implementación de IRegister
        public void Registercustomer(List<Customer> list)
        {
            try
            {
                // create a new customer
                var customer = new Customer();

                // date and time of registration
                
                Console.Write("Enter customer full name: ");
                customer.FullName = Console.ReadLine() ?? "Unknown";

                Console.Write("Enter customer address: ");
                customer.Adress = Console.ReadLine() ?? "Unknown";

                // Asignar el animal actual como la mascota del paciente
                var pet = new Pet
                {
                    Name = this.Name,
                    Type = this.Type,
                    Age = this.Age
                };

                customer.Pet = pet;

                // Guardar en la lista
                list.Add(customer);

                Console.WriteLine("✅ customer registered successfully with Animal as Pet.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error registering customer: {ex.Message}");
            }
        }
    }
}
