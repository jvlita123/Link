using Data.Entities;
using Data.Repositories;

namespace Service.Services
{
    public class UserAchievementService
    {
        private readonly UserAchievementRepository _userAchievementRepository;

        public UserAchievementService(UserAchievementRepository userAchievementRepository)
        {
            _userAchievementRepository = userAchievementRepository;
        }

        public List<UserAchievement> GetAll()
        {
            List<UserAchievement> userAchievements = _userAchievementRepository.GetAll().ToList();

            return userAchievements;
        }
    }
}