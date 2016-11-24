using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PatientApi.Helpers;
using PatientApi.PlatformClients;

namespace PatientApi.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        [HttpPost]
        [Route("sign-in")]
        public HttpResponseMessage SignIn(string email, string password)
        {
            try
            {
                var profile = new PlatformService().CheckLoginCredentials(email, password);
                var patient = new PlatformService().GetPatient(profile.PatientId);
                var token = Guid.NewGuid().ToString();
                UserHelper.SetPatient(token, patient);
                return Request.CreateResponse(HttpStatusCode.OK, new { Token = token, Patient = patient });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Error = e.GetBaseException().Message });
            }
        }

        [HttpPost]
        [Route("reset")]
        public HttpResponseMessage Reset(string email, string password, string newPassword)
        {
            try
            {
                var profile = new PlatformService().CheckLoginCredentials(email, password);
                var status = new PlatformService().ResetLoginCredentials(email, newPassword);
                return Request.CreateResponse(HttpStatusCode.OK, new { Error = status ? "" : "fail" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Error = e.GetBaseException().Message });
            }
        }
    }
}
