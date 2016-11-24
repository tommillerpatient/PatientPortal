using System;

namespace PatientService.PlatformClients.Requests
{
    public class ResetPatientLoginCredentialsRequestBody
    {
        public string EmailAddress { get; set; }
        public string NewPassword { get; set; }

        public const string WcfHandlerName = "ResetPatientLoginCredentials";
        public string IdentityUserId { get; set; }
        public string CreatedDate { get; set; }
        public Guid CommandId { get; set; }
        public string ClientIPAddress { get; set; }
        public string HostIPAddress { get; set; }
    }
}
