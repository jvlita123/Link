using Api.Data;
using Data.Entities;

namespace Data.Repositories
{
    public class AccountRepository : BaseRepository<Account>
    {
        private DataContext _dataContext;

        public AccountRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }
    }
}