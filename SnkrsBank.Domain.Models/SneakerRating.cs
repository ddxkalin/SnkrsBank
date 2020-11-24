namespace SnkrsBank.Domain.Models
{
    public class SneakerRating
    {
        public Sneaker Sneaker { get; set; }

        public string SneakerId { get; set; }

        public Rating Rating { get; set; }

        public string RatingId { get; set; }
    }
}