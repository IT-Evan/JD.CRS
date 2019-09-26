using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JD.CRS.Authorization;

namespace JD.CRS
{
    [DependsOn(
        typeof(CRSCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CRSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CRSAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CRSApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
