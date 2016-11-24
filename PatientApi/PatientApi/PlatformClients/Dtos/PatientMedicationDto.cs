using System;

namespace PatientApi.PlatformClients.Dtos
{
	public class PatientMedicationDto
	{	
		public long PatientMedicationId { get; set; }

		public string MedicationName {get; set;}

		public string Dosage { get; set; }
		
		public string Frequency { get; set; }
		
		public DateTime? StartDate { get; set; }
		
		public DateTime? StopDate { get; set; }

		public string ReasonForTaking { get; set; }
	}
}
