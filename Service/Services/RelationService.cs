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

        public List<Relation> GetAll()
        {
            List<Relation> relations = _relationRepository.GetAll().ToList();

            return relations;
        }
    }
}