using System;

namespace PatientService.PlatformClients.Requests
{
    public class GetPathwayDetailsRequest
    {
        public long DataId { get; set; }
        public const string WcfHandlerName = "GetPathwayDetails";
        public string IdentityUserId { get; set; }
        public string CreatedDate { get; set; }
        public Guid CommandId { get; set; }
        public string ClientIPAddress { get; set; }
        public string HostIPAddress { get; set; }
    }
}
