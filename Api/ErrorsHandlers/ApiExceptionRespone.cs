namespace Api.ErrorsHandlers
{
    public class ApiExceptionRespone : ApiErrorResponse
    {
        public ApiExceptionRespone(int statusCode, string message = null,string details=null) : base(statusCode, message)
        {
            Details = details;
        }

        public string Details { get; }
    }
}