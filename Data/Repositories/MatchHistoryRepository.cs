using Api.Data;
using Data.Entities;

namespace Data.Repositories
{
    public class MatchHistoryRepository : BaseRepository<MatchHistory>
    {
        private DataContext _dataContext;

        public MatchHistoryRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }
    }
}