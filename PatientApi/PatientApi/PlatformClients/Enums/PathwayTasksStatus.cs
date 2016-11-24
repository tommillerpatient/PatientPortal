using System.ComponentModel.DataAnnotations;

namespace PatientApi.PlatformClients.Enums
{
	public enum PathwayTasksStatus
	{
		[Display(Name = "New", Order = 1)]
		New = 1,

		[Display(Name = "In Progress", Order = 2)]
		InProcess = 2,

		[Display(Name = "Complete", Order = 4)]
		Complete = 3,

		[Display(Name = "Incomplete", Order = 5)]
		InComplete = 4,

		//[Display(Name = "Stalled")]
		//Stalled = 5,

		[Display(Name = "Skipped", Order = 3)]
		Skipped = 6
	}
}