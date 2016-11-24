using System;

namespace PatientApi.PlatformClients.Requests
{
    public class GetPatientPathwayDetailRequestBody
    {
        public long PatientId { get; set; }
        public long PathwayId { get; set; }
        public const string WcfHandlerName = "GetPatientPathwayDetails";
        public string IdentityUserId { get; set; }
        public string CreatedDate { get; set; }
        public Guid CommandId { get; set; }
        public string ClientIPAddress { get; set; }
        public string HostIPAddress { get; set; }
    }
}
