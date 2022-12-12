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
                .Where(ru => ru.Preference.Value == relationType);

            return result;
        }
        public IQueryable<RelationUser> GetAllByRelation(int userId, int relationType)
        {
            var result = _dataContext.RelationUsers.Include(ru => ru.Relation)
                .Where(ru => ru.UserId == userId)
                .Where(ru => ru.RelationId == relationType);

            return result;
        }
        public IEnumerable<User> GetUserWithProfiles(int userId)
        {
            return _dataContext.Users
                .Where(u => u.Id != userId)
                .Include(p => p.Photos)
                .ToList();
        }
    }
}