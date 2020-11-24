namespace SnkrsBank.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using SnkrsBank.Domain.Common.Repositories;
    using SnkrsBank.Domain.Models;
    using SnkrsBank.Web.Controllers.Base;
    using SnkrsBank.Web.ViewModels.Settings;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SettingsController : BaseController
    {
        private readonly IDeletableEntityRepository<Setting> repository;
        private readonly IMapper _mapper;

        public SettingsController(IDeletableEntityRepository<Setting> repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var setting = this.repository.All().ToList();   /*GetSettingDetails();*/

            var settingListViewModel = _mapper.Map<SettingsListViewModel>(setting);

            return View(settingListViewModel);
        }

        public async Task<IActionResult> InsertSetting()
        {
            var random = new Random();
            var setting = new Setting { Name = $"Name_{random.Next()}", Value = $"Value_{random.Next()}" };
            this.repository.Add(setting);

            await this.repository.SaveChangesAsync();

            return this.RedirectToAction(nameof(this.Index));
        }


        //TODO 
        //TEST IT, URL NOT WORKING
        private static Setting GetSettingDetails()
        {
            return new Setting
            {
                Name = "Kalin Test",
                Value = "Stoinost"
            };
        }
    }
}