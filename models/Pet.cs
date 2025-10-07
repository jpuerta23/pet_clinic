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
            return Type.ToLower() switch
            {
                "Dog" => "Guau",
                "Cat" => "Miau",
                "Bird" => "Pío",
                _ => "unknown sound"
            };
        }
    }
}
