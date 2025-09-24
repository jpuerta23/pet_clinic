using HealthClinic.Models;

namespace HealthClinic.Services;

public static class PatientService
{
    public static void RegisterPatient(List<Patient> list)
    {
        try
        {
            var patient = new Patient
            {
                // Valores temporales para cumplir con 'required'
                Name = string.Empty,
                Pet = new Pet()
            };


            Console.Write("Enter patient Id: ");
            patient.Id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter patient name: ");
            patient.Name = Console.ReadLine() ?? "";

            Console.Write("Enter patient age: ");
            patient.Age = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter patient symptom: ");
            patient.Symptom = Console.ReadLine() ?? "";

            // Related pet
            var pet = new Pet();
            Console.Write("Enter pet name: ");
            pet.Name = Console.ReadLine() ?? "";

            Console.Write("Enter pet type: ");
            pet.Type = Console.ReadLine() ?? "";

            Console.Write("Enter pet age: ");
            pet.Age = int.Parse(Console.ReadLine() ?? "0");

            patient.Pet = pet;

            list.Add(patient);
            Console.WriteLine("✅ Patient registered successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }

    public static void ListPatients(List<Patient> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("No patients registered.");
            return;
        }

        foreach (var p in list)
        {
            Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Age: {p.Age}, Symptom: {p.Symptom}");
            Console.WriteLine($"   Pet: {p.Pet.Name}, Type: {p.Pet.Type}, Age: {p.Pet.Age}");
        }
    }

    public static void SearchPatientByName(List<Patient> list, string name)
    {
        var patient = list.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (patient != null)
        {
            Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Symptom: {patient.Symptom}");
            Console.WriteLine($"   Pet: {patient.Pet.Name}, Type: {patient.Pet.Type}, Age: {patient.Pet.Age}");
        }
        else
        {
            Console.WriteLine("Patient not found.");
        }
    }
}

