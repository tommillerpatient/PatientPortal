using System;
using PatientService.PlatformClients.Enums;

namespace PatientService.PlatformClients.Requests
{
    public class SavePatientCommentRequestBody
    {
        public long PatientId { get; set; }

		public long? StepId { get; set; }

		public CommunicationType? CommunicationType { get; set; }

		public string CommentText { get; set; }

		public bool? IsHighPriority { get; set; }

		public CommentType? CommentType { get; set; }

        public const string WcfHandlerName = "SavePatientCommentCmd";
        public string IdentityUserId { get; set; }
        public string CreatedDate { get; set; }
        public Guid CommandId { get; set; }
        public string ClientIPAddress { get; set; }
        public string HostIPAddress { get; set; }
    }
}
