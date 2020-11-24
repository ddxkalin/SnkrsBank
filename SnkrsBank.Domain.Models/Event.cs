namespace SnkrsBank.Domain.Models
{
    using SnkrsBank.Domain.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Event : BaseDeletableModel<string>
    {
        public Event()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual ICollection<EventParticipant> Participants { get; set; }

        public string SneakerId { get; set; }

        [ForeignKey(nameof(SneakerId))]
        public Sneaker Sneaker { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }
    }
}