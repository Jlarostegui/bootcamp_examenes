using ApoloApi.Application.contracts.Services;
using ApoloApi.BusinessModels.Models.Customer;
using Microsoft.AspNetCore.Mvc;

namespace ApoloAtm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class CustomersController : Controller
    {

        private ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        [Route("{name}")]
        public IActionResult GetCustomerByName(int name)
        {
            CustomerResponse? customer = _customerService.GetCustomerResponse(name);
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
            CustomerResponse? newCustomer = _customerService.AddCustomer(customer);
            return Ok(newCustomer);
        }


    }
}
