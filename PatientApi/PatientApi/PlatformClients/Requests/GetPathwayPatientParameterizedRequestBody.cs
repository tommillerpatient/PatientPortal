using System;

namespace PatientService.PlatformClients.Requests
{
    public class GetPathwayPatientParameterizedRequestBody
    {
        public long PatientId { get; set; }

        public long? PatientPathwayId { get; set; }

        public bool ReturnPatientInformation { get; set; }

        public bool ReturnPatientHealthInformation { get; set; }

        public bool ReturnPrimaryInsurance { get; set; }

        public bool ReturnPrimaryInsuranceVerification { get; set; }

        public bool ReturnSecondaryInsurance { get; set; }

        public bool ReturnSecondaryInsuranceVerification { get; set; }

        public bool ReturnCustomFormList { get; set; }

        public bool ReturnOptins { get; set; }

        public const string WcfHandlerName = "GetPathwayPatientParameters";
        public string IdentityUserId { get; set; }
        public string CreatedDate { get; set; }
        public Guid CommandId { get; set; }
        public string ClientIPAddress { get; set; }
        public string HostIPAddress { get; set; }
    }
}
