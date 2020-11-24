namespace SnkrsBank.Domain.Models
{
    public class UserWatchedSneaker
    {
        public string SneakerId { get; set; }

        public Sneaker Sneaker { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }
    }
}