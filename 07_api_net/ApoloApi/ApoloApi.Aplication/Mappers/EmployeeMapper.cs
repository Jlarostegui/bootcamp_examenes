using ApoloApi.BusinessModels.Models.Employee;
using ApoloApiDataAccess.contracts.Dto;

namespace ApoloApi.Aplication.Mappers
{
    public class EmployeeMapper
    {   

        public static EmployeeResponse MaptEmployeeDto (EmployeeDto employee)
        {
            EmployeeResponse result = new EmployeeResponse
            {
                Email = employee.Email,
                EmployeeNumber = employee.EmployeeNumber,
                FirstName = employee.FirstName,
                JobTitle = employee.JobTitle,
                LastName = employee.LastName,
            };
            return result;

        }

        public static EmployeeDto MapEmployeeDto(int number , EmployeeUpdatedRequest employee)
        {
            EmployeeDto result = new EmployeeDto
            {
                Email = employee.Email,
                EmployeeNumber = number,
                Extension = employee.Extension,
                FirstName = employee.FirstName,
                JobTitle = employee.JobTitle,
                LastName = employee.LastName,
                OfficeCode = employee.OfficeCode,
                ReportsTo = employee.ReportsTo,
            };
            return result;
        }

    }
}
