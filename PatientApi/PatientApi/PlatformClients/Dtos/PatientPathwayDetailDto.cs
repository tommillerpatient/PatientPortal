using System.Collections.Generic;
using PatientApi.PlatformClients.Enums;

namespace PatientApi.PlatformClients.Dtos
{
    public class PatientPathwayDetailDto
    {
        public PatientPathwayDetailDto()
        {
            PatientStepDetailList = new List<PatientStepDetailDto>();
        }
        public long PatientPathwayId { get; set; }

        public long PatientId { get; set; }

        public long PathwayId { get; set; }

        public string PathwayDescription { get; set; }

        public PathwayStatus PathwayStatus { get; set; }

        public List<PatientStepDetailDto> PatientStepDetailList { get; set; }
    }
}
