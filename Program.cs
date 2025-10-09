using System;
using System.Collections.Generic;
using HealthClinic.Models;
using HealthClinic.Services;
using HealthClinic.Utils;

class Program
{
    static void Main()
    {
        // 🧩 Cargar datos por defecto
        var customers = DefaultData.GetDefaultCustomers();
        var veterinarians = DefaultData.GetDefaultVeterinarians();
        // instanciar los servicios
        var customerService = new CustomerService();
        var veterinaryService = new VeterinaryService(veterinarians);

        // 🚀 Iniciar menú principal
        ConsolaUI.MostrarMenu(customers, customerService, veterinaryService);
    }
}
