using System;

namespace PatientService.PlatformClients.Models
{
    public class AddPatienModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string MedicalRecordNumber { get; set; }
    }
}