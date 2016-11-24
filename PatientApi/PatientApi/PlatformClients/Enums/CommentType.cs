using System.ComponentModel.DataAnnotations;

namespace PatientService.PlatformClients.Enums
{
	public enum CommentType
	{
		[Display(Name = "General")]
		General = 0,

		[Display(Name = "Action Item")]
		ActionItem = 1,

		[Display(Name = "Clinical")]
		Clinical = 2,

        [Display(Name="To Patient")]
        ToPatient = 3,

        [Display(Name="From Patient")]
        FromPatient = 4
	}
}
