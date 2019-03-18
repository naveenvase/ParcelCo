using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace XUnitTest
{
    public class ParcelTypeTests : IClassFixture<DbFixture>
    {
        private readonly ServiceProvider serviceProvider;

        public ParcelTypeTests(DbFixture fixture)
        {
            serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void ReadJsonFileTest()
        {

        }

        [Fact]
        public void ReadJsonFileWithEmptyFile()
        {

        }

        [Fact]
        public void ReadJsonFileWithInvalidFilePath()
        {

        }

        [Fact]
        public void ReadJsonFileWithInvalidContents()
        {

        }
    }
}
