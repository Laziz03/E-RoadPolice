namespace ERoadPolice.Domain.Entities
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string Phone {  get; set; }  
        public string? OnlyIdentificationNumber {  get; set; } 
        public string? LicenseNumber { get; set; }
         

        public ICollection<Incident> Incidents { get; set; }
    }
}


