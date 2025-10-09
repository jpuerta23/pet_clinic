using System.Globalization;
using HealthClinic.Models;

namespace HealthClinic.Services
{
    public class CustomerService : IRegister<List<Customer>>
    {
       public void Registercustomer(List<Customer> list)
{
    try
    {
        var customer = new Customer();

        // --- Validar nombre único ---
        string name;
        while (true)
        {
            Console.Write("Enter customer FullName: ");
            name = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("❌ Name cannot be empty.");
                continue;
            }

            if (name.Length < 4)
            {
                Console.WriteLine("❌ Name must have at least 4 characters.");
                continue;
            }

            if (list.Any(c => string.Equals(c.FullName, name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("❌ This name already exists. Please enter a different one.");
                continue;
            }

            break;
        }
        customer.FullName = name;

        // --- Validar teléfono ---
        string phone;
        while (true)
        {
            Console.Write("Enter customer Phone number: ");
            phone = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(phone))
            {
                Console.WriteLine("❌ Phone number cannot be empty.");
                continue;
            }

            // Validar formato (solo números y opcional '+')
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\+?\d{8,15}$"))
            {
                Console.WriteLine("❌ Invalid phone number. Use only digits (and optional '+'), at least 8 characters.");
                continue;
            }

            break;
        }
        customer.Phone = phone; // ✅ Asegúrate de tener esta propiedad en tu clase Customer

        // --- Validar dirección ---
        string address;
        while (true)
        {
            Console.Write("Enter customer Address: ");
            address = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("❌ Address cannot be empty.");
                continue;
            }

            if (address.Length < 5)
            {
                Console.WriteLine("❌ Address must have at least 5 characters.");
                continue;
            }

            break;
        }
        customer.Adress = address;

        // --- Validar edad ---
        int age;
        while (true)
        {
            Console.Write("Enter customer Age: ");
            string input = Console.ReadLine() ?? "";

            if (!int.TryParse(input, out age) || age <= 0)
            {
                Console.WriteLine("❌ Invalid age. Please enter a positive number.");
                continue;
            }

            if (age < 18)
            {
                Console.WriteLine("⚠️ Note: The customer must be an adult (18+).");
                continue;
            }

            break;
        }
        customer.Age = age;

        // --- Registrar cliente ---
        list.Add(customer);

        Console.WriteLine("\n✅ Customer registered successfully!");
        Console.WriteLine("===============================");
        ConsoleHelper.WriteSuccess(customer.Viewinformation());
        Console.WriteLine("===============================\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}");
    }
}



        // ✅ Método: listar clientes
        public static void Listcustomers(List<Customer> list)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("No customers registered.");
                return;
            }

            foreach (var c in list)
            {
                Console.WriteLine($"----------------------------------------");
                ConsoleHelper.WriteSuccess($"ID: {c.Id}, Name: {c.FullName}, Address: {c.Adress}");

                if (c.Pets == null || c.Pets.Count == 0)
                {
                    Console.WriteLine("   No pets registered.");
                }
                else
                {
                    Console.WriteLine("   Pets:");
                    foreach (var pet in c.Pets)
                    {
                        Console.WriteLine($"      • Name: {pet.Name}, Type: {pet.Type}, Age: {pet.Age} años , Breed: {pet.Breed}");
                    }
                }
            }

            Console.WriteLine($"----------------------------------------");
        }


        // ✅ Método: buscar cliente por nombre
        public static void SearchcustomerByName(List<Customer> list, string name)
        {
            // Buscar cliente por nombre (ignorando mayúsculas/minúsculas)
            var customer = list.FirstOrDefault(c =>
                string.Equals(c.FullName, name, StringComparison.OrdinalIgnoreCase));

            if (customer != null)
            {
                Console.WriteLine($" Name: {customer.FullName}, Address: {customer.Adress}");

                if (customer.Pets == null || customer.Pets.Count == 0)
                {
                    Console.WriteLine("   No pets registered for this customer.");
                }
                else
                {
                    Console.WriteLine("   Pets:");
                    foreach (var pet in customer.Pets)
                    {
                        Console.WriteLine($"     • Name: {pet.Name},  Type: {pet.Type},   Age: {pet.Age},   Breed: {pet.Breed}");
                    }
                }
            }
            else
            {
                Console.WriteLine("❌ Customer not found.");
            }
        }



        // ✅ Método: agregar mascota a cliente existente
        public static void AddPetToCustomer(List<Customer> list)
        {
            if (list.Count == 0)
            {
                ConsoleHelper.WriteError("⚠️ No customers registered yet.");
                return;
            }

            Console.Write("Enter the customer name to add a pet: ");
            string name = (Console.ReadLine() ?? "").Trim();

            var customer = list.FirstOrDefault(c =>
                string.Equals(c.FullName, name, StringComparison.OrdinalIgnoreCase));

            if (customer == null)
            {
                ConsoleHelper.WriteError("❌ Customer not found.");
                return;
            }

            var newPet = new Pet();

            // 🐾 Validar nombre
            while (true)
            {
                Console.Write("Enter pet name: ");
                newPet.Name = (Console.ReadLine() ?? "").Trim();

                if (string.IsNullOrWhiteSpace(newPet.Name) || newPet.Name.Length < 2)
                {
                    ConsoleHelper.WriteError("❌ Pet name must have at least 2 characters.");
                    continue;
                }

                if (customer.Pets.Any(p => string.Equals(p.Name, newPet.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    ConsoleHelper.WriteError($"❌ {customer.FullName} already has a pet named '{newPet.Name}'.");
                    return;
                }

                break;
            }

            // 🐾 Validar tipo
            while (true)
            {
                Console.Write("Enter pet type: ");
                newPet.Type = (Console.ReadLine() ?? "").Trim();

                if (string.IsNullOrWhiteSpace(newPet.Type) || newPet.Type.Length < 3)
                {
                    ConsoleHelper.WriteError("❌ Pet type must have at least 3 characters.");
                    continue;
                }
                break;
            }

            // 🐾 Validar edad (permite decimales, ej: 1.5)
            double petAge;
            while (true)
            {
                Console.Write("Enter pet age (you can use decimals, e.g., 1.5): ");
                string input = (Console.ReadLine() ?? "").Trim();

                // 🔹 Se fuerza el uso del punto (.) como separador decimal
                if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out petAge) && petAge > 0)
                {
                    newPet.Age = petAge;
                    break;
                }

                ConsoleHelper.WriteError("❌ Invalid pet age. Please enter a positive number (e.g., 2 or 1.5).");
            }

            Console.Write("Enter pet breed: ");
            newPet.Breed = Console.ReadLine() ?? "";

            // ✅ Agregar mascota al cliente
            customer.Pets.Add(newPet);
            ConsoleHelper.WriteSuccess($"✅ Pet '{newPet.Name}' added successfully to {customer.FullName}.");

            // 🐶 Mostrar detalles de la mascota
            Console.WriteLine("\n🐾 Pet details:");
            Console.WriteLine($"   Name: {newPet.Name}");
            Console.WriteLine($"   Type: {newPet.Type}");
            Console.WriteLine($"   Age: {newPet.Age:F1} years");
            Console.WriteLine($"   Breed: {newPet.Breed}");
            Console.WriteLine($"   Sound: {newPet.Emitsound()}");
        }

    }
}





