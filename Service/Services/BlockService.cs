using Data.Entities;
using Data.Repositories;

namespace Service.Services
{
    public class BlockService
    {
        private readonly BlockRepository _blockRepository;
        private readonly UserRepository _userRepository;
        private readonly EmployeeRepository _employeeRepository;

        public BlockService(BlockRepository blockRepository, UserRepository userRepository, EmployeeRepository employeeRepository)
        {
            _blockRepository = blockRepository;
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
        }

        public List<Block> GetAll()
        {
            List<Block> blocks = _blockRepository.GetAll().ToList();

            return blocks;
        }

        public Block Add(Block block)
        {
            Block? newBlock = _blockRepository.AddAndSaveChanges(block);

            return newBlock;
        }

        public void Update(Block block)
        {
            _blockRepository.UpdateAndSaveChanges(block);
        }

        public Block? AddNewBlock(int userId, int blockedUserId)
        {
            User blockedUser = _userRepository.GetById(blockedUserId);
            User? user = _userRepository.GetById(userId);

            if (_employeeRepository.GetById(userId) != null)
            {
                var newBlock = new Block()
                {
                    UserId = userId,
                    BlockedUserId = blockedUserId,
                    BlockedUser = _userRepository.GetById(blockedUserId),
                 //   User = _userRepository.GetById(userId),
                };

                blockedUser.IsBlock = true;
                _blockRepository.AddAndSaveChanges(newBlock);

                return newBlock;
            }

            else if (blockedUser != null && user != null && blockedUserId != userId && (_blockRepository.GetAll().Where(x => x.UserId == userId && x.BlockedUserId == blockedUserId).FirstOrDefault()) == null)
            {
                var newBlock = new Block()
                {
                    UserId = userId,
                    BlockedUserId = blockedUserId,
                    BlockedUser = _userRepository.GetById(blockedUserId),
                    User = _userRepository.GetById(userId),
                };

                _blockRepository.AddAndSaveChanges(newBlock);
                user.Blocks = _blockRepository.GetAll().Where(x => x.UserId == user.Id).ToList();
                _userRepository.UpdateAndSaveChanges(user);

                return newBlock;
            }
            else
            {
                return null;
            }
        }

        public void Unblock(int userId, int blockedUserId)
        {
            User blockedUser = _userRepository.GetById(blockedUserId);
            User user = _userRepository.GetById(userId);
            Block block = _blockRepository.GetAll().Where(x => x.UserId == userId && x.BlockedUserId == blockedUserId).FirstOrDefault();

            if (block != null)
            {
                _blockRepository.RemoveById(block.Id);
                _blockRepository.SaveChanges();

                user.Blocks = _blockRepository.GetAll().Where(x => x.UserId == user.Id).ToList();
                _userRepository.UpdateAndSaveChanges(user);
            }
        }

        public List<Block?> GetUserBlocksList(int id)
        {
            List<Block> blocks = _blockRepository.GetAll().Where(x => x.UserId == id).ToList();
            return blocks;
        }
    }
}