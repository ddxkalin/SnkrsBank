namespace SnkrsBank.Web.ViewModels.SalePosts
{
    using System.ComponentModel.DataAnnotations;

    public class CreatePostVM /*: IMapFrom<SalePost>*/
    {
        [Required]
        public string Name { get; set; }

        public CreateSneakerVM Sneaker { get; set; }
    }
}