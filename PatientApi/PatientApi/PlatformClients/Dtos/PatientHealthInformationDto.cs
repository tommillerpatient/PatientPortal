using System.Collections.Generic;

namespace PatientService.PlatformClients.Dtos
{
	public class PatientHealthInformationDto
	{
		public decimal? Height { get; set; }

		public decimal? Weight { get; set; }

		public decimal? WaistSize { get; set; }

		public string MajorComplaints { get; set; }

		public string MentalHealthComments { get; set; }

		public bool? TobaccoUsage { get; set; }

		public string TobaccoUsageComments { get; set; }

		public string WomensHealthComments { get; set; }

		public Dictionary<long, string> Allergies { get; set; }

		public List<PatientMedicationDto> Medications {get; set;}

		public Dictionary<long, string> MedicalConditions { get; set; }

		public Dictionary<long, string> MentalConditions { get; set; }

		public Dictionary<long, string> WomenHealthConditions { get; set; }
	}
}