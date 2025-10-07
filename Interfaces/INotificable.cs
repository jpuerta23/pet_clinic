using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pet_clinic.Interfaces
{
    public interface INotificable
    {

        // Method to send a notification
        void SendNotify( string message);
    }
}