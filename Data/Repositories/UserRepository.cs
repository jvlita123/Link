using Api.Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        private DataContext _dataContext;

        public UserRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }

        public string GetUserNameByAccountId(int accountId)
        {
            var result = _dataContext.Users.Where(u => u.AccountId == accountId).Select(u => u.Name).FirstOrDefault();

            return result;
        }

        public int GetUserIdByAccountId(int accountId)
        {
            var result = _dataContext.Users.Where(u => u.AccountId == accountId).Select(u => u.Id).FirstOrDefault();

            return result;
        }
        
    }
}