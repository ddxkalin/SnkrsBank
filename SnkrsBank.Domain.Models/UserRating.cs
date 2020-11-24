namespace SnkrsBank.Domain.Models
{
    public class UserRating
    {
        public User User { get; set; }

        public string UserId { get; set; }

        public Rating Rating { get; set; }

        public string RatingId { get; set; }
    }
}
