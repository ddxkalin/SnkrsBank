namespace SnkrsBank.Web.Areas.Identity.Pages.Account.Manage.OutputModels
{
    using System.ComponentModel.DataAnnotations;

    public class IndexOutputModel
    {
        public string Email { get; set; }

        [Display(Name = "Member since")]
        public string RegisteredOn { get; set; }
    }
}
