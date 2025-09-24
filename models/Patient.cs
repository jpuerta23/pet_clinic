namespace HealthClinic.Models;

public class Patient
{
    public int Id { get; set; }

    // Siempre tendrá un valor inicial, nunca null
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    // También con valor inicial
    public string Symptom { get; set; } = string.Empty;

    // Siempre se inicializa con un objeto Pet vacío
    public Pet Pet { get; set; } = new Pet();
}
