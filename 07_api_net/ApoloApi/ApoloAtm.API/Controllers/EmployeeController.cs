using ApoloApi.Application.contracts.Services;
using ApoloApi.BusinessModels.Models.Employee;
using Microsoft.AspNetCore.Mvc;

namespace ApoloAtm.API.Controllers
{
        [Route("api/[contrpller]")]
        [ApiController]
    public class EmployeeController : Controller
    {
        private IEmployeeServcice _employeeService;

        public EmployeeController (IEmployeeServcice employeeservice)
        {
            _employeeService = employeeservice;
        }
   
          
        public IActionResult UpdatedEmployee(int number, EmployeeUpdatedRequest employee)
        {

            EmployeeResponse employeeUpdated = _employeeService.UpdateEmployee(number, employee);

            if (string.IsNullOrEmpty(employeeUpdated.Error))
                return Ok(employeeUpdated);
            else
                return BadRequest();
        }
    }
}
