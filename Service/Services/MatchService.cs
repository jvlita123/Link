using Data.Entities;
using Data.Repositories;

namespace Service.Services
{
    public class MatchService
    {
        private readonly MatchRepository _matchRepository;

        public MatchService(MatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
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

        public Match Add(Match match)
        {
            Match? newAccount = _matchRepository.Add(match);

            return newAccount;
        }

        public void Update(Match match)
        {
            _matchRepository.UpdateAndSaveChanges(match);
        }
    }
}