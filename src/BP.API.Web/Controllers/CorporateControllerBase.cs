using Abp.AspNetCore.Mvc.Controllers;

namespace BP.API.Web.Controllers
{
    public abstract class CorporateControllerBase: AbpController
    {
        protected CorporateControllerBase()
        {
            LocalizationSourceName = CorporateConsts.LocalizationSourceName;
        }
    }
}