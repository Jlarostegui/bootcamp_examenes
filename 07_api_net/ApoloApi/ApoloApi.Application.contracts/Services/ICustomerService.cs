using ApoloApi.BusinessModels.Models.Customer;

namespace ApoloApi.Application.contracts.Services
{
    public interface ICustomerService

    {
        CustomerResponse ? GetCustomerResponse(int code);
    }
}
