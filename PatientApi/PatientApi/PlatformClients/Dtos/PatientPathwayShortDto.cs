namespace PatientService.PlatformClients.Dtos
{
    public class PatientPathwayShortDto
    {
        //will be set to zero during patient add
        public long PatientPathwayId { get; set; }

        public long PathwayId { get; set; }

        public string Name { get; set; }

        public long? StepId { get; set; }

        public string NavigatorId { get; set; }

        public long? ProviderId { get; set; }

        public long? LocationId { get; set; }
    }
}
