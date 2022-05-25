using ApoloApi.Application.contracts.Services;
using ApoloApi.BusinessModels.Models.Customer;
using ApoloApiDataAccess.contracts.Dto;
using ApoloApiDataAccess.contracts.Repositories;

namespace ApoloApi.Aplication.Services
{
    public class CustomerService : ICustomerService
    {

        private ICustomerRepository _CostumerRepository;

        public CustomerService(ICustomerRepository costumerRepository)
        {
            _CostumerRepository = costumerRepository;
        }




    
        public CustomerResponse? GetCustomerResponse(string name)
        {
            CustormersDto? customer = _CostumerRepository.GetCustomerByName(name);
            CustomerResponse result = new CustomerResponse();
            if (customer != null)
            {
                result.Bussines = customer.CustomerName;
                result.Name = customer.ContactFirstName;
                result.Phone = customer.CustomerNumber;
                result.Country = customer.Country;
            }
            else return null;

            return result;
        }
       
    }
}



