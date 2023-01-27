using Api.Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class MatchRepository : BaseRepository<Match>
    {
        private DataContext _dataContext;
        private readonly RelationUserRepository _relationUserRepository;

        public MatchRepository(DataContext context, RelationUserRepository relationUserRepository) : base(context)
        {
            _dataContext = context;
            _relationUserRepository = relationUserRepository;
        }
        public User? GetValidPerson(int userId, int relID)
        {

            var result = _relationUserRepository.GetAllByRelationID(userId, relID).Where(x => !GetAllMatchesForAUser(userId).Where(y => y.FirstUserId == x.UserId || y.SecondUserId == x.UserId).Any()).FirstOrDefault();
           if(result!=null)  return result.User;
            return null;
        }

        public Match GetNextMatchForLoggedUser1(int userId)
        {
            var result = _dataContext.Matches.Where(m => m.FirstUserId == userId && m.StatusId != 2 && m.StatusId != 4 &&m.StatusId!=1).FirstOrDefault();

            return result;
        }
        public Match GetNextMatchForLoggedUser2(int userId)
        {
            var result = _dataContext.Matches.Where(m => m.SecondUserId == userId && m.StatusId == 2 && m.StatusId == 5).FirstOrDefault();
            return result;
        }
        public IQueryable<Match> GetAllMatchesForAUser(int userId)
        {
            var result = _dataContext.Matches.Where(m => m.FirstUserId == userId || (m.SecondUserId == userId));
            return result;
        }
    }
}