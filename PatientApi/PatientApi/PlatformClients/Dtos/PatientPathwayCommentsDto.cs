using System.Collections.Generic;

namespace PatientApi.PlatformClients.Dtos
{
	public class PatientPathwayCommentsDto
	{
		public PatientPathwayCommentsDto()
		{
			PatientComments = new List<PatientComment>();
		}

		public ICollection<PatientComment> PatientComments { get; set; }

		public int TotalCount { get; set; }
	}
}
