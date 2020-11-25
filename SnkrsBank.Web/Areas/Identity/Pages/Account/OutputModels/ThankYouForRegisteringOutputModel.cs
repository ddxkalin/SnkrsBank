namespace SnkrsBank.Web.Areas.Identity.Pages.Account.OutputModels
{

    public class ThankYouForRegisteringOutputModel
    {
        public string UserId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public bool Resent { get; set; } = false;

        public bool SubsequentResend { get; set; } = false;
    }
}