using SnkrsBank.Domain.Common.Models;
using System;
using System.Collections.Generic;

namespace SnkrsBank.Domain.Models
{

    public class Brand : BaseDeletableModel<string>
    {
        public Brand()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual ICollection<Sneaker> Brands { get; set; }
    }
}