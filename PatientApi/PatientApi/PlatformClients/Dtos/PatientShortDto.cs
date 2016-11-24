using System;
using System.Collections.Generic;
using PatientApi.PlatformClients.Enums;

namespace PatientApi.PlatformClients.Dtos
{
	public class PatientShortDto
	{
		public PatientShortDto()
		{
			Pathways = new List<IdNameDto>();
		}

		public long PatientId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MRN { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public string Phone { get; set; }

		public string Email { get; set; }

		public TimeSpan? BeginDelivery { get; set; }
		public TimeSpan? EndDelivery { get; set; }
		public PreferredWayToContact? ContactType { get; set; }

        public PatientCoverageType? PatientCoverageType { get; set; }


		public string NavigatorName { get; set; }

		public string Surgeon { get; set; }

		public string AlertText { get; set; }

		public List<IdNameDto> Pathways { get; set; }
	}
}
