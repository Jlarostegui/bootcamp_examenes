

using ApoloApi.BusinessModels.Models.Customer;
using ApoloApiDataAccess.contracts.Dto;

namespace BootcampAres.Application.Mappers
{
    public static class CustomerMapper
    {
        //CustomerDto -> CustomerResponse
        public static CustomerResponse MapToCustomerResponseFromCustomerDto(CustormersDto customerDto)
        {
            CustomerResponse result = new CustomerResponse
            {
                Name = customerDto.CustomerName,
                CustomerNumber = customerDto.CustomerNumber
            };

            return result;
        }

        //CustomerRequest -> CustomerDto
        public static CustormersDto MapToCustomerDtoFromCustomerRequest(CustomerRequest customerRequest)
        {
            CustormersDto customer = new CustormersDto
            {
                AddressLine1 = customerRequest.AddressLine1,
                AddressLine2 = customerRequest.AddressLine2,
                City = customerRequest.City,
                FirstName = customerRequest.FirstName,
                LastName = customerRequest.LastName,
                Country = customerRequest.Country,
                CreditLimit = customerRequest.CreditLimit,
                CustomerName = customerRequest.Client,
                CustomerNumber = customerRequest.Number,
                Phone = customerRequest.Phone,
                PostalCode = customerRequest.PostalCode,
                SalesRepEmployeeNumber = customerRequest.SalesRepEmployeeNumber,
                State = customerRequest.State
            };

            return customer;
        }
    }
 }
