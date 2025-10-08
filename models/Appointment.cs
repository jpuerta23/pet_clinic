using System;

namespace HealthClinic.Models
{
    public class Appointment
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public Customer Customer { get; set; }
        public Pet Pet { get; set; }
        public Veterinarian Veterinarian { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Appointment()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            Id = _nextId++;
            
        }

        public override string ToString()
        {
            return $"Appointment ID: {Id}, Date: {Date:dd/MM/yyyy HH:mm}, " +
                   $"Customer: {Customer.FullName}, Pet: {Pet.Name}, Vet: {Veterinarian.Name}, Reason: {Reason}";
        }
    }
}
