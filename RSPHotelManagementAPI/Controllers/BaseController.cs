using RSPHotelManagementBAL.UnitOfWork;
using RSPHotelManagementComman.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RSPHotelManagementAPI.Controllers
{
    public class BaseController : ApiController
    {
        protected static readonly UnitOfWork UnitOfWork = new UnitOfWork();
        public interface IResponse { }
        protected HttpResponseMessage HttpResponse(HttpStatusCode statusCode, IResponse response=null)
        {
            HttpResponseMessage responseMessage = Request.CreateResponse(statusCode, response);
            if(response==null && HttpStatusCode.InternalServerError==statusCode)
            {
                responseMessage = Request.CreateResponse(statusCode, new FailureResponse(ErrorConstants.API_Internal_Error));
            }
            return responseMessage;
        }
        public class FailureResponse : APIResponse,IResponse
        {
            public FailureResponse(string code) : base(ResponseConstants.Failure, code,ErrorConstants.GetErrorMessage(code))
            { }
            public FailureResponse(string code,string message) : base(ResponseConstants.Failure, code, message) { }

        }
        protected HttpResponseMessage SuccessResponses(object result)
        {
            var response = new SuccessResponse(result);
            return HttpResponse(HttpStatusCode.OK, response);
        }
        public class SuccessResponse : APIResponse, IResponse
        {
            public SuccessResponse(object result)
            {
                this.status = ResponseConstants.Success;
                this.data = result;
            }
            public object data { get; set; }
        }
        public class APIResponse
        {
            public APIResponse() { }
            public APIResponse(int status,string code,string message)
            {
                this.status = status;
                this.error = new APIError() { code = code, message = message };
            }
            public int status { get; set; }
            public APIError error { get; set; }
        }
        public class APIError
        {
            public string code { get; set; }
            public string message { get; set; }
        }
        public class ResponseConstants
        {
            public static int Failure = 0;
            public static int Success = 1;
        }
    }
    
}
