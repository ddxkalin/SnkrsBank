namespace SnkrsBank.Services.Implementation
{
    using SnkrsBank.Domain.Common.Models;
    using SnkrsBank.Domain.Common.Repositories;
    using SnkrsBank.Services.Contracts;

    using System.Linq;
    using System.Threading.Tasks;

    public class CrudService<T> : ICrudService<T>
        where T : BaseDeletableModel<string>
    {
        private IDeletableEntityRepository<T> data;

        public CrudService(IDeletableEntityRepository<T> data)
        {
            this.data = data;
        }

        public IQueryable<T> GetAll()
        {
            var result = this.data.All();

            return result;
        }

        public IQueryable<T> GetAllWithDeleted()
        {
            var result = this.data.All();

            return result;
        }

        public async Task<T> Get(string id)
        {
            var entity = await this.data.GetByIdAsync(id);

            return entity;
        }

        public async Task<T> Create(T entity)
        {
            this.data.Add(entity);
            await this.data.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Update(T entity)
        {
            this.data.Update(entity);
            await this.data.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(string id)
        {
            var entity = await this.data.GetByIdAsync(id);

            if (entity != null)
            {
                this.data.Delete(entity);
                await this.data.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(IQueryable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.data.Delete(entity);
            }

            await this.data.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Restore(string id)
        {
            var entity = await this.data.GetByIdWithDeletedAsync(id);

            if (entity != null)
            {
                this.data.Undelete(entity);
                await this.data.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> Restore(IQueryable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.data.Undelete(entity);
            }

            await this.data.SaveChangesAsync();
            return true;
        }
    }
}
