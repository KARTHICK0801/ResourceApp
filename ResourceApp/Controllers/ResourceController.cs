using EmployeeData;
using Newtonsoft.Json;
using System;
using EmployeeRepository;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using static EmployeeModel.ResourceM;
using EmployeeModel;

namespace ResourceApp.Controllers
{
    [RoutePrefix("Web")]
    public class ResourceController : ApiController
    {
        private HttpResponseMessage APIOutputResponse = null;
        private ResourceR aEmployeeRepository = null;
        private dynamic mReponseList;
        [Route("InsertResource")]
        [HttpPost]
        public HttpResponseMessage InsertResources(ResourceM aResourceDa) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    APIOutputResponse = new HttpResponseMessage();
                    aEmployeeRepository = new ResourceR();
                    mReponseList = aEmployeeRepository.InsertResources(aResourceDa);
                    APIOutputResponse = CreateResponse(2000, "Success", mReponseList);
                }
                else
                {
                    APIOutputResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                APIOutputResponse = CreateResponse(5000, ex.Message, "");
            }
            finally
            {
                aEmployeeRepository = null;
                APIOutputResponse.Headers.Add("CallMessage", "InsertStudentM");
            }
            return APIOutputResponse;
        }

        [Route("UpdateResource")]
        [HttpPost]
        public HttpResponseMessage UpdateResources(ResourceM aResourceDa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    APIOutputResponse = new HttpResponseMessage();
                    aEmployeeRepository = new ResourceR();
                    mReponseList = aEmployeeRepository.UpdateResource(aResourceDa);
                    APIOutputResponse = CreateResponse(2000, "Success", mReponseList);
                }
                else
                {
                    APIOutputResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                APIOutputResponse = CreateResponse(5000, ex.Message, "");
            }
            finally
            {
                aEmployeeRepository = null;
                APIOutputResponse.Headers.Add("CallMessage", "InsertStudentM");
            }
            return APIOutputResponse;
        }

        [Route("GetString")]
        [HttpGet]

        public HttpResponseMessage GetCompanyName()
        {
            try
            {
                string mReponseList = "Easy design systems";
                APIOutputResponse = CreateResponse(2000, "Success", mReponseList);
            }
            catch (Exception ex)
            {
                APIOutputResponse = CreateResponse(5000, ex.Message, "");
            }

            return APIOutputResponse;
        }

        private HttpResponseMessage CreateResponse(int aResponseCode, string aReponseMessage, dynamic aResponseList)
        {
            APIResponse mAPIResponse = null;
            HttpResponseMessage mHttpResponseMessage = null;
            try
            {
                mHttpResponseMessage = new HttpResponseMessage();
                mAPIResponse = new APIResponse();
                mAPIResponse.ResponseCode = aResponseCode;
                mAPIResponse.ResponseMessage = aReponseMessage;
                mAPIResponse.ResponseList = aResponseList;
                if (aResponseCode == 5000)
                {
                    mHttpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                }
                mHttpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(mAPIResponse), Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                mAPIResponse.ResponseCode = 5000;
                mAPIResponse.ResponseMessage = ex.Message;
                mHttpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                mHttpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(mAPIResponse), Encoding.UTF8, "application/json");
            }
            return mHttpResponseMessage;
        }
        public class APIResponse
        {
            public int ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
            public dynamic ResponseList { get; set; }
        }
    }
}
