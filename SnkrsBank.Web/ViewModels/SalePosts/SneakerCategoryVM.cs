namespace SnkrsBank.Web.ViewModels.SalePosts
{
    using System.ComponentModel.DataAnnotations;

    public class SneakerCategoryVM /*: IMapFrom<SneakerCategory>*/
    {
        [Required(ErrorMessage = "Field is required")]
        public string CategoryId { get; set; }

        public CategoryVM Category { get; set; }
    }
}
