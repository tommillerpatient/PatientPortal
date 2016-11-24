using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using PatientService.PlatformClients.Dtos;
using PatientService.PlatformClients.Enums;
using PatientService.PlatformClients.Models;
using PatientService.PlatformClients.Requests;
using PatientService.PlatformClients.Responses;

namespace PatientService.PlatformClients
{
    public class PlatformService
    {
        //
        // The Client ID is used by the application to uniquely identify itself to Azure AD.
        // The App Key is a credential used by the application to authenticate to Azure AD.
        // The Tenant is the name of the Azure AD tenant in which this application is registered.
        // The AAD Instance is the instance of Azure, for example public Azure or Azure China.
        // The Authority is the sign-in URL of the tenant.
        //
        private static string aadInstance = ConfigurationSettings.AppSettings["ida:AADInstance"];
        private static string tenant = ConfigurationSettings.AppSettings["ida:Tenant"];
        private static string clientId = ConfigurationSettings.AppSettings["ida:ClientId"];
        private static string appKey = ConfigurationSettings.AppSettings["ida:AppKey"];

        static string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        //
        // To authenticate to the service, the client needs to know the service's App ID URI.
        // To contact the To Do list service we need its URL as well.
        //
        private static string ResourceId = ConfigurationSettings.AppSettings["ServiceAppUri"];
        private static string RequestURL = ConfigurationSettings.AppSettings["ServiceRequestUri"];
       
        private AuthenticationContext authContext = new AuthenticationContext(authority);
        private ClientCredential clientCredential = new ClientCredential(clientId, appKey);

        private HttpClient httpClient = new HttpClient();

        public PlatformService()
        {
            //
            // Get an access token to call the To Do service.
            //
            var result = authContext.AcquireTokenAsync(ResourceId, clientCredential);
            result.Wait();
            var authResult = result.Result;

            // Once the token has been returned by ADAL, add it to the http authorization header, before making the call to access the To Do list service.
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
        }

        //JSON Serialization settings
        private static JsonSerializerSettings Settings
        {
            get
            {
                var settings = new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    TypeNameHandling = TypeNameHandling.Auto
                };

                return settings;
            }
        }

        public PatientPathwayDetailDto GetPatientPathwayDetailsFromPlatform(int patientId, int pathwayId)
        {

            //Build the body of the request
            var getPPRequestBody = new GetPatientPathwayDetailRequestBody
            {
                PatientId = patientId,
                PathwayId = pathwayId,
                IdentityUserId = ConfigurationSettings.AppSettings["IdentityUserId"],
                CreatedDate = DateTime.UtcNow.ToString(),
                CommandId = System.Guid.NewGuid()
            };

            //Build the request
            var apiRequest = new APIRequest
            {
                Source = string.Empty,
                TrackingId = Guid.NewGuid().ToString(),
                Type = "GetPatientPathwayDetails",
                Body = JsonConvert.SerializeObject(getPPRequestBody)
            };

            //Generate the HttpContent
            var content = new StringContent(JsonConvert.SerializeObject(apiRequest), System.Text.Encoding.UTF8, "application/json");


            // post the json content to the service.
            var response = httpClient.PostAsync(RequestURL, content);
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                var getPPResult = JsonConvert.DeserializeObject<ApiResponse>(response.Result.Content.ReadAsStringAsync().Result);

                if (getPPResult.Success)
                {
                    return JsonConvert.DeserializeObject<PatientPathwayDetailDto>(getPPResult.Body, Settings);
                }
                throw new Exception(String.Format("Get Request Failed {0}", getPPResult.Body));
            }
            throw new Exception(String.Format("Error Response Code from service - {0}", response.Result.ReasonPhrase));

        }

        public void UpdatePatient(UpdatePatienModel model)
        {
            //Build the body of the request
            var savePPRequestBody = new SavePathwayPatientInformationRequestBody
            {
                PatientId = model.PatientId, //patient id created while saving new patient
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress,
                DateOfBirth = model.Dob,
                AddressLine = model.AddressLine,
                City = model.City,
                StateId = model.StateId, //Shared with other client data
                Gender = Gender.Male,
                PatientPathways = new List<PatientPathwayShortDto>(), //leave empty unless pathway details need to be updated
                MedicalRecordNumber = model.MedicalRecordNumber,
                Optins = new List<CommunicationOptinDto>()
                { new CommunicationOptinDto {  CommunicationType = CommunicationType.Email, Optin = true},
                    new CommunicationOptinDto{ CommunicationType = CommunicationType.Phone, Optin = true},
                    new CommunicationOptinDto{ CommunicationType = CommunicationType.Sms, Optin = true}
                },
                CellPhone = model.CellPhone, //updating with new information
                HomePhone = model.HomePhone, //updating with new information
                IdentityUserId = ConfigurationSettings.AppSettings["IdentityUserId"],
                CreatedDate = DateTime.UtcNow.ToString(),
                CommandId = System.Guid.NewGuid()
            };

            //Build the request
            var apiRequest = new APIRequest
            {
                Source = string.Empty,
                TrackingId = Guid.NewGuid().ToString(),
                Type = "SavePathwayPatientInformation",
                Body = JsonConvert.SerializeObject(savePPRequestBody)
            };

            //Generate the HttpContent
            var content = new StringContent(JsonConvert.SerializeObject(apiRequest), System.Text.Encoding.UTF8, "application/json");


            // post the json content to the service.
            var response = httpClient.PostAsync(RequestURL, content);
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                var getPatientResult = JsonConvert.DeserializeObject<ApiResponse>(response.Result.Content.ReadAsStringAsync().Result);

                if (getPatientResult.Success)
                {
                    return;
                }
                throw new Exception($"Failed Updating Existing Patient {getPatientResult.Body}");
            }
            throw new Exception($"Error Response Code from service - {response.Result.ReasonPhrase}");
        }

        public PatientShortDto CheckLoginCredentials(string email,string password)
        {
            //Build the body of the request
            var checkLoginRequestBody = new CheckPatientLoginCredentialsRequestBody
            {
                EmailAddress = email,
                Password = password,

                IdentityUserId = ConfigurationSettings.AppSettings["IdentityUserId"],
                CreatedDate = DateTime.UtcNow.ToString(),
                CommandId = System.Guid.NewGuid()
            };

            //Build the request
            var apiRequest = new APIRequest
            {
                Source = string.Empty,
                TrackingId = Guid.NewGuid().ToString(),
                Type = "CheckPatientLoginCredentials",
                Body = JsonConvert.SerializeObject(checkLoginRequestBody)
            };

            //Generate the HttpContent
            var content = new StringContent(JsonConvert.SerializeObject(apiRequest), System.Text.Encoding.UTF8, "application/json");


            // post the json content to the service.
            var response = httpClient.PostAsync(RequestURL, content);
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                var checkLoginResult = JsonConvert.DeserializeObject<ApiResponse>(response.Result.Content.ReadAsStringAsync().Result);

                if (checkLoginResult.Success)
                {
                    return JsonConvert.DeserializeObject<PatientShortDto>(checkLoginResult.Body, Settings);
                }
                throw new Exception(String.Format("Failed Fetching Patient {0}", checkLoginResult.Body));
            }
            throw new Exception(String.Format("Error Response Code from service - {0}", response.Result.ReasonPhrase));
        }

        public bool ResetLoginCredentials(string email, string password)
        {
            //Build the body of the request
            var resetLoginRequestBody = new ResetPatientLoginCredentialsRequestBody
            {
                EmailAddress = email,
                NewPassword = password,

                IdentityUserId = ConfigurationSettings.AppSettings["IdentityUserId"],
                CreatedDate = DateTime.UtcNow.ToString(),
                CommandId = System.Guid.NewGuid()
            };

            //Build the request
            var apiRequest = new APIRequest
            {
                Source = string.Empty,
                TrackingId = Guid.NewGuid().ToString(),
                Type = "ResetPatientLoginCredentials",
                Body = JsonConvert.SerializeObject(resetLoginRequestBody)
            };

            //Generate the HttpContent
            var content = new StringContent(JsonConvert.SerializeObject(apiRequest), System.Text.Encoding.UTF8, "application/json");


            // post the json content to the service.
            var response = httpClient.PostAsync(RequestURL, content);
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                var resetLoginResult = JsonConvert.DeserializeObject<ApiResponse>(response.Result.Content.ReadAsStringAsync().Result);

                if (resetLoginResult.Success)
                {
                    return JsonConvert.DeserializeObject<bool>(resetLoginResult.Body, Settings);
                }
                throw new Exception(String.Format("Failed to reset credentials - {0}", resetLoginResult.Body));
            }
            throw new Exception(String.Format("Error Response Code from service - {0}", response.Result.ReasonPhrase));
        }

        public ApiResponse AddPatient(AddPatienModel model)
        {
            //Build the body of the request
            var savePPRequestBody = new SavePathwayPatientInformationRequestBody
            {
                PatientId = 0,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress,
                DateOfBirth = model.Dob,
                AddressLine = model.AddressLine,
                City = model.City,
                StateId = model.StateId, //Shared with other client data
                Gender = Gender.Male,
                PatientPathways = new List<PatientPathwayShortDto>() { new PatientPathwayShortDto { PatientPathwayId = 0, PathwayId = Convert.ToInt32(ConfigurationSettings.AppSettings["PathwayId"]) } },
                MedicalRecordNumber = model.MedicalRecordNumber,
                Optins = new List<CommunicationOptinDto>()
                { new CommunicationOptinDto {  CommunicationType = CommunicationType.Email, Optin = true},
                    new CommunicationOptinDto{ CommunicationType = CommunicationType.Phone, Optin = true},
                    new CommunicationOptinDto{ CommunicationType = CommunicationType.Sms, Optin = true}
                },
                IdentityUserId = ConfigurationSettings.AppSettings["IdentityUserId"],
                CreatedDate = DateTime.UtcNow.ToString(),
                CommandId = System.Guid.NewGuid()
            };

            //Build the request
            var apiRequest = new APIRequest
            {
                Source = string.Empty,
                TrackingId = Guid.NewGuid().ToString(),
                Type = "SavePathwayPatientInformation",
                Body = JsonConvert.SerializeObject(savePPRequestBody)
            };

            //Generate the HttpContent
            var content = new StringContent(JsonConvert.SerializeObject(apiRequest), System.Text.Encoding.UTF8, "application/json");


            // post the json content to the service.
            var response = httpClient.PostAsync(RequestURL, content);
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiResponse>(response.Result.Content.ReadAsStringAsync().Result);
            }
            return new ApiResponse
            {
                Success = false,
                Body = $"Error Response Code from service - {response.Result.ReasonPhrase}"
            };

        }

        public PatientDto GetPatient(long id)
        {
            //Build the body of the request
            var getPatientRequestBody = new GetPathwayPatientParameterizedRequestBody
            {
                PatientId = id,
                ReturnPatientInformation = true,
                ReturnOptins = false,
                ReturnCustomFormList = false,
                ReturnPatientHealthInformation = false,
                ReturnPrimaryInsurance = false,
                ReturnPrimaryInsuranceVerification = false,
                ReturnSecondaryInsurance = false,
                ReturnSecondaryInsuranceVerification = false,

                IdentityUserId = ConfigurationSettings.AppSettings["IdentityUserId"],
                CreatedDate = DateTime.UtcNow.ToString(),
                CommandId = System.Guid.NewGuid()
            };

            //Build the request
            var apiRequest = new APIRequest
            {
                Source = string.Empty,
                TrackingId = Guid.NewGuid().ToString(),
                Type = "GetPathwayPatientParameters",
                Body = JsonConvert.SerializeObject(getPatientRequestBody)
            };

            //Generate the HttpContent
            var content = new StringContent(JsonConvert.SerializeObject(apiRequest), System.Text.Encoding.UTF8, "application/json");


            // post the json content to the service.
            var response = httpClient.PostAsync(RequestURL, content);
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                var getPatientResult = JsonConvert.DeserializeObject<ApiResponse>(response.Result.Content.ReadAsStringAsync().Result);

                if (getPatientResult.Success)
                {
                    return JsonConvert.DeserializeObject<PatientDto>(getPatientResult.Body, Settings);
                }
                throw new Exception($"Failed Get Patient {getPatientResult.Body}");
            }
            throw new Exception($"Error Response Code from service - {response.Result.ReasonPhrase}");
        }
    }
}
