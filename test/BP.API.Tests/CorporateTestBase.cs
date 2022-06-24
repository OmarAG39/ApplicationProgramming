using System;
using System.Threading.Tasks;
using Abp.TestBase;
using BP.API.EntityFrameworkCore;
using BP.API.Tests.TestDatas;

namespace BP.API.Tests
{
    public class CorporateTestBase : AbpIntegratedTestBase<CorporateTestModule>
    {
        public CorporateTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<CorporateDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<CorporateDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<CorporateDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<CorporateDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<CorporateDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<CorporateDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<CorporateDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<CorporateDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
