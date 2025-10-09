using pet_clinic.Interfaces;

namespace HealthClinic.Models;

public class Customer : INotificable<Customer>
{
    private static int _nextId = 1;

    public int Id { get; private set; }
    public string FullName { get; set; } 
    public string Phone { get; set; }
    public int Age { get; set; } 
    public string Adress { get; set; } 

    // 🔹 Ahora una lista de mascotas
    public List<Pet> Pets { get; set; } = new List<Pet>();

    public Customer()
    {
        Id = _nextId++;
        FullName = string.Empty;
        Phone = string.Empty;
        Age = 0;
        Adress = string.Empty;
    }

    public void SendNotify(Customer customer)
{
    Console.WriteLine($"📅 Reminder: {customer.FullName}, you have an appointment scheduled don't miss it");
}


    public string Viewinformation()
    {
        string petInfo = Pets.Count > 0 
            ? string.Join(", ", Pets.Select(p => $"{p.Name} ({p.Type})"))
            : "No pets registered";
        return $"Customer ID: {Id}, Name: {FullName}, Address: {Adress}, phone: {Phone} Pets: {petInfo}";
    }
}
