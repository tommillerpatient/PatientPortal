namespace PatientService.PlatformClients.Dtos
{
	public class StepDto
	{
		public long StepId { get; set; }
		public long PathwayId { get; set; }
		
		public string Name { get; set; }
		
		public int Sequence { get; set; }
		
		public string Color { get; set; }

		public bool IsActive { get; set; }
	}
}
