using Api.Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

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
        public int? GetValidPerson(int userId, int relID)
        {
            var GetAllByRelationID = _relationUserRepository.GetAllByRelationID(userId, relID); // Wybacz Eryk, ale nie umiałem poprawić czytelności tego bez rozwalania tego sql XD, funkcja sprawdza czy istnieje osoba, która szuka tego samego typu relacji i jeszcze sie z Tobą nie matchowała
            var result = GetAllByRelationID.Where(x => !GetAllMatchesForAUser(userId).Where(y => (y.FirstUserId == x.UserId || y.SecondUserId == x.UserId) && (y.RelationId == x.RelationId)).Any()).FirstOrDefault();
           if(result!=null)  return result.UserId;
            return null;
        }

        public Match GetNextMatchForLoggedUser1(int userId)
        {
            var result = _dataContext.Matches.Where(m => m.FirstUserId == userId && (m.StatusId != 4 && m.StatusId != 1 &&m.StatusId!=3)).FirstOrDefault(); // No reject, didnt match already, didnt like that person already (in order)

            return result;
        }
        public Match GetMatchForSpecifiedUser(int myuserId,int specifiedUserId, int relID)
        {
            var result = _dataContext.Matches.Where(m => (m.FirstUserId == myuserId && m.SecondUserId == specifiedUserId || m.FirstUserId == specifiedUserId && m.SecondUserId == myuserId) && m.RelationId == relID).FirstOrDefault();
            return result;
        }
        public Match GetNextMatchForLoggedUser2(int userId)
        {
            var result = _dataContext.Matches.Where(m => m.SecondUserId == userId && (m.StatusId == 3 || m.StatusId == 5)).FirstOrDefault(); // same as above just in different manner, cost is actually really similar if u optimize order of and statements, was too lazy to run calculations
            return result;
        }
        public IQueryable<Match> GetAllMatchesForAUser(int userId)
        {
            var result = _dataContext.Matches.Where(m => m.FirstUserId == userId || (m.SecondUserId == userId));
            return result;
        }
    }
}