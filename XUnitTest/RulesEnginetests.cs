using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace XUnitTest
{
    public class RulesEngineTests : IClassFixture<DbFixture>
    {
        private readonly ServiceProvider serviceProvider;

        public RulesEngineTests(DbFixture fixture)
        {
            serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void SmallPackageInput()
        {

        }
        [Fact]
        public void SmallPackageInValidWeight()
        {

        }

        [Fact]
        public void MediumPackageInput()
        {

        }

        [Fact]
        public void MediumPackageInValidWeight()
        {

        }

        [Fact]
        public void LaregePackageInput()
        {

        }

        [Fact]
        public void LargePackageInValidWeight()
        {

        }
    }
}
