namespace SnkrsBank.Web.Areas.Admin.ViewModels.Settings
{
    using SnkrsBank.Domain.Models;
    using SnkrsBank.Web.App_Start;

    public class SettingsViewModel : IMapFrom<Setting>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
