using System;
using System.Collections.Generic;
using PatientApi.PlatformClients.Enums;

namespace PatientApi.PlatformClients.Dtos
{
	public class PatientInformationDto
	{
		public PatientInformationDto()
		{
			PathwaysDetails = new List<PatientPathwayShortDto>();
		}

		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		public string LastName { get; set; }

		public string AlertText { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public Gender? Gender { get; set; }

		public Ethnicity? Ethnicity { get; set; }

		public string SSN { get; set; }

		public PatientCoverageType? PatientCoverageType { get; set; }

		public PreferredWayToContact? PreferredWayToContact { get; set; }

		public IdNameDto LanguageDto { get; set; }

		//public Languages? Language { get; set; }

		public string SpecialNeeds { get; set; }

		public string EmergencyContactFirstName { get; set; }

		public string EmergencyContactLastName { get; set; }

		public string EmergencyContactPhone { get; set; }

		public RelationShip? EmergencyContactRelation { get; set; }

		public Tuple<long, string> ReferralSource { get; set; }

		public string SecondaryReferralSource { get; set; }

		public Tuple<long, string> PrimaryCarePhysician { get; set; }

		public Tuple<long, string> ReferringPhysician { get; set; }

		public string EmailAddress { get; set; }

		public string MedicalRecordNumber { get; set; }

		public string HomePhone { get; set; }

		public string CellPhone { get; set; }

		public string WorkPhone { get; set; }

		public string ExternalId { get; set; }

		public MaritalStatus? MaritalStatus { get; set; }

		public bool? Insurance { get; set; }

		public TimeSpan? BeginDelivery { get; set; }

		public TimeSpan? EndDelivery { get; set; }

		public string CareGiver { get; set; }

		//PatientAddress
		public string Address1 { get; set; }

		public string Address2 { get; set; }

		public string City { get; set; }

		public Tuple<int, string> State { get; set; }

		public string ZipCode { get; set; }

		public string County { get; set; }

		public long? LogoId { get; set; }

		public Tuple<int, string> Country { get; set; }

        public decimal? Height { get; set; }

        public decimal? Weight { get; set; }

        public bool? TobaccoUsage { get; set; }

        public PhoneType? PrimaryPhoneType { get; set; }

		public List<PatientPathwayShortDto> PathwaysDetails { get; set; }

	}
}