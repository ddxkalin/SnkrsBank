namespace SnkrsBank.Services.Contracts
{
    using SnkrsBank.Domain.Common.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICrudService<T> where T : BaseDeletableModel<string>
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAllWithDeleted();

        Task<T> Get(string id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task<bool> Delete(string id);

        Task<bool> Delete(IQueryable<T> id);

        Task<bool> Restore(string id);

        Task<bool> Restore(IQueryable<T> id);

    }
}
