using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        private DbSet<Account> Accounts { get; set; }
        private DbSet<Achievement> Achievements { get; set; }
        private DbSet<Employee> Employees { get; set; }
        private DbSet<Match> Matches { get; set; }
        private DbSet<MatchHistory> MatchHistories { get; set; }
        private DbSet<Message> Messages { get; set; }
        private DbSet<Photo> Photos { get; set; }
        private DbSet<Reaction> Reactions { get; set; }
        private DbSet<Relation> Relations { get; set; }
        private DbSet<Status> Statuses { get; set; }
        private DbSet<Story> Stories { get; set; }
        private DbSet<UserAchievement> UserAchievements { get; set; }
        private DbSet<User> Users { get; set; }

        public void AddEntity<TEntity>(TEntity entity) where TEntity : class, new()
        {
            Set<TEntity>().Add(entity);
        }

        public void AddEntityAndSaveChanges<TEntity>(TEntity entity) where TEntity : class, new()
        {
            AddEntity(entity);
            SaveChanges();
        }

        public void AddEntitiesRange<TEntity>(IEnumerable<TEntity> entity) where TEntity : class, new()
        {
            Set<TEntity>().AddRange(entity);
        }

        public void AddEntitiesRangeAndSaveChanges<TEntity>(IEnumerable<TEntity> entity) where TEntity : class, new()
        {
            AddEntitiesRange(entity);
            SaveChanges();
        }

        public void UpdateEntity<TEntity>(TEntity entity) where TEntity : class, new()
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void UpdateEntitiesRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, new()
        {
            foreach (var entity in entities)
            {
                UpdateEntity(entity);
            }
        }

        public void UpdateEntitiesRangeAndSaveChanges<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, new()
        {
            UpdateEntitiesRange(entities);
            SaveChanges();
        }

        public void RemoveEntity<TEntity>(TEntity entity) where TEntity : class, new()
        {
            Set<TEntity>().Remove(entity);
        }

        public void RemoveEntitiesRange<TEntity>(IEnumerable<TEntity> entity) where TEntity : class, new()
        {
            Set<TEntity>().RemoveRange(entity);
        }

        public void RemoveEntitiesRangeAndSaveChanges<TEntity>(IEnumerable<TEntity> entity) where TEntity : class, new()
        {
            RemoveEntitiesRange(entity);
            SaveChanges();
        }
    }
}