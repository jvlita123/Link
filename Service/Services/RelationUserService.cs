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

        public void Create(int userId, int relationId)
        {
            List<RelationUser> relationUsers = new List<RelationUser>();

                relationUsers.Add(new RelationUser
                {
                    UserId = userId,
                    RelationId = relationId,
                });

            _relationUserRepository.AddRange(relationUsers);
            _relationUserRepository.SaveChanges();
        }

        public void Update(int userId, int relationId)
        {
            List<RelationUser> userRelations = _relationUserRepository.GetAll()
                .Where(ru => ru.UserId == userId)
                .Where(ru => ru.RelationId == relationId)
                .ToList();

            _relationUserRepository.SaveChanges();
        }

        public bool IsRelation(int userId, int relationId)
        {
            RelationUser? relationUser = _relationUserRepository.GetAll()
                .Where(ru => ru.UserId == userId)
                .Where(ru =>ru.RelationId == relationId)
                .FirstOrDefault();

            if(relationUser != null) return true; else return false;
        }
    }
}