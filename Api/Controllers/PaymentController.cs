using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Api.Controllers
{
    public class PaymentController : ApiBaseController
    {
        [HttpGet("products")]
        public IActionResult Products()
        {
            StripeConfiguration.ApiKey = "sk_test_51JHfzoFT1lPmToeXo0ci8XPDFAOvwG9LFvWyh34XhAevRPMksXBalUdgzxON2GRueGsdAGVq4lQzd5nfGsBZSrxa00dyukPFsF";

            var options = new ProductListOptions
            {
                Limit = 3,
            };
            var service = new ProductService();
            StripeList<Product> products = service.List(
              options
            );
            return Ok(products);
        }
    }
}