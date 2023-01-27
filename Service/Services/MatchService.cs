using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Service.Models.Relation;
using Service.Models.Match;

namespace Service.Services
{
    public class MatchService
    {
        private readonly MatchRepository _matchRepository;
        private readonly UserService _userService;
        private readonly RelationService _relationService;
        private readonly RelationUserRepository _relationUserRepository;


        public MatchService(MatchRepository matchRepository,UserService userService, RelationService relationService, RelationUserRepository relationUserRepository)
        {
            _matchRepository = matchRepository;
            _userService = userService;
            _relationService = relationService;
            _relationUserRepository = relationUserRepository;

        }

        public Match? Get(int id)
        {
            Match? account = _matchRepository.GetById(id);

            return account;
        }

        public List<Match> GetAll()
        {
            List<Match> matches = _matchRepository.GetAll().ToList();

            return matches;
        }
        public Match? GetNextMatchForLoggedUser(int userId,int relID)
        {
           Match? result = _matchRepository.GetNextMatchForLoggedUser1(userId);
            if (result == null) result = _matchRepository.GetNextMatchForLoggedUser2(userId);
            if (result == null)
            {
                Match createNew;   
                User user = _userService.GetById(userId);
                if (_matchRepository.GetValidPerson(userId, relID) == null) return null;
                int idOfValidPerson = _matchRepository.GetValidPerson(userId,relID).Id;
                User user2 = _matchRepository.GetValidPerson(userId,relID);
                int matchID = GetAll().Count;
                Relation relation = _relationService.GetById(relID);
                Status status = new Status
                {
                Id = 5,
                Name = "undefined"
                };
                createNew = new Match
                {
                    Id = matchID,
                    FirstUserId = userId,
                    FirstUser = user,
                    SecondUserId = idOfValidPerson,
                    SecondUser = user2,
                    RelationId = relID,
                    Relation = relation,
                    StatusId = 5,
                    Status = status,
                    Date = DateTime.Now
                };
                _matchRepository.Add(createNew);
                return createNew;
            }
            return result;
        }
        public MatchViewModel GetMatchViewModel (Match match, int userID)
        {
            if (match.FirstUserId == userID) return new MatchViewModel(null, match.SecondUser);
            return new MatchViewModel(null, match.FirstUser);
        }
        public Match Add(Match match)
        {
            Match? newAccount = _matchRepository.Add(match);

            return newAccount;
        }

        public void Update(Match match, bool swipe, int userID)
        {
            if (swipe == false) match.StatusId = 4;
            else if (swipe && match.StatusId == 5 && userID == match.FirstUserId) match.StatusId = 2;
            else if (swipe && match.StatusId == 5 && userID == match.SecondUserId) match.StatusId = 3;
            else if (swipe && match.StatusId == 2 && userID == match.SecondUserId) match.StatusId = 1;
            else if (swipe && match.StatusId == 3 && userID == match.FirstUserId) match.StatusId = 1;
            _matchRepository.UpdateAndSaveChanges(match);
        }
    }
}