using Data.Dto_s.User;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Service.Services
{
    public class PremiumService
    {
        private readonly UserRepository _userRepository;

        public PremiumService(UserRepository userRepository){
            _userRepository = userRepository;
        }

        public void SetPremium(int userId){
            User? user = _userRepository.GetById(userId);
            user.IsPremium=true;
            _userRepository.UpdateAndSaveChanges(user);
        }
    }
}