namespace SnkrsBank.Web.Controllers.Base
{
    using SnkrsBank.Web.ViewModels;
    using System;
    using System.Linq;

    public class EntityListController : BaseController
    {
        protected IQueryable<T> PaginateList<T>(PaginationVM pagination, IQueryable<T> query)
        {
            var skip = (pagination.Page - 1) * pagination.PageSize;
            var take = pagination.PageSize;

            return query.Skip(skip).Take(take);
        }

        protected int GetTotalPages(int pageSize, int entityCount)
        {
            var totalPages = (int)Math.Ceiling(decimal.Divide(entityCount, pageSize));

            return totalPages;
        }

        protected PaginationVM GetCurrentPagination()
        {
            PaginationVM pagination = new PaginationVM
            {
                Page = !string.IsNullOrWhiteSpace(this.Request.Query["page"]) ? int.Parse(this.Request.Query["page"]) : 1,
                PageSize = !string.IsNullOrWhiteSpace(this.Request.Query["pageSize"]) ? int.Parse(this.Request.Query["pageSize"]) : 20,
            };

            return pagination;
        }
    }
}