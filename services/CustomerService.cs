using HealthClinic.Models;

namespace HealthClinic.Services
{
    public class CustomerService : IRegister
    {
        public void Registercustomer(List<Customer> list)
        {
            try
            {
                var customer = new Customer();

                // --- Validar nombre único ---
                string name;
                do
                {
                    Console.Write("Enter customer FullName: ");
                    name = (Console.ReadLine() ?? "").Trim();

                    if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
                    {
                        Console.WriteLine("❌ Name must have at least 3 characters.");
                        continue;
                    }

                    if (list.Any(c => string.Equals(c.FullName, name, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine("❌ This name already exists. Please enter a different name.");
                        name = "";
                    }

                } while (string.IsNullOrWhiteSpace(name));
                customer.FullName = name;

                // --- Validar dirección ---
                string adress;
                do
                {
                    Console.Write("Enter customer Address: ");
                    adress = (Console.ReadLine() ?? "").Trim();
                    if (string.IsNullOrWhiteSpace(adress) || adress.Length < 5)
                        Console.WriteLine("❌ Address must have at least 5 characters.");
                } while (string.IsNullOrWhiteSpace(adress) || adress.Length < 5);
                customer.Adress = adress;

                // --- Mascota ---
                var pet = new Pet();

                // Validar nombre de mascota (único por dueño)
                string petName;
                do
                {
                    Console.Write("Enter pet name: ");
                    petName = (Console.ReadLine() ?? "").Trim();

                    if (string.IsNullOrWhiteSpace(petName))
                    {
                        Console.WriteLine("❌ Pet name cannot be empty.");
                        continue;
                    }

                    if (list.Any(c => c.Pet != null &&
                        string.Equals(c.Pet.Name, petName, StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(c.FullName, customer.FullName, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine("❌ This customer already has a pet with that name.");
                        petName = "";
                    }

                } while (string.IsNullOrWhiteSpace(petName));
                pet.Name = petName;

                // Validar tipo de mascota
                string petType;
                do
                {
                    Console.Write("Enter pet type: ");
                    petType = (Console.ReadLine() ?? "").Trim();
                    if (string.IsNullOrWhiteSpace(petType))
                        Console.WriteLine("❌ Pet type cannot be empty.");
                } while (string.IsNullOrWhiteSpace(petType));
                pet.Type = petType;

                // Validar edad de mascota
                int petAge;
                while (true)
                {
                    Console.Write("Enter pet age: ");
                    if (int.TryParse(Console.ReadLine(), out petAge) && petAge > 0)
                        break;
                    Console.WriteLine("❌ Invalid pet age. Please enter a positive number.");
                }
                pet.Age = petAge;

                customer.Pet = pet;

                // Guardar en la lista
                list.Add(customer);
                Console.WriteLine("✅ Customer and pet registered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }

        // ✅ Listar clientes
        public static void Listcustomers(List<Customer> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No customers registered.");
                return;
            }

            foreach (var p in list)
            {
                Console.WriteLine($"Name: {p.FullName}, Address: {p.Adress}");
                Console.WriteLine($"   Pet: {p.Pet.Name}, Type: {p.Pet.Type}, Age: {p.Pet.Age}, Owner: {p.FullName}, Breed: {p.Pet.Breed}");
            }
        }

        // ✅ Buscar cliente
        public static void SearchcustomerByName(List<Customer> list, string name)
        {
            var customer = list.FirstOrDefault(p =>
                string.Equals(p.FullName, name, StringComparison.OrdinalIgnoreCase));

            if (customer != null)
            {
                Console.WriteLine($" Name: {customer.FullName}, Address: {customer.Adress}");
                Console.WriteLine($"   Pet: {customer.Pet.Name}, Type: {customer.Pet.Type}, Age: {customer.Pet.Age}");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }
    }
}
