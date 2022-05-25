using ApoloApi.DataAccess.Entidades;
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

        public CustormersDto? GetCustomerByName(string name)
        {
            var query =
                from customer in _context.Customers
                where customer.CustomerName.Contains(name) 
                select new CustormersDto
                {
                
                };

             return query.FirstOrDefault();
        }
        public CustormersDto AddCustomer(CustormersDto customer)
        {
            Customer newCustomer = new Customer
            {
                CustomerNumber = customer.CustomerNumber,
                CustomerName = customer.ContactLastName,
                ContactLastName = customer.ContactLastName,
                ContactFirstName = customer.ContactFirstName,
                Phone = customer.Phone,
                AddressLine1 = customer.AddressLine1,
                City = customer.City,
                Country = customer.Country,
                SalesRepEmployeeNumber = customer.SalesRepEmployeeNumber

            };

            var customerInserted = _context.Customers.Add(newCustomer);

            CustormersDto result = new CustormersDto
            {
                CustomerNumber = customerInserted.Entity.CustomerNumber,
                CustomerName = customerInserted.Entity.CustomerName,
                ContactLastName = customerInserted.Entity.ContactLastName,
                ContactFirstName = customerInserted.Entity.ContactFirstName,
                Phone = customerInserted.Entity.Phone,
                AddressLine1 = customerInserted.Entity.AddressLine1,
                AddressLine2 = customerInserted.Entity.AddressLine2,
                City = customerInserted.Entity.City,
                State = customerInserted.Entity.State,
                PostalCode = customerInserted.Entity.PostalCode,
                Country = customerInserted.Entity.Country,
                SalesRepEmployeeNumber = customerInserted.Entity.SalesRepEmployeeNumber

            };

            return result;
        }
    }   
}
 