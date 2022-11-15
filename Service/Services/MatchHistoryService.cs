using Data.Entities;
using Data.Repositories;

namespace Service.Services
{
    public class MatchHistoryService
    {
        private readonly MatchHistoryRepository _matchHistoryRepository;

        public MatchHistoryService(MatchHistoryRepository matchHistoryRepository)
        {
            _matchHistoryRepository = matchHistoryRepository;
        }

        public List<MatchHistory> GetAll()
        {
            List<MatchHistory> matchHistories = _matchHistoryRepository.GetAll().ToList();

            return matchHistories;
        }
    }
}