using ApoloApiDataAccess.contracts.Dto;

namespace ApoloApiDataAccess.contracts.Repositories
{
     public interface ICustomerRepository
    {
        

        CustormersDto? GetCustomerById(int code);

        CustormersDto? AddCustomer(CustormersDto customer);

  


    }
}
