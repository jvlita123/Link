using Api.Data;
using Data.Entities;

namespace Data.Repositories
{
    public class RelationRepository : BaseRepository<Relation>
    {
        private DataContext _dataContext;

        public RelationRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }
<<<<<<< Updated upstream
=======

        public Relation GetByName(string name)
        {
            var result = _dataContext.Relations.Where(r => r.Name == name).FirstOrDefault();

            return result;
        }
        public Relation GetName(int id)
        {
            var result = _dataContext.Relations.Where(r => r.Id == id).FirstOrDefault();

            return result;
        }
>>>>>>> Stashed changes
    }
}