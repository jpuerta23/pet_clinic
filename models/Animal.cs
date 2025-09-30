namespace HealthClinic.Models;

public class Animal: IRegister
{
   
  

    // Nombre del animal, inicializado para evitar null
    public string Name { get; set; } = string.Empty;

    // Tipo de animal (ej: perro, gato, ave)
    public string Type { get; set; } = string.Empty;

    // Edad inicial en 0
    public int Age { get; set; } = 0;

    public virtual string Emitsound()
    {
        return "Sound genéric animal";
    }

    // method to register an animal
    public void Register()
    {
        Console.WriteLine("Animal registered successfully.");
    }
}
