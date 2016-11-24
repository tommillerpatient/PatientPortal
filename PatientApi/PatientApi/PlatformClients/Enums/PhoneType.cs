using System.ComponentModel.DataAnnotations;

namespace PatientService.PlatformClients.Enums
{
	public enum PhoneType
	{
		[Display(Name = "Other")]
		Other = 0,
		[Display(Name = "Home")]
		Home = 1,
		[Display(Name = "Work")]
		Work = 2,
		[Display(Name = "Cell")]
		Cell = 3
	}
}
