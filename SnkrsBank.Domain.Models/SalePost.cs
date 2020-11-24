namespace SnkrsBank.Domain.Models
{
    using SnkrsBank.Domain.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SalePost : BaseDeletableModel<string>
    {
        public SalePost()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public string SneakerId { get; set; }

        [ForeignKey(nameof(SneakerId))]
        public Sneaker Sneaker { get; set; }
    }
}