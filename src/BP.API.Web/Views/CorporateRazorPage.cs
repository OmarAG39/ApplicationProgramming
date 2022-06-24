using Abp.AspNetCore.Mvc.Views;

namespace BP.API.Web.Views
{
    public abstract class CorporateRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected CorporateRazorPage()
        {
            LocalizationSourceName = CorporateConsts.LocalizationSourceName;
        }
    }
}
