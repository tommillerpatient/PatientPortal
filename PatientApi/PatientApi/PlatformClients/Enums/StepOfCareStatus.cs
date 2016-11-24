using System.ComponentModel;

namespace PatientService.PlatformClients.Enums
{
	public enum StepOfCareStatus
	{
		[Description("New")]
		New = 1,

		[Description("On Track")]
		Current = 2,

		[Description("Stalled")]
		Stalled = 3,

		[Description("Completed")]
		Completed = 4,

		[Description("Completed – With Override")]
		CompletedWithOverride = 5
	}
}