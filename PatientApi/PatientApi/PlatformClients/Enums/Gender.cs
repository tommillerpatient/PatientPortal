using System.ComponentModel.DataAnnotations;

namespace PatientService.PlatformClients.Enums
{
	public enum Gender
	{
		[Display(Name = "Male")]
		Male = 0,
		[Display(Name = "Female")]
		Female = 1,
		[Display(Name = "Other")]
		Other = 2
	}
}
