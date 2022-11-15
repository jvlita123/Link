using Api.Data;
using Data.Entities;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        private DataContext _dataContext;

        public UserRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }
    }
}