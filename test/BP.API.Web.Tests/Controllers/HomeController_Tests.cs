using System.Threading.Tasks;
using BP.API.Web.Controllers;
using Shouldly;
using Xunit;

namespace BP.API.Web.Tests.Controllers
{
    public class HomeController_Tests: CorporateWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
