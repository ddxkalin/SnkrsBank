namespace SnkrsBank.Domain.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SnkrsBank.Domain.Common.Models;
    using SnkrsBank.Domain.Models;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    public class SnkrsBankDbContext : IdentityDbContext<User, UserRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(SnkrsBankDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public SnkrsBankDbContext(DbContextOptions<SnkrsBankDbContext> options)
            : base(options)
        {
            //Configuration.ProxyCreationEnabled = true;
        }

        //DbSets
        public DbSet<Setting> Settings { get; set; }

        public DbSet<Sneaker> Sneakers { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<SalePost> SalePosts { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SalePost> Posts { get; set; }

        public DbSet<Category> SneakerCategories { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            ConfigureRatingRelations(builder);
            ConfigureUserIdentityRelations(builder);
            ConfigureConstraints(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        private static void ConfigureConstraints(ModelBuilder builder)
        {
            builder.Entity<Sneaker>()
                .HasIndex(u => u.Slug)
                .IsUnique();

            builder.Entity<Category>()
                .HasIndex(u => u.Slug)
                .IsUnique();
        }

        private static void ConfigureUserIdentityRelations(ModelBuilder builder)
        {
            #region User

            builder.Entity<User>()
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region UserWishlist

            builder.Entity<UserWishlist>()
                .HasKey(uw => new { uw.UserId, uw.SneakerId });

            builder.Entity<UserWishlist>()
                .HasOne(uw => uw.Sneaker)
                .WithMany(p => p.UserWishlists)
                .HasForeignKey(uw => uw.SneakerId);

            builder.Entity<UserWishlist>()
                .HasOne(uw => uw.User)
                .WithMany(c => c.UserWishlists)
                .HasForeignKey(pc => pc.UserId);

            #endregion

            #region UserOwnedSneaker

            builder.Entity<UserOwnedSneaker>()
               .HasKey(uw => new { uw.UserId, uw.SneakerId });

            builder.Entity<UserOwnedSneaker>()
                .HasOne(uw => uw.Sneaker)
                .WithMany(p => p.UserOwnedSneaker)
                .HasForeignKey(uw => uw.SneakerId);

            builder.Entity<UserOwnedSneaker>()
                .HasOne(uw => uw.User)
                .WithMany(c => c.UserOwnedSneaker)
                .HasForeignKey(pc => pc.UserId);

            #endregion

            #region UserWatchedSneaker

            builder.Entity<UserWatchedSneaker>()
                .HasKey(uw => new { uw.UserId, uw.SneakerId });

            builder.Entity<UserWatchedSneaker>()
                .HasOne(uw => uw.Sneaker)
                .WithMany(p => p.UserWatchedSneaker)
                .HasForeignKey(uw => uw.SneakerId);

            builder.Entity<UserWatchedSneaker>()
                .HasOne(uw => uw.User)
                .WithMany(c => c.UserWatchedSneaker)
                .HasForeignKey(pc => pc.UserId);

            #endregion

            #region EventParticipant

            builder.Entity<EventParticipant>()
                .HasKey(bc => new { bc.UserId, bc.EventId });

            builder.Entity<EventParticipant>()
                .HasOne(bc => bc.Participant)
                .WithMany(b => b.Events)
                .HasForeignKey(bc => bc.EventId);

            builder.Entity<EventParticipant>()
                .HasOne(bc => bc.Event)
                .WithMany(c => c.Participants)
                .HasForeignKey(bc => bc.UserId);
            #endregion

            #region SneakerCategory

            builder.Entity<SneakerCategory>()
                .HasKey(bc => new { bc.SneakerId, bc.CategoryId });

            builder.Entity<SneakerCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(b => b.SneakersList)
                .HasForeignKey(bc => bc.CategoryId);

            builder.Entity<SneakerCategory>()
                .HasOne(bc => bc.Sneaker)
                .WithMany(c => c.SneakerCategories)
                .HasForeignKey(bc => bc.SneakerId);
            #endregion
        }

        private static void ConfigureRatingRelations(ModelBuilder builder)
        {
            builder.Entity<UserRating>()
                .HasKey(uw => new { uw.UserId, uw.RatingId });

            builder.Entity<UserRating>()
                .HasOne(uw => uw.User)
                .WithMany(p => p.UserRatings)
                .HasForeignKey(uw => uw.UserId);

            builder.Entity<UserRating>()
                .HasOne(uw => uw.Rating)
                .WithMany(c => c.UserRatings)
                .HasForeignKey(pc => pc.RatingId);

            builder.Entity<SneakerRating>()
                .HasKey(uw => new { uw.RatingId, uw.SneakerId });

            builder.Entity<SneakerRating>()
                .HasOne(uw => uw.Sneaker)
                .WithMany(p => p.SneakerRatings)
                .HasForeignKey(uw => uw.SneakerId);

            builder.Entity<SneakerRating>()
                .HasOne(uw => uw.Rating)
                .WithMany(c => c.SneakerRatings)
                .HasForeignKey(pc => pc.RatingId);
        }


        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
