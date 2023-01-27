using Data.Entities;
using Data.Repositories;

namespace Service.Services
{
    public class RelationService
    {
        private readonly RelationRepository _relationRepository;

        public RelationService(RelationRepository relationRepository)
        {
            _relationRepository = relationRepository;
        }

<<<<<<< Updated upstream
=======
        public Relation GetByName(string name)
        {
            Relation relation = _relationRepository.GetByName(name);

            return relation;
        }
        public Relation GetById(int id)
        {
            Relation relation = _relationRepository.GetById(id);

            return relation;
        }
>>>>>>> Stashed changes
        public List<Relation> GetAll()
        {
            List<Relation> relations = _relationRepository.GetAll().ToList();

            return relations;
        }
    }
}