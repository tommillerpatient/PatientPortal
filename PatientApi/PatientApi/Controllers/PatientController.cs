using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PatientApi.Helpers;
using PatientApi.PlatformClients;
using PatientApi.PlatformClients.Models;

namespace PatientApi.Controllers
{
    [RoutePrefix("api/patient")]
    public class PatientController : ApiController
    {

        [HttpGet]
        [Route("pathway/{patientId}/{pathwayId}")]
        public HttpResponseMessage GetPatientPathwayDetailsFromPlatform(int patientId, int pathwayId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new PlatformService().GetPatientPathwayDetailsFromPlatform(patientId, pathwayId));
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage SavePatient([FromBody]AddPatienModel model)
        {
            try
            {
                var res = new PlatformService().AddPatient(model);
                var status = new PlatformService().ResetLoginCredentials(model.EmailAddress, model.Password);
                if (res.Success && status)
                {
                    var token = Guid.NewGuid().ToString();
                    var patient = new PlatformService().GetPatient(int.Parse(res.Body));
                    UserHelper.SetPatient(token, patient);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Token = token, Patient = patient });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Error = res.Body });

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Error = e.GetBaseException().Message });
            }
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage UpdatePatient(string token, UpdatePatienModel model)
        {
            try
            {
                var current = UserHelper.GetPatient(token);
                if(current == null) return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Error = "Unauthorized" });
                new PlatformService().UpdatePatient(model);
                var patient = new PlatformService().GetPatient(current.PatientId);
                UserHelper.SetPatient(token, patient);
                return Request.CreateResponse(HttpStatusCode.OK, new { Patient = patient });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Error = e.GetBaseException().Message });
            }
        }
    }
}
