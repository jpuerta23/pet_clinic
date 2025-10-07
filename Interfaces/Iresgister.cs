namespace HealthClinic.Models;
// Interface for registering customers
public interface IRegister<T>
{
    // Method to register a customer
    void Registercustomer (T list);
}
