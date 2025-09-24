namespace HealthClinic.Models;

    public class Patient:Pet
    {
       

        protected string adrees { get; set; }= string.Empty;

        protected byte phone { get; set; }
        public string Symptom { get; set; }= string.Empty;

        // Relation with Pet
        public  required Pet Pet { get; set; }
    }

