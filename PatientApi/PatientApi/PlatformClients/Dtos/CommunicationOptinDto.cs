using PatientApi.PlatformClients.Enums;

namespace PatientApi.PlatformClients.Dtos
{
    public class CommunicationOptinDto
    {
        public CommunicationType CommunicationType { get; set; }
        public bool Optin { get; set; }
    }
}
