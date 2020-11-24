namespace SnkrsBank.Domain.Models
{
    public class EventParticipant
    {
        public string UserId { get; set; }

        public User Participant { get; set; }

        public string EventId { get; set; }

        public Event Event { get; set; }
    }
}