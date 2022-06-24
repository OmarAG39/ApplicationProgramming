using Abp.Application.Services;

namespace BP.API
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class CorporateAppServiceBase : ApplicationService
    {
        protected CorporateAppServiceBase()
        {
            LocalizationSourceName = CorporateConsts.LocalizationSourceName;
        }
    }
}