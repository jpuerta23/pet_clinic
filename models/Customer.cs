using pet_clinic.Interfaces;

namespace HealthClinic.Models;

public class Customer : INotificable
{
    // --- Campo estático para controlar el siguiente ID disponible ---
    private static int _nextId = 1;

    // --- Propiedades del cliente ---
    public int Id { get; private set; }   // 'private set' evita que se cambie manualmente
    public string FullName { get; set; } 
    public int Age { get; set; } 
    public string Adress { get; set; } 
    public Pet Pet { get; set; }

    // --- Constructor ---
    public Customer()
    {
        Id = _nextId++;          // Asigna el ID y luego incrementa para el próximo cliente
        FullName = string.Empty;
        Age = 0;
        Adress = string.Empty;
        Pet = new Pet();
    }

    // --- Método de notificación ---
    public void SendNotify(string message)
    {
        Console.WriteLine($"Notification sent to {FullName}: {message}");
    }

    // --- Método para ver información del cliente ---
    public string Viewinformation()
    {
        return $"Customer ID: {Id}, Name: {FullName}, Address: {Adress}, Pet: {Pet.Name}, Type: {Pet.Type}";
    }
}
