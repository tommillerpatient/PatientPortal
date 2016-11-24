using System.ComponentModel.DataAnnotations;

namespace PatientApi.PlatformClients.Enums
{
	public enum Ethnicity
	{
		[Display(Name = "Unspecified")]
		Unspecified = 0,
		[Display(Name = "American Indian/Alaska Native")]
		AmericanIndian = 1,
		[Display(Name = "Asian")]
		Asian = 2,
		[Display(Name = "Black or African American, not of Hispanic origin")]
		Black = 3,
		[Display(Name = "Hispanic")]
		Hispanic = 4,
		[Display(Name = "White, not of Hispanic origin")]
		White = 5,
		[Display(Name = "Native Hawaiian/Other Pacific Islander")]
		Pacific = 6,
	}
}
