using System;
using System.Collections.Generic;
using PatientService.PlatformClients.Dtos;
using PatientService.PlatformClients.Enums;

namespace PatientService.PlatformClients.Requests
{
    public class SavePathwayPatientInformationRequestBody
    {
        public long PatientId { get; set; }

        public string FirstName
        {
            get;
            set;
        }

        public string MiddleName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

		public DateTime? DateOfBirth { get; set; }

		public Gender? Gender { get; set; }

		public string SSN { get; set; }

		public string MedicalRecordNumber { get; set; }

		public long? ReferralSourceId { get; set; }

		public string AddressLine
		{
			get;
			set;
		}

        public string City
        {
            get;
            set;
        }

		public int? StateId { get; set; }

		public string ZipCode { get; set; }

		public string County { get; set; }

		public string HomePhone { get; set; }

		public string CellPhone { get; set; }

		public string WorkPhone { get; set; }

		public string EmailAddress { get; set; }

		public long? LogoId { get; set; }

		// Contact Preference
		public PreferredWayToContact? PreferredWayToContact { get; set; }

		public TimeSpan? BeginDelivery { get; set; }

		public TimeSpan? EndDelivery { get; set; }

		public string SpecialNeeds { get; set; }

		public long? LanguageId { get; set; }

		//public Languages? Language { get; set; }

		public Ethnicity? Ethnicity { get; set; }

		//Enmergency Contact
		public string EmergencyContactFirstName { get; set; }

		public string EmergencyContactLastName { get; set; }

		public string EmergencyContactPhone { get; set; }

		public RelationShip? EmergencyContactRelation { get; set; }

		//Provider Information

		public long? PrimaryCarePhysicianId { get; set; }

		public long? ReferringPhysicianId { get; set; }

		public long HospitalId { get; set; }

		public string CareGiver { get; set; }

		public decimal? Height { get; set; }

		public decimal? Weight { get; set; }

		public bool? TobaccoUsage { get; set; }

		public PhoneType? PrimaryPhoneType { get; set; }

		public List<PatientPathwayShortDto> PatientPathways { get; set; }

		public List<CommunicationOptinDto> Optins { get; set; }

		public MaritalStatus? MaritialStatus { get; set; }

		public string SecondaryReferralSource { get; set; }

        public const string WcfHandlerName = "SavePathwayPatientInformation";
        public string IdentityUserId { get; set; }
        public string CreatedDate { get; set; }
        public Guid CommandId { get; set; }
        public string ClientIPAddress { get; set; }
        public string HostIPAddress { get; set; }
		
    }
}
