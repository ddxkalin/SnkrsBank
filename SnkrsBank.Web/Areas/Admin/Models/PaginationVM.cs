namespace SnkrsBank.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PaginationVM
    {
        [Range(0, int.MaxValue)]
        public int Page { get; set; }

        [Range(1, 40)]
        public int PageSize { get; set; }
    }
}