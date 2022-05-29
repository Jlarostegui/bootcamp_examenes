using ApoloApi.DataAccess.Entidades;
using ApoloApiDataAccess.contracts.Dto;

namespace ApoloApi.DataAccess.Mappers
{
    public static class CustomerMapper
    {

        #region MapCUSTOMER
        public static CustormersDto MaptoCustomerDtoFromCustomer(Customer customer)
        {
            CustormersDto result = new CustormersDto
            {
                AddressLine1 = customer.AddressLine1,
                AddressLine2 = customer.AddressLine2,
                City = customer.City,
                FirstName = customer.ContactFirstName,
                LastName = customer.ContactLastName,
                Country = customer.Country,
                CreditLimit = customer.CreditLimit,
                CustomerName = customer.CustomerName,
                CustomerNumber = customer.CustomerNumber,
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                SalesRepEmployeeNumber = customer.SalesRepEmployeeNumber,
                State = customer.State
            };

            return result;  
        }
        #endregion

        #region MapCUSTOMERDTO
        public static Customer MaptoCustomerFromCustomerDto(CustormersDto customerDto)
        {
            Customer result = new Customer
            {
                AddressLine1 = customerDto.AddressLine1,
                AddressLine2 = customerDto.AddressLine2,
                City = customerDto.City,
                ContactFirstName = customerDto.FirstName,
                ContactLastName = customerDto.LastName,
                Country = customerDto.Country,
                CreditLimit = customerDto.CreditLimit,
                CustomerName = customerDto.CustomerName,
                CustomerNumber = customerDto.CustomerNumber,
                Phone = customerDto.Phone,
                PostalCode = customerDto.PostalCode,
                SalesRepEmployeeNumber = customerDto.SalesRepEmployeeNumber,
                State = customerDto.State
            };

            return result;
        }
        #endregion
    }
}
