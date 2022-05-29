using ApoloApi.DataAccess.Entidades;
using ApoloApi.DataAccess.Mappers;
using ApoloApiDataAccess.contracts.Dto;
using ApoloApiDataAccess.contracts.Repositories;

namespace ApoloApi.DataAccess.Repositories
{
    public class EmployeeRepository: IEployeeRepository
    {
        private ApoloApiDataAccessContext _context;

        public EmployeeRepository(ApoloApiDataAccessContext context)
        {
            _context = context;
        }

        public EmployeeDto? GetEmployeeBynumber(int number)
        {
            var query =

                from e in _context.Employees
                where e.EmployeeNumber == number
                select EmployeeMapper.MapToEmployeeDto(e);
            return query.FirstOrDefault();
        }

        public EmployeeDto AddEmployee(EmployeeDto employee)
        {
            Employee newEmployee = Mappers.EmployeeMapper.MapToEmployee(employee);
            var employeeInserted = _context.Employees.Add(newEmployee);
            EmployeeDto result = EmployeeMapper.MapToEmployeeDto(employeeInserted.Entity);
            return result;
        }

        public void DeletedEmployee(EmployeeDto employee)
        {
            Employee employeeToDelete = EmployeeMapper.MapToEmployee(employee);
            _context.Employees.Remove(employeeToDelete);
        }

        public EmployeeDto UpdatedEmployed(EmployeeDto employee)
        {
            Employee employeeToUpdate = EmployeeMapper.MapToEmployee(employee);
            var employeeUpdated = _context.Employees.Update(employeeToUpdate);
            EmployeeDto result = EmployeeMapper.MapToEmployeeDto(employeeUpdated.Entity);
            return result;
        }
    }
}
