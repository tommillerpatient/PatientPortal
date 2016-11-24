using System.ComponentModel.DataAnnotations;

namespace PatientApi.PlatformClients.Enums
{
	public enum MaritalStatus
	{
		[Display(Name = "Married")]
		Married = 0,

		[Display(Name = "Separated")]
		Separated = 1,

		[Display(Name = "Single")]
		Single = 2,

		[Display(Name = "Divorced")]
		Divorced = 3,

		[Display(Name = "Widow")]
		Widow = 4
	}
}
