using System;
using PatientApi.PlatformClients.Enums;

namespace PatientApi.PlatformClients.Dtos
{
	public class PatientPathwayDto
	{
		public long PatientPathwayId { get; set; }

		public Tuple<long, string> Pathway { get; set; }

		public Tuple<long, string> Provider { get; set; }

		public Tuple<string, string> Navigator { get; set; }

		public PathwayStatus Status { get; set; }

		public PathwayReason? Reason { get; set; }

		public bool IsDeleted { get; set; }

		public DateTime? ConsultDate { get; set; }

		public DateTime? SeminarDate { get; set; }

		public DateTime? SurgeryDate { get; set; }

		public DateTime? DischargeDate { get; set; }

		public PatientPipStatus? PipStatus { get; set; }

		public string PipUrl { get; set; }

		public IdNameDto Location { get; set; }
	}
}