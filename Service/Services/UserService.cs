using Data.Entities;
using Data.Repositories;

namespace Service.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAll()
        {
            List<User> users = _userRepository.GetAll().ToList();

            return users;
        }
    }
}