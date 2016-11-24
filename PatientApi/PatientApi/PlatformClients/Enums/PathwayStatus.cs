using System.ComponentModel.DataAnnotations;

namespace PatientApi.PlatformClients.Enums
{
	public enum PathwayStatus
	{
		[Display(Name="On Track")]
		Current = 0,

		[Display(Name = "Stalled")]
		Stalled = 1,

		[Display(Name = "Archived")]
		Archived = 2,

		[Display(Name = "Complete")]
		Completed = 3
	}
}