using Data.Entities;
using Data.Repositories;

namespace Service.Services
{
    public class StoryService
    {
        private readonly StoryRepository _storyRepository;

        public StoryService(StoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public List<Story> GetAll()
        {
            List<Story> stories = _storyRepository.GetAll().ToList();

            return stories;
        }
    }
}