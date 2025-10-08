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

                    if (string.IsNullOrWhiteSpace(name) || name.Length < 4)
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

                // --- Validar dirección ---
                string adress;
                while (true)
                {
                    Console.Write("Enter customer Address: ");
                    adress = (Console.ReadLine() ?? "").Trim();

                    if (string.IsNullOrWhiteSpace(adress) || adress.Length < 5)
                    {
                        Console.WriteLine("❌ Address must have at least 5 characters.");
                        continue;
                    }

                    break;
                }
                customer.Adress = adress;

                // --- Mascota ---
                var pet = new Pet();

                // Validar nombre de mascota
                string petName;
                while (true)
                {
                    Console.Write("Enter pet name: ");
                    petName = (Console.ReadLine() ?? "").Trim();

                    if (string.IsNullOrWhiteSpace(petName) || petName.Length < 2)
                    {
                        Console.WriteLine("❌ Pet name must have at least 2 characters.");
                        continue;
                    }
                    break;
                }
                pet.Name = petName;

                // Validar tipo de mascota
                string petType;
                while (true)
                {
                    Console.Write("Enter pet type: ");
                    petType = (Console.ReadLine() ?? "").Trim();

                    if (string.IsNullOrWhiteSpace(petType) || petType.Length < 2)
                    {
                        Console.WriteLine("❌ Pet type must have at least 3 characters.");
                        continue;
                    }
                    break;
                }
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

                customer.Pets.Add(pet);


                // Guardar en la lista
                list.Add(customer);
                Console.WriteLine("✅ Customer and Pet registered successfully.");
                Console.WriteLine(customer.Viewinformation());
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
                Console.WriteLine($"ID: {c.Id}, Name: {c.FullName}, Address: {c.Adress}");

                if (c.Pets == null || c.Pets.Count == 0)
                {
                    Console.WriteLine("   No pets registered.");
                }
                else
                {
                    Console.WriteLine("   Pets:");
                    foreach (var pet in c.Pets)
                    {
                        Console.WriteLine($"      • Name: {pet.Name}, Type: {pet.Type}, Age: {pet.Age}, Breed: {pet.Breed}");
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
                Console.WriteLine($"      • Name: {pet.Name}, Type: {pet.Type}, Age: {pet.Age}, Breed: {pet.Breed}");
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
                Console.WriteLine("⚠️ No customers registered yet.");
                return;
            }

            Console.Write("Enter the customer name to add a pet: ");
            string name = (Console.ReadLine() ?? "").Trim();

            var customer = list.FirstOrDefault(c =>
                string.Equals(c.FullName, name, StringComparison.OrdinalIgnoreCase));

            if (customer == null)
            {
                Console.WriteLine("❌ Customer not found.");
                return;
            }

            var newPet = new Pet();

            Console.Write("Enter pet name: ");
            newPet.Name = Console.ReadLine() ?? "";

            Console.Write("Enter pet type: ");
            newPet.Type = Console.ReadLine() ?? "";

            Console.Write("Enter pet age: ");
            if (!int.TryParse(Console.ReadLine(), out int petAge) || petAge <= 0)
            {
                Console.WriteLine("❌ Invalid pet age.");
                return;
            }
            newPet.Age = petAge;

            Console.Write("Enter pet breed: ");
            newPet.Breed = Console.ReadLine() ?? "";

            // Agregar mascota al cliente
            customer.Pets.Add(newPet);
            Console.WriteLine($"✅ Pet '{newPet.Name}' added successfully to {customer.FullName}.");
        }

    }
}





