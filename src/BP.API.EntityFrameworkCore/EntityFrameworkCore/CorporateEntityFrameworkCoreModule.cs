using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace BP.API.EntityFrameworkCore
{
    [DependsOn(
        typeof(CorporateCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class CorporateEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CorporateEntityFrameworkCoreModule).GetAssembly());
        }
    }
}