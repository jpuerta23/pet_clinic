namespace HealthClinic.Models
{
    public class Veterinarian
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Specialty { get; set; }

        public Veterinarian()
        {
            Id = _nextId++;
            Name = string.Empty;
            Specialty = string.Empty;
        }
    }
}
