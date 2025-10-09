using HealthClinic.Models;

namespace HealthClinic.Services
{
    public class VeterinaryService
    {
        // Lista de veterinarios disponibles
        private List<Veterinarian> _veterinarians;

        // Lista de citas agendadas
        private List<Appointment> _appointments = new List<Appointment>();

        public VeterinaryService(List<Veterinarian> veterinarians)
        {
            _veterinarians = veterinarians;
        }

        // ✅ Método para agendar una cita
        public void ScheduleAppointment(List<Customer> customers)
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("⚠️ No customers registered yet.");
                return;
            }

            // Buscar cliente
            Console.Write("Enter the customer's full name: ");
            string name = (Console.ReadLine() ?? "").Trim();
            var customer = customers.FirstOrDefault(c =>
                string.Equals(c.FullName, name, StringComparison.OrdinalIgnoreCase));

            if (customer == null)
            {
                Console.WriteLine("❌ Customer not found.");
                return;
            }

            // Verificar si el cliente tiene mascotas
            if (customer.Pets.Count == 0)
            {
                Console.WriteLine("⚠️ This customer has no registered pets.");
                return;
            }

            Console.WriteLine("Select the pet for the appointment:");
            for (int i = 0; i < customer.Pets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {customer.Pets[i].Name} ({customer.Pets[i].Type})");
            }

            int petChoice;
            while (!int.TryParse(Console.ReadLine(), out petChoice) || petChoice < 1 || petChoice > customer.Pets.Count)
            {
                Console.Write("Invalid choice. Select again: ");
            }
            var selectedPet = customer.Pets[petChoice - 1];

            // Seleccionar veterinario según necesidad
            Console.Write("Enter reason or pet issue (e.g. vaccination, injury, check-up): ");
            string reason = Console.ReadLine() ?? "General Check-up";

            // Elegir veterinario por especialidad
            Console.WriteLine("\nAvailable veterinarians:");
            foreach (var vet in _veterinarians)
            {
                Console.WriteLine($"ID: {vet.Id} - {vet.FullName} ({vet.Specialty})");
            }

            Console.Write("Enter veterinarian ID to assign: ");
            int vetId;
            while (!int.TryParse(Console.ReadLine(), out vetId) || !_veterinarians.Any(v => v.Id == vetId))
            {
                Console.Write("Invalid ID. Enter again: ");
            }
            var assignedVet = _veterinarians.First(v => v.Id == vetId);

            // 🗓️ Pedir al cliente que ingrese la fecha y hora de la cita
            // 📅 Pedir fecha y hora al cliente
            DateTime appointmentDate;
            while (true)
            {
                Console.Write("Enter appointment date and time (format: yyyy-MM-dd HH:mm): ");
                string dateInput = Console.ReadLine() ?? "";

                // Validar formato
                if (!DateTime.TryParse(dateInput, out appointmentDate))
                {
                    Console.WriteLine("❌ Invalid date format. Please try again (e.g., 2025-10-10 14:30).");
                    continue;
                }

                // 🚫 Validar que no esté en el pasado
                if (appointmentDate < DateTime.Now)
                {
                    Console.WriteLine("⚠️ You cannot schedule an appointment in the past.");
                    continue;
                }

                // 🚫 Validar que el veterinario no tenga otra cita en ese horario exacto
                if (_appointments.Any(a => a.Veterinarian.Id == assignedVet.Id && a.Date == appointmentDate))
                {
                    Console.WriteLine("⚠️ This veterinarian already has an appointment at that time. Please choose another time.");
                    continue; // 🔁 vuelve a pedir la fecha
                }

                // ✅ Fecha válida y disponible
                break;
            }

            // Crear cita
            var appointment = new Appointment
            {
                Customer = customer,
                Pet = selectedPet,
                Veterinarian = assignedVet,
                Reason = reason,
                Date = appointmentDate
            };


            _appointments.Add(appointment);

            ConsoleHelper.WriteSuccess($"✅ Appointment scheduled successfully for {customer.FullName} with {assignedVet.FullName} on {appointmentDate:dd/MM/yyyy HH:mm}.");

            // 🔔 Enviar notificación al cliente
            customer.SendNotify(customer);
        }


        // ✅ Mostrar citas existentes
        public void ListAppointments()
        {
            if (_appointments.Count == 0)
            {
                ConsoleHelper.WriteError("No appointments scheduled yet.");
                return;
            }

            Console.WriteLine("\n📋 Appointments List:");
            foreach (var app in _appointments)
            {
                ConsoleHelper.WriteSuccess(app.ToString());
            }
        }
    }
}
