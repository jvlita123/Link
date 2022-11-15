using Data.Entities;
using Data.Repositories;

namespace Service
{
    public class AchievementService
    {
        private readonly AchievementRepository _achievementRepository;

        public AchievementService(AchievementRepository achievementRepository)
        {
            _achievementRepository = achievementRepository;
        }

        public List<Achievement> GetAll()
        {
            List<Achievement>? achievements = _achievementRepository.GetAll().ToList();

            return achievements;
        }
    }
}