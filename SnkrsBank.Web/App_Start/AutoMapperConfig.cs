using AutoMapper;

namespace SnkrsBank.Web.App_Start
{
    using SnkrsBank.Domain.Models;
    using SnkrsBank.Web.ViewModels.SalePosts;
    using SnkrsBank.Web.ViewModels.Settings;
    using System.Reflection;

    public static class AutoMapper
    {
        public static MapperConfiguration MapperConfiguration { get; set; }
        public static IMapper Mapper { get; set; }
    }

    public class AutoMapperConfig
    {
        public static void RegisterMappings(params Assembly[] assemblies)
        {

            if (AutoMapper.MapperConfiguration == null)
            {
                AutoMapper.MapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Setting, SettingViewModel>().ReverseMap();
                    cfg.CreateMap<Setting, SettingsListViewModel>().ReverseMap();
                    cfg.CreateMap<SalePost, PostVM>().ReverseMap();


                });

                AutoMapper.Mapper = AutoMapper.MapperConfiguration.CreateMapper();
            }
        }

    }
}
