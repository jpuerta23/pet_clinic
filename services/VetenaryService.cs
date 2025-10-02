namespace HealthClinic.Services;

using HealthClinic.Models;
using pet_clinic.Interfaces;
using System;

public class VeterinaryService : IAtendible
{
    // Propiedades del servicio
    public string ServiceName { get; set; } = "General Veterinary Service";
    public string Veterinarian { get; set; } = "Default Vet";
    public DateTime Date { get; set; } = DateTime.Now;

    // Atender a un paciente
    public void Attend(Customer customer)
    {
        Console.WriteLine($"👨‍⚕️ {Veterinarian} is is taking care of {customer.FullName}'s Pet {customer.Pet.Name}  .");
    }

    // Vacunar a la mascota de un paciente
    public void Vaccinationpet(Customer customer, string vaccineName)
    {
        Console.WriteLine($"💉 {Veterinarian} applied {vaccineName} vaccine to pet {customer.Pet.Name}.");
    }
}
