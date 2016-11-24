using System;
using System.ComponentModel.DataAnnotations;
using PatientService.PlatformClients.Enums;

namespace PatientService.PlatformClients.Dtos
{
	public class PatientComment
	{
		public long PatientCommentId { get; set; }

		public long PatientId { get; set; }

		public string Text { get; set; }

        public string CreatedBy { get; set; }

		public DateTime CreatedOn { get; set; }

		public CommentType CommentType { get; set; }

		public long? PatientStepsOfCareId { get; set; }

		public CommunicationType? CommunicationType { get; set; }

		public bool? IsHighPriority { get; set; }

		[StringLength(128)]
		public string UpdatedBy { get; set; }

		public DateTime? UpdatedOn { get; set; }		
	}
}
