using System.Runtime.CompilerServices;
using pet_clinic.Interfaces;

namespace HealthClinic.Models;

public class Customer: INotificable
{


    // Siempre tendrá un valor inicial, nunca null
    public string FullName { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
    public string Adress { get; set; } = string.Empty;


    



    public Pet Pet { get; set; } = new Pet();
    

    // method to register a customer

  
    public void SendNotify(string message)
    {
        Console.WriteLine($"Notification sent to {FullName}: {message}");
    }


    // Método para obtener una informacion del paciente
    public string Viewinformation()
    {
        return $"customer: {FullName}, adress: {Adress}, Pet: {Pet.Name}, Type: {Pet.Type}";
    }

}