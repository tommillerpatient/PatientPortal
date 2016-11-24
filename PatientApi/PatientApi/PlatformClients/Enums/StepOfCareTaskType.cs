using System.ComponentModel.DataAnnotations;

namespace PatientApi.PlatformClients.Enums
{
	public enum StepOfCareTaskType
	{
        [Display(Name="General")]
        General = 0,

		[Display(Name = "Seminar Registration")]
		SeminarRegistration = 1,

		[Display(Name = "Seminar Attendance")]
		SeminarAttendance = 2,

		[Display(Name = "Insurance Verification")]
		InsuranceVerificatiom = 3,

		[Display(Name = "Consult Complete")]
		ConsultComplete = 4,

		[Display(Name = "Surgery Complete")]
		SurgeryComplete = 5,

		[Display(Name = "Patient Discharge")]
		PatientDischarge = 6,

		[Display(Name = "Assign CTS Survey")]
		AssignCTSSurvey = 7,

		[Display(Name = "Online Seminar Registration")]
        OnlineSeminarRegistration = 8,

        [Display(Name = "Online Seminar Attendance")]
        OnlineSeminarAttendance = 9,

        [Display(Name = "Complete Care Transition")]
		CompleteCareTransition = 10,

		[Display(Name = "Intake Form Completion")]
		IntakeFormCompletion = 11
	}
}