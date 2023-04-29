using System.Collections.Generic;

namespace Api.ErrorsHandlers
{
    public class ApiValidationError : ApiErrorResponse
    {
        public ApiValidationError() : base(400)
        {
        }
        public IEnumerable<string> Errors { get; set; }
    }
}