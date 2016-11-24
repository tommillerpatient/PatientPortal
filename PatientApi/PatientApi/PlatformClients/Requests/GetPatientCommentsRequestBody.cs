using System;
using PatientApi.PlatformClients.Enums;

namespace PatientApi.PlatformClients.Requests
{
    public class GetPatientCommentsRequestBody
    {
        public long PatientId { get; set; }

        public long? StepId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? EndDate { get; set; }

        public CommentType? CommentType { get; set; }

        public string CreatedBy { get; set; }

        public const string WcfHandlerName = "GetPathwayPatientComments";
        public string IdentityUserId { get; set; }
        public string CreatedDate { get; set; }
        public Guid CommandId { get; set; }
        public string ClientIPAddress { get; set; }
        public string HostIPAddress { get; set; }
    }
}
