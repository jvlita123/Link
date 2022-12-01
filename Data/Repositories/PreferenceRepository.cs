using Api.Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Data.Repositories
{
    public class PreferenceRepository : BaseRepository<Preference>
    {
        private DataContext _dataContext;

        public PreferenceRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }

        public IQueryable<Preference> GetAllByType(string type)
        {
            var result = _dataContext.Preferences.Where(p => p.Type == type);

            return result;
        }
    }
}