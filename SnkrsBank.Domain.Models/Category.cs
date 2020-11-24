namespace SnkrsBank.Domain.Models
{
    using SnkrsBank.Domain.Common.Models;
    using System.Collections.Generic;

    public class Category : BaseDeletableModel<string>
    {
        public string Slug { get; set; }

        public virtual ICollection<SneakerCategory> SneakersList { get; set; }
    }
}