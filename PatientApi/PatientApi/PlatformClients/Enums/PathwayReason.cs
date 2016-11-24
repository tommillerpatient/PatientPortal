using System.ComponentModel.DataAnnotations;

namespace PatientApi.PlatformClients.Enums
{
	public enum  PathwayReason
	{
		[Display(Name = "No Transportation")]
		Notransportation = 0,

		[Display(Name = "No Answer")]
		Noanswer = 1,

        [Display(Name = "Pending COE")]
        PendingCOE = 2,

        [Display(Name = "Dismissed from program ")]
        DismissedFromProgram  = 3,

        [Display(Name = "Insurance did not cover surgery ")]
        NoInsuranceCoverage = 4,

         [Display(Name = "Withdrew for personal reasons")]
        WithdDrew = 5,

        [Display(Name = "Other")]
        Other = 6,

        [Display(Name = "Wrong Number")]
        WrongNumber = 7
	}
}
