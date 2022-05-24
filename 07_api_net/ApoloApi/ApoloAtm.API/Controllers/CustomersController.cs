using ApoloApi.Application.contracts.Services;
using ApoloApi.BusinessModels.Models.Customer;
using Microsoft.AspNetCore.Mvc;

namespace ApoloAtm.API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]


    public class CustomersController : Controller
    { 

        private ICustomerService _icustomerService;

    public CustomersController(ICustomerService customerService)
    {
            _icustomerService = customerService;
    }

        
        [HttpGet]
        [Route("{code}")]
        public IActionResult GetCustomerById(int code)
        {
            CustomerResponse? customer = _icustomerService.GetCustomerResponse(code);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
