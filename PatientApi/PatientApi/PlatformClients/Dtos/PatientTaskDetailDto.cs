using System;
using PatientApi.PlatformClients.Enums;

namespace PatientApi.PlatformClients.Dtos
{
    public class PatientTaskDetailDto
    {
        public long PatientTaskId { get; set; }

        public IdNameDto StepOfCareTask { get; set; }

        public PathwayTasksStatus Status { get; set; }

        public UserIdNameDto AssignedTo { get; set; }

        public UserIdNameDto AssignedBy { get; set; }

        public int RepeatCount { get; set; }

        public bool IsRequired { get; set; }

        public bool IsSmart { get; set; }

        public IdNameDto Reason { get; set; }

        public StepOfCareTaskType? Type { get; set; }

        public long? PatientSurveyId { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? StartedOn { get; set; }

        public UserIdNameDto StartedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public UserIdNameDto UpdatedBy { get; set; }

        public DateTime? CompletedOn { get; set; }

        public UserIdNameDto CompletedBy { get; set; }

    }
}
