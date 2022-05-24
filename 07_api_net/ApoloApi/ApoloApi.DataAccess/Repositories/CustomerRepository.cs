using ApoloApiDataAccess.contracts.Dto;
using ApoloApiDataAccess.contracts.Repositories;

namespace ApoloApi.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ApoloApiDataAccessContext _context;

        public CustomerRepository(ApoloApiDataAccessContext context)
        {
            _context = context;
        }

        public CustormersDto? GetCustomerById(int customerCode)
        {
            var query =
                from customer in _context.Customers
                where customer.CustomerNumber == customerCode
                select new CustormersDto
                {
                    CustomerNumber = customer.CustomerNumber,
                    CustomerName = customer.CustomerName,
                    ContactLastName = customer.ContactLastName,
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

             return query.FirstOrDefault();
        }

    
    }
}
 