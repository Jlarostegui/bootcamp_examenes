using ApoloApi.DataAccess.Entidades;
using ApoloApi.DataAccess.Mappers;
using ApoloApiDataAccess.contracts.Dto;
using ApoloApiDataAccess.contracts.Repositories;

namespace ApoloApi.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        #region context
        private ApoloApiDataAccessContext _context;
        public CustomerRepository(ApoloApiDataAccessContext context)
        {
            _context = context;
        }
        #endregion

        #region GET
        public CustormersDto? GetCustomerById(int number)
        {
            var query =
                from customer in _context.Customers
                where customer.CustomerNumber == number
                select CustomerMapper.MaptoCustomerDtoFromCustomer(customer);

            return query.FirstOrDefault();
        }
        #endregion

        #region POST
        public CustormersDto AddCustomer(CustormersDto customer)
        {
            
            Customer newCustomer =CustomerMapper.MaptoCustomerFromCustomerDto(customer);

            var customerInserted = _context.Customers.Add(newCustomer);

            CustormersDto result = CustomerMapper.MaptoCustomerDtoFromCustomer(customerInserted.Entity);


            return result;
        }
        #endregion

        #region PUT 
        public CustormersDto UpdateCustomer(CustormersDto customer)
        {
            Customer customerUpdate = CustomerMapper.MaptoCustomerFromCustomerDto(customer);

            var customerToUpdate =  _context.Customers.Update(customerUpdate);

            CustormersDto result = CustomerMapper.MaptoCustomerDtoFromCustomer(customerToUpdate.Entity);
            return result;
                 

        }
        #endregion

        #region DELETE
        public void DelteCustomer(CustormersDto customer)
        {
            Customer customerToDelete = CustomerMapper.MaptoCustomerFromCustomerDto(customer);
            _context.Customers.Remove(customerToDelete);
        }

        #endregion
    }
}
 