using Api.Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserAchievementRepository : BaseRepository<UserAchievement>
    {
        private DataContext _dataContext;

        public UserAchievementRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }
    }
}