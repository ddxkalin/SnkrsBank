namespace SnkrsBank.Domain.Models
{
    using Microsoft.AspNetCore.Identity;
    using SnkrsBank.Domain.Common.Models;
    using System;
    using System.Collections.Generic;

    public class User : IdentityUser, IDeletableEntity, IAuditInfo
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset EmailConfirmationTokenResentOn { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; } = new HashSet<IdentityUserRole<string>>();

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; } = new HashSet<IdentityUserClaim<string>>();

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; } = new List<IdentityUserLogin<string>>();

        public virtual ICollection<UserWishlist> UserWishlists { get; set; } = new HashSet<UserWishlist>();

        public virtual ICollection<UserOwnedSneaker> UserOwnedSneaker { get; set; } = new HashSet<UserOwnedSneaker>();

        public virtual ICollection<UserWatchedSneaker> UserWatchedSneaker { get; set; } = new HashSet<UserWatchedSneaker>();

        public virtual ICollection<SalePost> Posts { get; set; } = new HashSet<SalePost>();

        public virtual ICollection<EventParticipant> Events { get; set; } = new List<EventParticipant>();

        public virtual ICollection<UserRating> UserRatings { get; set; } = new HashSet<UserRating>();


    }
}
