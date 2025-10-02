using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;

namespace pet_clinic.Interfaces
{
    public interface IAtendible
    {
        void Attend(Customer customer);
        
        void Vaccinationpet(Customer customer, string vaccineName);
    }
}