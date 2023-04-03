using Data.Dto_s.User;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public User GetById(int id)
        {
            User? user = _userRepository.GetAll()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return user;
        }

        public MyUserDto? MyUser(string name)
        {
            var users = _userRepository.GetAll().ToList();
            User? user = _userRepository.GetAll()
                .Include(x => x.Photos)
                .Where(x => x.Name == name)
                .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            MyUserDto myUserDto = new MyUserDto
            {
                Id = user.Id,
                Name = user.Name,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                IsPremium = user.IsPremium,
                ProfilePhoto = user.Photos.Where(p => p.IsProfilePicture).Select(p => p.Path).FirstOrDefault(),
                Photos = user.Photos.Where(p => !p.IsProfilePicture).Select(p => p.Path).ToList(),
            };

            myUserDto.ProfilePhoto = CheckProfile(myUserDto.ProfilePhoto);

            return myUserDto;
        }

        public GetUserDto? Get(int id)
        {
            User? user = _userRepository.GetAll()
                .Include(x => x.Photos)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            GetUserDto getUserDto = new GetUserDto
            {
                Id = user.Id,
                Name = user.Name,
                Gender = user.Gender,
                Height = user.Height,
                Localization = user.Localization,
                PhoneNumber = user.PhoneNumber,
                ProfilePhoto = user.Photos.Where(p => p.IsProfilePicture).Select(p => p.Path).FirstOrDefault(),
                Photos = user.Photos.Where(p => !p.IsProfilePicture).Select(p => p.Path).ToList(),
            };

            getUserDto.ProfilePhoto = CheckProfile(getUserDto.ProfilePhoto);

            return getUserDto;
        }

        public string GetUserNameByAccountId(int accountId)
        {
            string? name = _userRepository.GetUserNameByAccountId(accountId);

            return name;
        }

        public int GetUserIdByAccountId(int accountId)
        {
            int id = _userRepository.GetUserIdByAccountId(accountId);

            return id;
        }

        private string CheckProfile(string? path)
        {
            if (String.IsNullOrEmpty(path))
            {
                path = "noProfile.jpg";
            }

            return path;
        }

        public NavUserDto GetNavUserDto(int id)
        {
            User? user = _userRepository.GetAll()
                .Include(x => x.Photos)
                .Where(x => x.AccountId == id)
                .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            NavUserDto navUser = new NavUserDto
            {
                Name = user.Name,
                Email = user.Account.Email,
                ProfilePhoto = user.Photos.Where(p => p.IsProfilePicture).Select(p => p.Path).FirstOrDefault(),
            };

            navUser.ProfilePhoto = CheckProfile(navUser.ProfilePhoto);

            return navUser;
        }

        public MyUserDto? MyUser(int id)
        {
            User? user = _userRepository.GetAll()
                .Include(x => x.Photos)
                .Where(x => x.AccountId == id)
                .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            MyUserDto myUserDto = new MyUserDto
            {
                Id = user.Id,
                Name = user.Name,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                IsPremium = user.IsPremium,
                ProfilePhoto = user.Photos.Where(p => p.IsProfilePicture).Select(p => p.Path).FirstOrDefault(),
                Photos = user.Photos.Where(p => !p.IsProfilePicture).Select(p => p.Path).ToList(),
            };

            myUserDto.ProfilePhoto = CheckProfile(myUserDto.ProfilePhoto);

            return myUserDto;
        }

        public User? GetByAccId(int id)
        {
            User? user = _userRepository.GetAll()
                .Where(x => x.AccountId == id)
                .FirstOrDefault();

            return user;
        }

        public List<User?> GetProfiles(int id)
        {
            List<User> users = _userRepository.GetAll()
                .Where(x => x.AccountId != id).ToList();

            return users;
        }

        public User Add(User user)
        {
            User? newUser = _userRepository.AddAndSaveChanges(user);

            return newUser;
        }
    }
}