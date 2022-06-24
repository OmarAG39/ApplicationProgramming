using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace BP.API
{
    [DependsOn(
        typeof(CorporateCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CorporateApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CorporateApplicationModule).GetAssembly());
        }
    }
}