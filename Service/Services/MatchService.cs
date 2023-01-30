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
        private readonly UserRepository _userRepository;
        private readonly RelationService _relationService;
        private readonly RelationUserRepository _relationUserRepository;


        public MatchService(MatchRepository matchRepository,UserRepository userRepository, RelationService relationService, RelationUserRepository relationUserRepository)
        {
            _matchRepository = matchRepository;
            _userRepository = userRepository;
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
                int? idOfValidPerson = _matchRepository.GetValidPerson(userId,relID);
                if (idOfValidPerson == null) return null;
                Match createNew = new Match
                {

                    FirstUserId = userId,
                    SecondUserId = (int)idOfValidPerson,
                    RelationId = relID,
                    StatusId = 5,
                    Date = DateTime.Today
                };
                _matchRepository.AddAndSaveChanges(createNew);
                return createNew;
            }
            return result;
        }
        public MatchViewModel GetMatchViewModel (Match match, int userID)
        {
            if (match.FirstUserId == userID) return new MatchViewModel(null, _userRepository.GetById(match.SecondUserId));
            return new MatchViewModel(null, _userRepository.GetById(match.FirstUserId));
        }
        public Match Add(Match match)
        {
            Match? newAccount = _matchRepository.Add(match);

            return newAccount;
        }

        public void Update(Match match, bool swipe, int userID)
        {
            if (swipe == false) match.StatusId = 4; // 1 = matched, 2 = user1 matched // 3 = user2 matched // 4 = reject // 5 = just created
            else if (match.StatusId == 5 && userID == match.FirstUserId) match.StatusId = 2;
            else if (match.StatusId == 5 && userID == match.SecondUserId) match.StatusId = 3;
            else if (match.StatusId == 2 && userID == match.SecondUserId) match.StatusId = 1;
            else if (match.StatusId == 3 && userID == match.FirstUserId) match.StatusId = 1;
            _matchRepository.UpdateAndSaveChanges(match);
        }
    }
}