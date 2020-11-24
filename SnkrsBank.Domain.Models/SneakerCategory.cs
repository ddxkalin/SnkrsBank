namespace SnkrsBank.Domain.Models
{
    public class SneakerCategory
    {
        public string SneakerId { get; set; }

        public Sneaker Sneaker { get; set; }

        public Category Category { get; set; }

        public string CategoryId { get; set; }
    }
}