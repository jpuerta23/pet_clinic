using HealthClinic.Models;

namespace HealthClinic.Services;

public static class PatientService
{
    public static void RegisterPatient(List<Patient> list)
    {
        try
        {
            var patient = new Patient();

            // Validar Id
            int id;
            while (true)
            {
                Console.Write("Enter patient Id: ");
                if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                    break;
                Console.WriteLine("❌ Invalid Id. Please enter a positive number.");
            }
            patient.Id = id;

            // Validar nombre
            string name;
            do
            {
                Console.Write("Enter patient name: ");
                name = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(name))
                    Console.WriteLine("❌ Name cannot be empty.");
            } while (string.IsNullOrWhiteSpace(name));
            patient.Name = name;

            // Validar edad
            int age;
            while (true)
            {
                Console.Write("Enter patient age: ");
                if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                    break;
                Console.WriteLine("❌ Invalid age. Please enter a positive number.");
            }
            patient.Age = age;

            // Validar síntoma
            string symptom;
            do
            {
                Console.Write("Enter patient symptom: ");
                symptom = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(symptom))
                    Console.WriteLine("❌ Symptom cannot be empty.");
            } while (string.IsNullOrWhiteSpace(symptom));
            patient.Symptom = symptom;

            // --- Mascota ---
            var pet = new Pet();

            // Validar nombre de mascota
            string petName;
            do
            {
                Console.Write("Enter pet name: ");
                petName = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(petName))
                    Console.WriteLine("❌ Pet name cannot be empty.");
            } while (string.IsNullOrWhiteSpace(petName));
            pet.Name = petName;

            // Validar tipo de mascota
            string petType;
            do
            {
                Console.Write("Enter pet type: ");
                petType = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(petType))
                    Console.WriteLine("❌ Pet type cannot be empty.");
            } while (string.IsNullOrWhiteSpace(petType));
            pet.Type = petType;

            // Validar edad de mascota
            int petAge;
            while (true)
            {
                Console.Write("Enter pet age: ");
                if (int.TryParse(Console.ReadLine(), out petAge) && petAge > 0)
                    break;
                Console.WriteLine("❌ Invalid pet age. Please enter a positive number.");
            }
            pet.Age = petAge;

            patient.Pet = pet;

            // Guardar en la lista
            list.Add(patient);
            Console.WriteLine("✅ Patient registered successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }

    // ✅ Nuevo método: listar pacientes
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

    // ✅ Nuevo método: buscar paciente por nombre
    public static void SearchPatientByName(List<Patient> list, string name)
    {
        var patient = list.FirstOrDefault(p =>
            string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));

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
