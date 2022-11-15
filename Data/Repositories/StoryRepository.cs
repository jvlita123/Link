using Api.Data;
using Data.Entities;

namespace Data.Repositories
{
    public class StoryRepository : BaseRepository<Story>
    {
        private DataContext _dataContext;

        public StoryRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }
    }
}