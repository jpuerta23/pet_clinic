namespace pet_clinic.Interfaces
{
    public interface INotificable<T>
    {
        // Method to send a notification to a specific entity
        void SendNotify(T item);
    }
}
