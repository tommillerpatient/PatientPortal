using System;
using PatientService.PlatformClients.Enums;

namespace PatientService.PlatformClients.Dtos
{
	public class PatientInsuranceDto
	{
		public long PatientInsuranceProviderId { get; set; }

		public string InsuranceProviderPhoneNumber { get; set; }

		public bool IsPrimary { get; set; }

		public string Employer { get; set; }

		public string MemberId { get; set; }

		public string GroupNumber { get; set; }

		public string SubscriberFirstName { get; set; }

		public string SubscriberMiddleName { get; set; }

		public string SubscriberLastName { get; set; }

        public string SubscriberSSN { get; set; }

		public InsuranceSubscriberRelationship? RelationShip { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public DateTime? LastVerifiedOn { get; set; }

		public PatientCoverageType? PatientCoverageType { get; set; }

		public Tuple<long, string> InsuranceProvider { get; set; }

		public Tuple<long, string> PrimaryCareProvider { get; set; }
	}
}