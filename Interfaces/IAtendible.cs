using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pet_clinic.Interfaces
{
    public interface IAtendible
    {
        void Atender();
        void general_consultation();
        void vaccination();
    }
}