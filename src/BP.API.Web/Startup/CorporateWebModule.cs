using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BP.API.Configuration;
using BP.API.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace BP.API.Web.Startup
{
    [DependsOn(
        typeof(CorporateApplicationModule), 
        typeof(CorporateEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class CorporateWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public CorporateWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(CorporateConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<CorporateNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(CorporateApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CorporateWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(CorporateWebModule).Assembly);
        }
    }
}