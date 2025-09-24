namespace HealthClinic.Models;

public class Animal
{
    // Identificador único
    public int Id { get; set; }

    // Nombre del animal, inicializado para evitar null
    public string Name { get; set; } = string.Empty;

    // Tipo de animal (ej: perro, gato, ave)
    public string Type { get; set; } = string.Empty;

    // Edad inicial en 0
    public int Age { get; set; } = 0;
}
