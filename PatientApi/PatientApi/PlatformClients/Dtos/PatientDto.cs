using System.Collections.Generic;

namespace PatientService.PlatformClients.Dtos
{
	public class PatientDto
	{
		public PatientDto()
		{
			PatientInformationDto = new PatientInformationDto();
			PatientCustomFormList = new Dictionary<long, string>();
			PatientOptins = new List<PatientOptinDto>();
		}

		public long PatientId { get; set; }
		
		public PatientInformationDto PatientInformationDto { get; set; }

		public PatientHealthInformationDto PatientHealthInformationDto { get; set; }

		public PatientInsuranceDto PrimaryInsurance { get; set; }

		public PatientInsuranceVerificationDto PrimaryInsuranceVerificationDto { get; set; }

		public PatientInsuranceDto SecondaryInsurance { get; set; }

		public PatientInsuranceVerificationDto SecondaryInsuranceVerificationDto { get; set; }

		public PatientPathwayDto CurrentPathway { get; set; }

		public Dictionary<long, string> PatientCustomFormList { get; set; }

		public ICollection<PatientOptinDto> PatientOptins { get; set; }
	}
}
