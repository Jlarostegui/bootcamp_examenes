using ApoloApi.BusinessModels.Models.Employee;

namespace ApoloApi.Application.contracts.Services
{
    public interface IEmployeeServcice
    {
        EmployeeResponse UpdateEmployee(int number, EmployeeUpdatedRequest employee);
    }
}
