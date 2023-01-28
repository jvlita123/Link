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
                Match createNew;   
            //    User user = _userRepository.GetById(userId);
              
                int? idOfValidPerson = _matchRepository.GetValidPerson(userId,relID);
                if (idOfValidPerson == null) return null;
                //      User user2 = _userRepository.GetById((int)idOfValidPerson);
                //      Relation relation = _relationService.GetById(relID);
                //  Status status = new Status
                //   {
                //   Id = 5,
                //    Name = "undefined"
                //  };
                createNew = new Match
                {
                   
                    FirstUserId = userId,
                    //    FirstUser = user,
                    SecondUserId = (int)idOfValidPerson,
                    //     SecondUser = user2,
                    RelationId = relID,
                    //    Relation = relation,
                    StatusId = 5,
                    //    Status = status,
                    Date = DateTime.Today
                };
                _matchRepository.AddAndSaveChanges(createNew);
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