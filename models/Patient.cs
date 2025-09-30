using System.Runtime.CompilerServices;

namespace HealthClinic.Models;

public class Patient: IRegister
{


    // Siempre tendrá un valor inicial, nunca null
    public string FullName { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
    public string adress { get; set; } = string.Empty;


    // También con valor inicial


    // Siempre se inicializa con un objeto Pet vacío
    public Pet Pet { get; set; } = new Pet();
    

    // method to register a patient

    public void Register()
    {
        Console.WriteLine("Patient registered successfully.");
    }


    // Método para obtener una informacion del paciente
    public string viewinformation()
    {
        return $"Patient: {FullName}, adress: {adress}, Pet: {Pet.Name}, Type: {Pet.Type}";
    }

}