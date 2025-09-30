namespace HealthClinic.Services;

using HealthClinic.Models;
using pet_clinic.Interfaces;

public abstract class VeterinaryService: IAtendible
{
    public void Atender()
    {
       
    }

    public abstract void Attend(Patient patient);

    public void general_consultation()
    {
        
    }

    public void vaccination()
    {
        
    }
}

public class GeneralConsultation : VeterinaryService
{
    public override void Attend(Patient patient)
    {
        Console.WriteLine($"[General Consultation] Patient: {patient.FullName}, adress : {patient.adress}, Pet: {patient.Pet.Name}, Type: {patient.Pet.Type}");
    }
}

public class Vaccination : VeterinaryService
{
    public override void Attend(Patient patient)
    {
        Console.WriteLine($"[Vaccination] Patient: {patient.FullName}, Pet: {patient.Pet.Name}, Type: {patient.Pet.Type}");
    }
}
