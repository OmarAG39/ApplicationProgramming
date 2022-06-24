using Abp.Modules;
using Abp.Reflection.Extensions;
using BP.API.Localization;

namespace BP.API
{
    public class CorporateCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            CorporateLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CorporateCoreModule).GetAssembly());
        }
    }
}