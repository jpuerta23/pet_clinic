namespace HealthClinic.Models
{
    public class Pet : Animal
    {

        // Pet details
       
        public string Breed { get; set; }= string.Empty;
        public string OwnerName { get; set; }= string.Empty;

        
        
        // Override the Emitsound method for specific pet sounds
      public override string Emitsound()
{
    string type = Type.Trim().ToLower();

    return type switch
    {
        "dog" or "perro" => "🐶 Guau guau!",
        "cat" or "gato"  => "🐱 Miau miau!",
        "bird" or "pajaro" or "ave" => "🐦 Pío pío!",
        "hamster" => "🐹 Squeak squeak!",
        _ => "🤔 Unknown sound"
    };
}

    }
}
