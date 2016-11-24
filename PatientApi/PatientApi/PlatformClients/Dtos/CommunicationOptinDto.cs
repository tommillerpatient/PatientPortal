using PatientService.PlatformClients.Enums;

namespace PatientService.PlatformClients.Dtos
{
    public class CommunicationOptinDto
    {
        public CommunicationType CommunicationType { get; set; }
        public bool Optin { get; set; }
    }
}
