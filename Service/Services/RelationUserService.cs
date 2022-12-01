using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Service.Services
{
    public class RelationUserService
    {
        private readonly RelationUserRepository _relationUserRepository;

        public RelationUserService(RelationUserRepository relationUserRepository)
        {
            _relationUserRepository = relationUserRepository;
        }

        public void Create(int userId, int relationId, List<int> preferenceIds)
        {
            List<RelationUser> relationUsers = new List<RelationUser>();

            foreach (int preferenceId in preferenceIds)
            {
                relationUsers.Add(new RelationUser
                {
                    UserId = userId,
                    RelationId = relationId,
                    PreferenceId = preferenceId
                });
            }

            _relationUserRepository.AddRange(relationUsers);
            _relationUserRepository.SaveChanges();
        }

        public void Update(int userId, int relationId, List<int> preferenceIds)
        {
            List<RelationUser> userRelations = _relationUserRepository.GetAll()
                .Include(ru => ru.Preference)
                .Where(ru => ru.UserId == userId)
                .Where(ru => ru.RelationId == relationId)
                .ToList();

            for (int i = 0; i < preferenceIds.Count; i++)
            {
                userRelations[i].PreferenceId = preferenceIds[i];
            }

            _relationUserRepository.SaveChanges();
        }
    }
}