using ApoloApi.Application.contracts.Services;
using ApoloApi.BusinessModels.Models.Customer;
using ApoloApiDataAccess.contracts;
using ApoloApiDataAccess.contracts.Dto;
using ApoloApiDataAccess.contracts.Repositories;

namespace ApoloApi.Aplication.Services
{
    public class CustomerService : ICustomerService
    {

        private ICustomerRepository _CostumerRepository; 
        private IUnitOfWork _uOw;


        public CustomerService(ICustomerRepository costumerRepository, IUnitOfWork uOw)
        {
            _CostumerRepository = costumerRepository;
            _uOw = uOw;
        }

        public CustomerResponse? GetCustomerResponse(string name)
        {
            CustormersDto? customer = _CostumerRepository.GetCustomerByName(name);
            CustomerResponse result = new CustomerResponse();
            if (customer != null)
            {
                result.Bussines = customer.CustomerName;
                result.Name = customer.ContactFirstName;
                result.Phone = customer.Phone;
                result.Country = customer.Country;

            }
            else return null;

            return result;
        }


        public CustomerResponse? AddCustomer(CustomerRequest customer)
        {
            CustormersDto newCustomer = new CustormersDto
            {
                CustomerNumber = customer.Number,
                CustomerName = customer.Client,
                ContactLastName = customer.ContactLasName,
                ContactFirstName = customer.ContactFirstName,
                Phone = customer.Phone,
                AddressLine1 = customer.AddressLine1,
                AddressLine2 = customer.AddressLine2,
                City = customer.City,
                State = customer.State,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                SalesRepEmployeeNumber = customer.SalesRepEmployeeNumber,

            };

            var customerInserted = _CostumerRepository.AddCustomer(newCustomer);
            _uOw.Commit();

            CustomerResponse result = new CustomerResponse
            {
                Bussines = customerInserted.CustomerName,
                Name = customerInserted.ContactFirstName,
                Country = customerInserted.Country,
                Phone = customerInserted.Phone
                 

            };

            return result;
        }


    }
}



