using HealthClinic.Models;
using HealthClinic.Services;
using HealthClinic.Utils;

var customers = new List<Customer>();

// Crear veterinarios por defecto
var veterinarians = new List<Veterinarian>
{
    new Veterinarian { Name = "Dr. Smith", Specialty = "Internal medicine" },
    new Veterinarian { Name = "Dr. Lopez", Specialty = "surgeon" },
    new Veterinarian { Name = "Dr. Kim", Specialty = "Pathology" }
};

var customerService = new CustomerService();
var veterinaryService = new VeterinaryService(veterinarians);

// Mostrar menú principal
ConsolaUI.MostrarMenu(customers, customerService, veterinaryService);






