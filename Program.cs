using System.Collections.Generic;
using HealthClinic.Models;
using HealthClinic.Services;
using HealthClinic.Utils;

List<Customer> customers = new List<Customer>();
CustomerService service = new CustomerService();  //Instance

ConsolaUI.MostrarMenu(customers, service); //FUNCTION MENU

