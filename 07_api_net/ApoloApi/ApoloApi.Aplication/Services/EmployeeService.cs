using ApoloApi.Aplication.Mappers;
using ApoloApi.Application.contracts.Services;
using ApoloApi.BusinessModels.Models.Employee;
using ApoloApiDataAccess.contracts;
using ApoloApiDataAccess.contracts.Dto;
using ApoloApiDataAccess.contracts.Repositories;

namespace ApoloApi.Aplication.Services
{
    public class EmployeeService : IEmployeeServcice
    {
        private IEployeeRepository _employeeRepository;
        private IUnitOfWork _uOw;

        public EmployeeService(IEployeeRepository employeeRepository,
                               IUnitOfWork uOw)
        {
            _employeeRepository = employeeRepository;
            _uOw = uOw;
        }


        public EmployeeResponse UpdateEmployee(int number, EmployeeUpdatedRequest employee)
        {
            if (number == 0)
                return new EmployeeResponse { Error = "el id del empleado no puede ser 0" };

            if (string.IsNullOrEmpty(employee.FirstName)
             || string.IsNullOrEmpty(employee.LastName)
             || string.IsNullOrEmpty(employee.OfficeCode)
             || string.IsNullOrEmpty(employee.Extension)
             || string.IsNullOrEmpty(employee.Email)
             || string.IsNullOrEmpty(employee.JobTitle))
                return new EmployeeResponse { Error = "Los campos obligatorios del empleado deben de ir infordos" };


            EmployeeDto existingEmployee = _employeeRepository.GetEmployeeBynumber(number);
            if (existingEmployee == null)
                return new EmployeeResponse { Error = "El empleaso no existe en bbdd" };

            if(employee.ReportsTo.HasValue)
            {
                EmployeeDto existingBoos = _employeeRepository.GetEmployeeBynumber(employee.ReportsTo.Value);

                if (existingBoos == null)
                    return new EmployeeResponse { Error = "El jefe indicaod no exite en bbdd" };
            }
            EmployeeDto employeToUpdate = EmployeeMapper.MapEmployeeDto(number, employee);

            EmployeeDto employeUpdatd=  _employeeRepository.UpdatedEmployed(employeToUpdate);
 
            _uOw.Commit();

            EmployeeResponse result = EmployeeMapper.MaptEmployeeDto(employeUpdatd);

            return result;
        }
    }
}
 