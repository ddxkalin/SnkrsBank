using SnkrsBank.Web.App_Start;

namespace SnkrsBank.Web.ViewModels.Base
{
    public class PaginatedWithMappingVM<T> : IMapFrom<T>
    {
        public int CurrentPage { get; set; }

        public int NextPage { get; set; }

        public int PreviousPage { get; set; }

        public int TotalPages { get; set; }

        public bool ShowPagination { get; set; }
    }
}