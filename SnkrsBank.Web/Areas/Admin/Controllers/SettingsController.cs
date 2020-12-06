namespace SnkrsBank.Web.Areas.Admin.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;

    using SnkrsBank.Domain.Common.Repositories;
    using SnkrsBank.Domain.Models;
    using SnkrsBank.Web.Areas.Admin.Controllers.Base;
    using SnkrsBank.Web.Areas.Admin.ViewModels.Settings;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SettingsController : BaseController
    {
        private readonly IDeletableEntityRepository<Setting> repository;

        public SettingsController(IDeletableEntityRepository<Setting> repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<Setting, SettingsViewModel>().ReverseMap());

            var settings = this.repository.All().ProjectTo<SettingsViewModel>(configuration).ToList();
            var model = new SettingsListViewModel { Settings = settings };

            return this.View(model);
        }

        public async Task<IActionResult> InsertSetting()
        {
            var random = new Random();
            var setting = new Setting { Name = $"Name_{random.Next()}", Value = $"Value_{random.Next()}" };
            this.repository.Add(setting);

            await this.repository.SaveChangesAsync();

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
