namespace HealthClinic.Models
{
    public class Veterinarian:Customer
    {
        
        public string Specialty { get; set; }

        public Veterinarian()
        {
            
            Specialty = string.Empty;
        }
    }
}
