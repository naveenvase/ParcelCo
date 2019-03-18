using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace XUnitTest
{
    public class ParcelTests : IClassFixture<DbFixture>
    {
        private readonly ServiceProvider serviceProvider;

        public ParcelTests(DbFixture fixture)
        {
            serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void CalculateWithSmallPackageInput()
        {

        }
        [Fact]
        public void CalculateWithSmallPackageInValidWeight()
        {

        }

        [Fact]
        public void CalculateWithMediumPackageInput()
        {

        }

        [Fact]
        public void CalculateWithMediumPackageInValidWeight()
        {

        }

        [Fact]
        public void CalculateWithLaregePackageInput()
        {

        }

        [Fact]
        public void CalculateWithLargePackageInValidWeight()
        {

        }
    }
}
