using System.ComponentModel.DataAnnotations;

namespace PatientApi.PlatformClients.Enums
{
	public enum CommunicationType
	{
		[Display(Name = "Text")]
		Sms = 0,
		[Display(Name = "Phone")]
		Phone = 1,
		[Display(Name = "Email")]
		Email = 2
	}
}