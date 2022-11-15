using Api.Data;
using Data.Entities;

namespace Data.Repositories
{
    public class RelationRepository : BaseRepository<Relation>
    {
        private DataContext _dataContext;

        public RelationRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }
    }
}