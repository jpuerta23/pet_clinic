namespace HealthClinic.Services;

using HealthClinic.Models;

public abstract class VeterinaryService
{
    public abstract void Attend(Patient patient);
}

public class GeneralConsultation : VeterinaryService
{
    public override void Attend(Patient patient)
    {
        Console.WriteLine($"[General Consultation] Patient: {patient.FullName}, Symptom: {patient.Symptom}");
    }
}

public class Vaccination : VeterinaryService
{
    public override void Attend(Patient patient)
    {
        Console.WriteLine($"[Vaccination] Patient: {patient.FullName}, Pet: {patient.Pet.Name}, Type: {patient.Pet.Type}");
    }
}
