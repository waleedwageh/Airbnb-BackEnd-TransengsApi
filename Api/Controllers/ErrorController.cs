using Api.ErrorsHandlers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("/errors/{code}")]
    [ApiExplorerSettings(IgnoreApi =true)]

    public class ErrorController : ApiBaseController
    {
        public IActionResult error(int code){
            return new ObjectResult(new ApiErrorResponse(code));
        }
    }
}