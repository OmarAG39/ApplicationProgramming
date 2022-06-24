using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BP.API.Web.Startup;
namespace BP.API.Web.Tests
{
    [DependsOn(
        typeof(CorporateWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class CorporateWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CorporateWebTestModule).GetAssembly());
        }
    }
}