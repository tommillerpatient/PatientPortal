using System.Collections.Generic;
using PatientService.PlatformClients.Dtos;

namespace PatientApi.Helpers
{
    public static class UserHelper
    {
        private static readonly Dictionary<string, PatientDto> Patient = new Dictionary<string, PatientDto>();

        public static void SetPatient(string token, PatientDto patient)
        {
            if (patient != null)
            {
                Patient[token] = patient;
            }
            else
            {
                Patient.Remove(token);
            }
            
        }

        public static PatientDto GetPatient(string token)
        {
            return Patient.ContainsKey(token) ? Patient[token] : null;
        }

    }
}