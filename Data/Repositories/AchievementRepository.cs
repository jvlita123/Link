using Api.Data;
using Data.Entities;

namespace Data.Repositories
{
    public class AchievementRepository : BaseRepository<Achievement>
    {
        private DataContext _dataContext;

        public AchievementRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }
    }
}