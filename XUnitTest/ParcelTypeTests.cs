using Microsoft.Extensions.DependencyInjection;
using Xunit;
using ParcelCo.Parcel.ModelContracts;
using System.Collections.Generic;
using System;
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
        public void ReadJsonFileTest()
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

            Assert.Throws<System.IO.IOException>(() => parcelType.ReadFromFile(@"Resources\EmptyParcelTypes.json"));
        }

        [Fact]
        public void ReadJsonFileWithInvalidFilePath()
        {
            IParcelType parcelType = serviceProvider.GetService<IParcelType>();

            Assert.Throws<System.IO.DirectoryNotFoundException>(() => parcelType.ReadFromFile(@"Resources2\EmptyParcelTypes.json"));
        }

        [Fact]
        public void ReadJsonFileWithEmptyRecords()
        {
            IParcelType parcelType = serviceProvider.GetService<IParcelType>();

            Assert.Throws<System.IO.IOException>(() => parcelType.ReadFromFile(@"Resources\ParcelTypesNoRecords.json"));
        }

        [Fact]
        public void ReadJsonFileWithInvalidContents()
        {
            IParcelType parcelType = serviceProvider.GetService<IParcelType>();

            Assert.Throws<System.IO.IOException>(() => parcelType.ReadFromFile(@"Resources\ParcelTypesInvalidContents.json"));
        }
    }
}
