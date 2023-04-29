using System;

namespace Api.ErrorsHandlers
{
    public class ApiErrorResponse
    {
        public ApiErrorResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message??GetDefaultMessage(statusCode);
        }

      

        public int StatusCode { get; set; }
        public string Message { get; set; }  

          private string GetDefaultMessage(int statusCode)
        {
           return statusCode switch{
               400=>"A Bad Request You Have made",
               401=>"Authorized,You are not",
               404=>"the resource you search for not found",
               501=>"there is a problem with server",
               _=>null

           };
        }
    }
}