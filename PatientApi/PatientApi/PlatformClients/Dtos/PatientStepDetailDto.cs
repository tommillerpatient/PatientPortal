using System;
using System.Collections.Generic;
using PatientApi.PlatformClients.Enums;

namespace PatientApi.PlatformClients.Dtos
{
    public class PatientStepDetailDto
    {
        public PatientStepDetailDto()
        {
            PatientTaskList = new List<PatientTaskDetailDto>();
        }
        public long PatientStepOfCareId { get; set; }

        public StepOfCareStatus StepOfCareStatus { get; set; }

        public StepDto StepDetail { get; set; }

        public DateTime LastUpdatedOn { get; set; }

        public List<PatientTaskDetailDto> PatientTaskList { get; set; }
    }
}
