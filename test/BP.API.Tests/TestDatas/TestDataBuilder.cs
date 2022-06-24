using BP.API.EntityFrameworkCore;

namespace BP.API.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly CorporateDbContext _context;

        public TestDataBuilder(CorporateDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}