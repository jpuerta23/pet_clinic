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




                // Validar nombre
                string name;
                do
                {
                    Console.Write("Enter customer your FullName: ");
                    name = Console.ReadLine() ?? "";
                    if (string.IsNullOrWhiteSpace(name))
                        Console.WriteLine("❌ Name cannot be empty.");
                } while (string.IsNullOrWhiteSpace(name));
                customer.FullName = name;





                // Validar síntoma
                string adress;
                do
                {
                    Console.Write("Enter customer Addrees: ");
                    adress = Console.ReadLine() ?? "";
                    if (string.IsNullOrWhiteSpace(adress))
                        Console.WriteLine("❌ Symptom cannot be empty.");
                } while (string.IsNullOrWhiteSpace(adress));
                customer.Adress = adress;

                // --- Mascota ---
                var pet = new Pet();

                // Validar nombre de mascota
                string petName;
                do
                {
                    Console.Write("Enter pet name: ");
                    petName = Console.ReadLine() ?? "";
                    if (string.IsNullOrWhiteSpace(petName))
                        Console.WriteLine("❌ Pet name cannot be empty.");
                } while (string.IsNullOrWhiteSpace(petName));
                pet.Name = petName;

                // Validar tipo de mascota
                string petType;
                do
                {
                    Console.Write("Enter pet type: ");
                    petType = Console.ReadLine() ?? "";
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
                Console.WriteLine("✅ customer and P2et registered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }

        // ✅ Nuevo método: listar pacientes
        public static void Listcustomers(List<Customer> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No customers registered.");
                return;
            }

            foreach (var p in list)
            {
                Console.WriteLine($"Name: {p.FullName}, adress: {p.Adress}");
                Console.WriteLine($"   Pet: {p.Pet.Name}, Type: {p.Pet.Type}, Age: {p.Pet.Age} ,owner: {p.Pet.OwnerName}, breed: {p.Pet.Breed}");
            }
        }

        // ✅ Nuevo método: buscar paciente por nombre
        public static void SearchcustomerByName(List<Customer> list, string name)
        {
            var customer = list.FirstOrDefault(p =>
                string.Equals(p.FullName, name, StringComparison.OrdinalIgnoreCase));

            if (customer != null)
            {
                Console.WriteLine($" Name: {customer.FullName}, adreess: {customer.Adress}");
                Console.WriteLine($"   Pet: {customer.Pet.Name}, Type: {customer.Pet.Type}, Age: {customer.Pet.Age}");
            }
            else
            {
                Console.WriteLine("customer not found.");
            }
        }

    }  
}
