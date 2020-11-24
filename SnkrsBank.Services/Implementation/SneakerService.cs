using SnkrsBank.Domain.Models;
using SnkrsBank.Services.Contracts;
using System.Threading.Tasks;

namespace SnkrsBank.Services.Implementation
{
    public class SneakerService  /*CrudService<Sneaker>, ISneakerService*/
    {

        //TODO: FIX RATING AND KEYWORD

        private ISneakerService data;

        public SneakerService(ISneakerService data)
        {
            this.data = data;
        }

        public Task<bool> AddRating(Sneaker entity, string sneakerRatingId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddKeyword(Sneaker entity, string keywordId)
        {
            throw new System.NotImplementedException();
        }
    }
}
