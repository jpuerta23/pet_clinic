using Pet_Clinic.models;

namespace HealthClinic.Models
{
    public class Pet: Animal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Type { get; set; } // e.g., Dog, Cat, etc.
        public int Age { get; set; }
    }
}
