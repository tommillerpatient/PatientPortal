using System;
using PatientService.PlatformClients.Enums;

namespace PatientService.PlatformClients.Dtos
{
	public class PatientInsuranceVerificationDto
	{
		public long PatientInsuranceVerificationId { get; set; }

		public DateTime? VerificationDate { get; set; }

		public PolicyType? PolicyType { get; set; }

		public string PreCertificationPhoneNumber { get; set; }

		public string PreCertificationNumber { get; set; }

		public string SpecialCopay { get; set; }

		public string FacilityCopay { get; set; }

		public string Deductible { get; set; }

		public string DeductibleAmountMet { get; set; }

		public string AfterDeductibleMet { get; set; }

		public string CoInsuranceMax { get; set; }

		public string CoInsuranceAmountMet { get; set; }

		public string AfterCoInsuranceMet { get; set; }

		public string TotalOOPMax { get; set; }

		public string TotalAmountMet { get; set; }

		public string Comments { get; set; }

		public ICD? ICD1 { get; set; }

		public ICD? ICD2 { get; set; }

		public CPT? CPT1 { get; set; }

		public CPT? CPT2 { get; set; }

		public string AdditionalClarification { get; set; }

		public string Clearances { get; set; }

		public string SpokeWith { get; set; }

		public string RefferenceId { get; set; }

		public bool? IsActive { get; set; }

		public UserIdNameDto VerifiedBy { get; set; }

		public bool? Predetermination { get; set; }

		public string PredeterminationPhoneNumber { get; set; }

		public bool? ReferralRequired { get; set; }

		public bool? OOPIncludesDeductable { get; set; }

		public bool? OOPMetCovered { get; set; }

		public string CopayIP { get; set; }

		public string CopayOP { get; set; }
	}
}