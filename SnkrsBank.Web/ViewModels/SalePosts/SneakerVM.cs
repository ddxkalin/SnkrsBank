namespace SnkrsBank.Web.ViewModels.SalePosts
{
    using System;
    using System.Collections.Generic;

    public class SneakerVM
    {
        public string Name { get; set; }

        public List<SneakerCategoryVM> Categories { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Brand { get; set; }

        public string Description { get; set; }

        public string PosterImageLink { get; set; }

        public string PosterImageRelativeLink { get; set; }

        public int Size { get; set; }

        public string Condition { get; set; }

        public List<SneakerRatingVM> Ratings { get; set; }

        public double OverallRating { get; set; }

        public double GivenUserRating { get; set; }

        public bool IsInWishlist { get; set; }

        public List<UserWishlistVM> UserWishlists { get; set; }

        public List<SneakerKeywordVM> Keywords { get; set; }
    }
}
