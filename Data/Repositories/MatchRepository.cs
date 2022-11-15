using Api.Data;
using Data.Entities;

namespace Data.Repositories
{
    public class MatchRepository : BaseRepository<Match>
    {
        private DataContext _dataContext;

        public MatchRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }
    }
}