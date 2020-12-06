namespace SnkrsBank.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SnkrsBank.Web.Areas.Admin.Controllers.Base;

    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
