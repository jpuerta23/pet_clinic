using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pet_clinic.Interfaces
{
    public interface INotificable
    {
        void SendNotify(string message);
    }
}