using Api.Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RelationUserRepository : BaseRepository<RelationUser>
    {
        private DataContext _dataContext;

        public RelationUserRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }

        public IQueryable<RelationUser> GetAllByRelationType(int userId, string relationType)
        {
            var result = _dataContext.RelationUsers.Include(ru => ru.Relation)
                .Where(ru => ru.UserId == userId)
               .Distinct();

            return result;
        }
        public IQueryable<RelationUser> GetAllByRelationID(int userId,int relationID)
        {
            var result = _dataContext.RelationUsers.Include(ru => ru.Relation)
                .Where(ru => ru.UserId != userId)
                .Where(ru => ru.RelationId == relationID).Distinct();
            return result;
        }

    }
}