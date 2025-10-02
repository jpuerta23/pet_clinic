using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;

namespace pet_clinic.Interfaces
{
    public interface IAtendible
    {

        // Method to attend a customer
        void Attend(Customer customer);
        
        // Method to vaccinate a pet
        void Vaccinationpet(Customer customer, string vaccineName);
    }
}