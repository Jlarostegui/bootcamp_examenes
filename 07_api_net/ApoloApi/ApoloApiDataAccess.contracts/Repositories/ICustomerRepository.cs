using ApoloApiDataAccess.contracts.Dto;

namespace ApoloApiDataAccess.contracts.Repositories
{
     public interface ICustomerRepository
    {
        CustormersDto ? GetCustomerByName(string name);
       
    }
}
