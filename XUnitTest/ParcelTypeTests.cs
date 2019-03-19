using Microsoft.Extensions.DependencyInjection;
using Xunit;
using ParcelCo.Parcel.ModelContracts;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        public void ReadJsonFile()
        {
            IParcelType parcelType = serviceProvider.GetService<IParcelType>();
            IEnumerable<IParcelType> parcelTypes = parcelType.ReadFromFile(@"Resources\ParcelTypes.json");

            var result = (from parcel in parcelTypes where parcel.Type == "Medium" select parcel).FirstOrDefault();

            Assert.True(result != null);
        }

        [Fact]
        public void ReadJsonFileWithEmptyFileContents()
        {
            IParcelType parcelType = serviceProvider.GetService<IParcelType>();
            IEnumerable<IParcelType> parcelTypes = parcelType.ReadFromFile(@"Resources\ParcelTypesEmpty.json");

            Assert.True(parcelTypes == null);
        }

        [Fact]
        public void ReadJsonFileWithInvalidFilePath()
        {
            IParcelType parcelType = serviceProvider.GetService<IParcelType>();

            Assert.Throws<DirectoryNotFoundException>(() => parcelType.ReadFromFile(@"Resources2\ParcelTypesEmpty.json"));
        }

        [Fact]
        public void ReadJsonFileWithNoRecords()
        {
            IParcelType parcelType = serviceProvider.GetService<IParcelType>();
            IEnumerable<IParcelType> parcelTypes = parcelType.ReadFromFile(@"Resources\ParcelTypesNoRecords.json");

            Assert.True(parcelTypes != null && parcelTypes.Count() == 0 );
        }

        [Fact]
        public void ReadJsonFileWithInvalidContents()
        {
            IParcelType parcelType = serviceProvider.GetService<IParcelType>();
            IEnumerable<IParcelType> parcelTypes = parcelType.ReadFromFile(@"Resources\ParcelTypesInvalidContents.json");
            
            Assert.True(parcelTypes != null && parcelTypes.Count() ==3);
        }
    }
}
