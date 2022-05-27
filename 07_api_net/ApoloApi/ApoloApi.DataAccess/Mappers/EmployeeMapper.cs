using ApoloApi.DataAccess.Entidades;
using ApoloApiDataAccess.contracts.Dto;

namespace ApoloApi.DataAccess.Mappers
{
    public static class EmployeeMapper
    {
        public static Employee MapToEmployee(EmployeeDto employeeDto)
        {
            Employee result = new Employee
            {
                Email = employeeDto.Email,
                EmployeeNumber = employeeDto.EmployeeNumber,
                Extension = employeeDto.Extension,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                JobTitle = employeeDto.JobTitle,
                OfficeCode = employeeDto.OfficeCode,
                ReportsTo = employeeDto.ReportsTo,
            };
            return result;
        }

        public static EmployeeDto MaToEmployeeDto(Employee employee)
        {
            EmployeeDto result = new EmployeeDto
            {
                Email = employee.Email,
                EmployeeNumber = employee.EmployeeNumber,
                Extension = employee.Extension,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                JobTitle = employee.JobTitle,
                OfficeCode = employee.OfficeCode,
                ReportsTo = employee.ReportsTo,
            };
            return result;
        } 
    }
}
