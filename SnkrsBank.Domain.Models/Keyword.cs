namespace SnkrsBank.Domain.Models
{
    using SnkrsBank.Domain.Common.Models;
    using System;

    public class Keyword : BaseDeletableModel<string>
    {
        public Keyword()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string SneakerId { get; set; }

        public Sneaker Sneaker { get; set; }
    }
}
