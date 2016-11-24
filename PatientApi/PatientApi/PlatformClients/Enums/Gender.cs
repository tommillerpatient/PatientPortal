using System.ComponentModel.DataAnnotations;

namespace PatientApi.PlatformClients.Enums
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
