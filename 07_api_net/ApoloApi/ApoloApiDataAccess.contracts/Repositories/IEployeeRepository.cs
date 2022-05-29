using ApoloApiDataAccess.contracts.Dto;

namespace ApoloApiDataAccess.contracts.Repositories
{
    public interface IEployeeRepository
    {
        EmployeeDto? GetEmployeeBynumber(int number);
        EmployeeDto AddEmployee(EmployeeDto employee);
        void DeletedEmployee(EmployeeDto employee);
        EmployeeDto UpdatedEmployed(EmployeeDto employee);

    }
}
