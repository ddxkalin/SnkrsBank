namespace SnkrsBank.Services.Contracts
{
    using SnkrsBank.Domain.Models;
    using System.Threading.Tasks;

    public interface ISneakerService : ICrudService<Sneaker>
    {
        Task<bool> AddRating(Sneaker entity, string sneakerRatingId);

        Task<bool> AddKeyword(Sneaker entity, string keywordId);
    }
}
