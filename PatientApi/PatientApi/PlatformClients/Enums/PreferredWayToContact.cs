using System.ComponentModel.DataAnnotations;

namespace PatientService.PlatformClients.Enums
{
	public enum PreferredWayToContact
	{
		[Display(Name = "Phone")]
		Phone = 0,
		[Display(Name = "Text")]
		Text = 1,
		[Display(Name = "Email")]
		Email = 2, 
		[Display(Name = "Post Mail")]
		PostalMail = 3
	}
}
