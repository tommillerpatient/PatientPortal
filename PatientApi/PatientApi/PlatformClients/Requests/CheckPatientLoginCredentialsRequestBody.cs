using System;

namespace PatientService.PlatformClients.Requests
{
    public class CheckPatientLoginCredentialsRequestBody
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public const string WcfHandlerName = "CheckPatientLoginCredentials";
        public string IdentityUserId { get; set; }
        public string CreatedDate { get; set; }
        public Guid CommandId { get; set; }
        public string ClientIPAddress { get; set; }
        public string HostIPAddress { get; set; }
    }
}
