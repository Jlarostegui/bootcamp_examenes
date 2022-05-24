using ApoloApiDataAccess.contracts;

namespace ApoloApi.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApoloApiDataAccessContext _context;
        public UnitOfWork(ApoloApiDataAccessContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
