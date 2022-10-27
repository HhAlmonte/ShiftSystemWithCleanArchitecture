using Microsoft.EntityFrameworkCore;
using ShiftSystem.Infrastructure.Context.Extensions;
using ShiftSystem002.Domain.Base;
using ShiftSystem002.Domain.Entities;

namespace ShiftSystem.Infrastructure.Context
{
    public interface IShiftSystemDbContext : IDisposable
    {
        public DbSet<T> GetDbSet<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class ShiftSystemDbContext : DbContext, IShiftSystemDbContext
    {
        public ShiftSystemDbContext(DbContextOptions<ShiftSystemDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Peoples { get; set; }
        public DbSet<QueueLine> QueueLines { get; set; }
        public DbSet<PersonQueue> PersonQueues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(type.ClrType)){
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
                }
            }
        }
        
        public void SetAuditEntities()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if(entry.State == EntityState.Deleted)
                {
                    entry.Entity.Deleted = true;
                    entry.State = EntityState.Modified;
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<T> GetDbSet<T>() where T : BaseEntity => Set<T>();
    }
}
