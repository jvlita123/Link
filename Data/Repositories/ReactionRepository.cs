using Api.Data;
using Data.Entities;

namespace Data.Repositories
{
    public class ReactionRepository : BaseRepository<Reaction>
    {
        private DataContext _dataContext;

        public ReactionRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }
    }
}