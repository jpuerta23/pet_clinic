using System;
using System.Collections.Generic;
using HealthClinic.Models;

namespace HealthClinic.Utils
{
    public static class DefaultData
    {
        public static List<Customer> GetDefaultCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                   
                    FullName = "Juan Pérez",
                    Adress = "Av. Siempre Viva 123",
                    Phone = "3001234567",
                    Age = 32,
                    Pets = new List<Pet>
                    {
                        new Pet { Name = "Rocky", Type = "Dog", Age = 3.5, Breed = "Labrador" },
                        new Pet { Name = "Mishi", Type = "Cat", Age = 2.1, Breed = "Siamese" }
                    }
                },
                new Customer
                {
                   
                    FullName = "Ana Gómez",
                    Adress = "Calle Luna 45",
                    Phone = "3019876543",
                    Age = 28,
                    Pets = new List<Pet>
                    {
                        new Pet { Name = "Bobby", Type = "Dog", Age = 1.8, Breed = "Poodle" }
                    }
                },
                new Customer
                {
                    
                    FullName = "Carlos Ramírez",
                    Adress = "Carrera Sol 78",
                    Phone = "3125556666",
                    Age = 45,
                    Pets = new List<Pet>
                    {
                        new Pet { Name = "Nemo", Type = "Fish", Age = 0.6, Breed = "Goldfish" },
                        new Pet { Name = "Paco", Type = "Bird", Age = 1.2, Breed = "Parrot" }
                    }
                },
                new Customer
                {
                   
                    FullName = "Jhon Puerta",
                    Adress = "Barrio Aberinco",
                    Phone = "3344444444",
                    Age = 30,
                    Pets = new List<Pet>()
                }
            };
        }

        public static List<Veterinarian> GetDefaultVeterinarians()
        {
            return new List<Veterinarian>
            {
                new Veterinarian {  FullName = "Dr. Smith", Specialty = "Internal medicine" },
                new Veterinarian {  FullName = "Dr. Lopez", Specialty = "Surgeon" },
                new Veterinarian {  FullName = "Dr. Kim", Specialty = "Pathology" }
            };
        }
    }
}
