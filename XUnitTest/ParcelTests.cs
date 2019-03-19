using Microsoft.Extensions.DependencyInjection;
using Xunit;
using ParcelCo.Parcel.ServiceContracts;
using ParcelCo.Parcel.ModelContracts;
using System.Collections.Generic;
using ParcelCo.Parcel.Exceptions;
using ParcelCo.Parcel.Constants.Exceptions;
using System;

namespace XUnitTest
{
    public class ParcelTests : IClassFixture<DbFixture>
    {
        private readonly ServiceProvider MockedParcelServiceProvider;

        public ParcelTests(DbFixture fixture)
        {
            MockedParcelServiceProvider = fixture.MockedParcelServiceProvider;
        }

        [Theory]
        [InlineData(200, 300, 150, 25)]
        [InlineData(300, 200, 150, 25)]
        [InlineData(150, 300, 100, 25)]
        [InlineData(400, 300, 50, 25)]
        public void CalculateWithValidSmallPackageDimensions(float length, float breath, float height,float weight)
        {
            IParcel parcelService = MockedParcelServiceProvider.GetService<IParcel>();
            IParcelType parcelType = MockedParcelServiceProvider.GetService<IParcelType>();

            IEnumerable<IParcelType> parcelTypes = new List<IParcelType> {
                parcelType.CreateTransientInstance("Small", 5.00M, 1100, 25 ),
                parcelType.CreateTransientInstance("Medium", 7.50M, 1500, 25 ),
                parcelType.CreateTransientInstance("Large", 8.50M, 2100, 25 )
            };

            IParcelResult result = null;

            result = parcelService.Calculate(parcelTypes, length, breath, height, weight);
            Assert.True(result.Type == "Small");
        }

        [Theory]
        [InlineData(300, 400, 200, 25)]
        [InlineData(400, 300, 150, 25)]
        [InlineData(550, 100, 200, 25)]
        [InlineData(800, 100, 100, 25)]
        public void CalculateWithValidMediumPackageDimensions(float length, float breath, float height, float weight)
        {
            IParcel parcelService = MockedParcelServiceProvider.GetService<IParcel>();
            IParcelType parcelType = MockedParcelServiceProvider.GetService<IParcelType>();

            IEnumerable<IParcelType> parcelTypes = new List<IParcelType> {
                parcelType.CreateTransientInstance("Small", 5.00M, 1100, 25 ),
                parcelType.CreateTransientInstance("Medium", 7.50M, 1500, 25 ),
                parcelType.CreateTransientInstance("Large", 8.50M, 2100, 25 )
            };

            IParcelResult result = null;

            result = parcelService.Calculate(parcelTypes, length, breath, height, weight);
            Assert.True(result.Type == "Medium");
        }

        [Theory]
        [InlineData(400, 600, 250, 25)]
        [InlineData(400, 200, 450, 25)]
        [InlineData(800, 200, 200, 25)]
        [InlineData(100, 400, 400, 25)]
        public void CalculateWithValidLargePackageDimensions(float length, float breath, float height, float weight)
        {
            IParcel parcelService = MockedParcelServiceProvider.GetService<IParcel>();
            IParcelType parcelType = MockedParcelServiceProvider.GetService<IParcelType>();

            IEnumerable<IParcelType> parcelTypes = new List<IParcelType> {
                parcelType.CreateTransientInstance("Small", 5.00M, 1100, 25 ),
                parcelType.CreateTransientInstance("Medium", 7.50M, 1500, 25 ),
                parcelType.CreateTransientInstance("Large", 8.50M, 2100, 25 )
            };

            IParcelResult result = null;

            result = parcelService.Calculate(parcelTypes, length, breath, height, weight);
            Assert.True(result.Type == "Large");
        }

        [Theory]
        [InlineData(0, 300, 50, 25)]
        [InlineData(-1, 300, 50, 20)]
        [InlineData(200, 0, 150, 7)]
        [InlineData(200, -1, 150, 6)]
        [InlineData(200, 500, 0, 5)]
        [InlineData(200, 500, -1, 2)]
        [InlineData(200, 300, 150, -1)]
        [InlineData(300, 200, 150, -26)]
        [InlineData(150, 300, -1700, 22)]
        [InlineData(-1500, 300, 100, 2)]
        [InlineData(1500, -3000, 100, 11)]
        public void CalculateWithInvalidPackageDimensions(float length, float breath, float height, float weight)
        {
            IParcel parcelService = MockedParcelServiceProvider.GetService<IParcel>();
            IParcelType parcelType = MockedParcelServiceProvider.GetService<IParcelType>();

            IEnumerable<IParcelType> parcelTypes = new List<IParcelType> {
                parcelType.CreateTransientInstance("Small", 5.00M, 1100, 25 ),
                parcelType.CreateTransientInstance("Medium", 7.50M, 1500, 25 ),
                parcelType.CreateTransientInstance("Large", 8.50M, 2100, 25 )
            };

            Exception ex = Assert.Throws<RulesException>(() => parcelService.Calculate(parcelTypes, length, breath, height, weight));
            Assert.True(ex.Data != null);
        }

        [Theory]
        [InlineData(1300, 400, 150, 25)]
        [InlineData(400, 200, 250, 2767)]
        [InlineData(1500, 300, 100, 24)]
        [InlineData(400, 3300, 50, 23)]
        [InlineData(400, 330, 5077, 23)]
        public void CalculateWithInvalidLargePackageDimensions(float length, float breath, float height, float weight)
        {
            IParcel parcelService = MockedParcelServiceProvider.GetService<IParcel>();
            IParcelType parcelType = MockedParcelServiceProvider.GetService<IParcelType>();

            IEnumerable<IParcelType> parcelTypes = new List<IParcelType> {
                parcelType.CreateTransientInstance("Small", 5.00M, 1100, 25 ),
                parcelType.CreateTransientInstance("Medium", 7.50M, 1500, 25 ),
                parcelType.CreateTransientInstance("Large", 8.50M, 2100, 25 )
            };

            Exception ex = Assert.Throws<SolutionNotFoundException>(() => parcelService.Calculate(parcelTypes, length, breath, height, weight));
            Assert.True(ex.Data != null);
        }

        [Fact]
        public void CalculateWithInvalidEmptyParcelCollection()
        {
            IParcel parcelService = MockedParcelServiceProvider.GetService<IParcel>();
            IEnumerable<IParcelType> parcelTypes = null;

            Exception ex = Assert.Throws<RulesException>(() => parcelService.Calculate(parcelTypes, 1, 1, 1, 1));
            Assert.True(ex.Data != null && ex.Data[nameof(Constants.Type)].ToString() == nameof(Constants.CollectionIsEmpty));
        }
    }
}
