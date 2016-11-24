using System.ComponentModel.DataAnnotations;

namespace PatientService.PlatformClients.Enums
{
	public enum RelationShip
	{
		[Display(Name = "self")]
		Self = 0,
		[Display(Name = "parent")]
		Parent = 1,
		[Display(Name = "child")]
		Child = 2,
		[Display(Name = "sibling")]
		Sibling = 3,
		[Display(Name = "spouse")]
		Spouse = 4,
		[Display(Name = "partner")]
		Partner = 5
	}
}
