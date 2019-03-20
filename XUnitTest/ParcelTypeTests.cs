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

            Assert.True(
                parcelTypes != null && 
                parcelTypes.ElementAt(0).Type == "Small" &&
                parcelTypes.ElementAt(0).Cost == 5.00M &&
                parcelTypes.ElementAt(0).OverallSize == 1100F &&
                parcelTypes.ElementAt(0).MaxWeight == 25F &&
                parcelTypes.ElementAt(1).Type == "Medium" &&
                parcelTypes.ElementAt(1).Cost == 7.50M &&
                parcelTypes.ElementAt(1).OverallSize == 1500 &&
                parcelTypes.ElementAt(1).MaxWeight == 25F &&
                parcelTypes.ElementAt(2).Type == "Large" &&
                parcelTypes.ElementAt(2).Cost == 8.50M &&
                parcelTypes.ElementAt(2).OverallSize == 2100 &&
                parcelTypes.ElementAt(2).MaxWeight == 25F
                );
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
