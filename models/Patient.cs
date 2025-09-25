namespace HealthClinic.Models;

public class Patient
{
    public int Id { get; set; }

    // Siempre tendrá un valor inicial, nunca null
    public string FullName { get; set; } = string.Empty;

   

    // También con valor inicial
    public string Symptom { get; set; } = string.Empty;

    // Siempre se inicializa con un objeto Pet vacío
    public Pet Pet { get; set; } = new Pet();
}
