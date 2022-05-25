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
        [Route("{name}")]
        public IActionResult GetCustomerByName(string name)
        {
            CustomerResponse? customer = _icustomerService.GetCustomerResponse(name);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerRequest customer)
        {
            CustomerResponse? newCustomer = _icustomerService.AddCustomer(customer);
            return Ok(newCustomer);
        }
    }
}
