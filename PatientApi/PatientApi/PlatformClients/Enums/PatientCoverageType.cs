using System.ComponentModel.DataAnnotations;

namespace PatientService.PlatformClients.Enums
{
	public enum PatientCoverageType
	{
		[Display(Name = "Has Coverage")] 
		HasCoverage = 0,

		[Display(Name = "No Coverage")] 
		NoCoverage = 1,

		[Display(Name = "Pending Coverage")] 
		Pending = 2,

        [Display(Name = "Needs Information")]
        NeedInformation = 3,

		[Display(Name = "Self Pay")] 
		SelfPay = 4
	}
}
