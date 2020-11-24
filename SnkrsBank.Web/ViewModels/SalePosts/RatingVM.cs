namespace SnkrsBank.Web.ViewModels.SalePosts
{
    using System.ComponentModel.DataAnnotations;

    public class RatingVM /*: IMapFrom<Rating>*/
    {
        [Required(ErrorMessage = "Field is required")]
        public double Score { get; set; }

        public UserVM RatedBy { get; set; }
    }
}
