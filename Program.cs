using HealthClinic.Models;
using HealthClinic.Services;

class Program
{
    static void Main(string[] args)
    {
        List<Patient> patients = new List<Patient>();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n=== Health Clinic Main Menu ===");
            Console.WriteLine("1. Register patient");
            Console.WriteLine("2. List patients");
            Console.WriteLine("3. Search patient by name");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                    PatientService.RegisterPatient(patients);
                    break;

                case "2":
                    PatientService.ListPatients(patients);
                    break;

                case "3":
                    Console.Write("Enter name to search: ");
                    var name = Console.ReadLine() ?? "";
                    PatientService.SearchPatientByName(patients, name);
                    break;

                case "4":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("❌ Invalid option, try again.");
                    break;
            }
        }
    }
}
