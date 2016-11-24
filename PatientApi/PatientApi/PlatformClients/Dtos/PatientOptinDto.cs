using PatientApi.PlatformClients.Enums;

namespace PatientApi.PlatformClients.Dtos
{
	public class PatientOptinDto
	{
		public long PatientOptinId { get; set; }
		public long PatientId { get; set; }
		public CommunicationType CommunicationType { set; get; }
		public string OptedBy { get; set; }
		public string OptedByUser { get; set; }
		public bool? Optin { get; set; }
	}
}
