namespace SnkrsBank.Domain.Models
{
    using SnkrsBank.Domain.Common.Models;
    using System;
    using System.Collections.Generic;
    public class Sneaker : BaseDeletableModel<string>
    {
        public Sneaker()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        // It's in BaseDeletableModel
        //public string Name { get; set; }

        public virtual Brand Brand { get; set; }

        public string Description { get; set; }

        public string Condition { get; set; }

        public int Size { get; set; }

        public string PosterImageLink { get; set; }

        public string Colorway { get; set; }

        public int RetailPrice { get; set; }

        public string Slug { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<Keyword> Keywords { get; set; } = new HashSet<Keyword>();

        public virtual ICollection<SneakerCategory> SneakerCategories { get; set; } = new HashSet<SneakerCategory>();

        public virtual ICollection<SneakerRating> SneakerRatings { get; set; } = new HashSet<SneakerRating>();

        public virtual ICollection<UserWishlist> UserWishlists { get; set; } = new HashSet<UserWishlist>();

        public virtual ICollection<UserOwnedSneaker> UserOwnedSneaker { get; set; } = new HashSet<UserOwnedSneaker>();

        public virtual ICollection<UserWatchedSneaker> UserWatchedSneaker { get; set; } = new HashSet<UserWatchedSneaker>();
    }
}
