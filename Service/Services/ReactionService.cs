using Data.Entities;
using Data.Repositories;

namespace Service.Services
{
    public class ReactionService
    {
        private readonly ReactionRepository _reactionRepository;

        public ReactionService(ReactionRepository reactiontRepository)
        {
            _reactionRepository = reactiontRepository;
        }

        public List<Reaction> GetAll()
        {
            List<Reaction> reactions = _reactionRepository.GetAll().ToList();

            return reactions;
        }
    }
}