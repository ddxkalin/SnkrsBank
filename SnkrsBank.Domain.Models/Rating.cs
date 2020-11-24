namespace SnkrsBank.Domain.Models
{
    using SnkrsBank.Domain.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Rating : BaseDeletableModel<string>
    {
        public Rating()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public User RatedBy { get; set; }

        public string RatedById { get; set; }

        public DateTime RatedOn { get; set; }

        [Range(1, 5)]
        public double Score { get; set; }

        public virtual ICollection<UserRating> UserRatings { get; set; } = new HashSet<UserRating>();

        public virtual ICollection<SneakerRating> SneakerRatings { get; set; } = new HashSet<SneakerRating>();
    }
}
