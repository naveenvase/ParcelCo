using Microsoft.Extensions.DependencyInjection;
using ParcelCo.Parcel.Exceptions;
using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Parcel.ServiceContracts.Rules;
using System;
using System.Collections.Generic;
using Xunit;
using ParcelCo.Parcel.Constants.Exceptions;

namespace XUnitTest
{
    public class RulesEngineTests : IClassFixture<DbFixture>
    {
        private readonly ServiceProvider serviceProvider;
        private readonly ServiceProvider MockedParcelServiceProvider;

        public RulesEngineTests(DbFixture fixture)
        {
            serviceProvider = fixture.ServiceProvider;
            MockedParcelServiceProvider = fixture.MockedParcelServiceProvider;
        }

        [Fact]
        public void CollectionCheckWithNullCollection()
        {
            ICollectionCheck collectionCheck = serviceProvider.GetService<ICollectionCheck>();

            Exception ex = Assert.Throws<RulesException>( () => collectionCheck.ApplyRule(null, 0, 0, 0, 0, null));
            Assert.True(ex.Data != null && ex.Data[nameof(Constants.Type)].ToString() == nameof(Constants.CollectionIsEmpty));
        }

        [Fact]
        public void CollectionCheckWithEmptyCollection()
        {
            ICollectionCheck collectionCheck = serviceProvider.GetService<ICollectionCheck>();
            IParcelType parcelType = MockedParcelServiceProvider.GetService<IParcelType>();

            Exception ex = Assert.Throws<RulesException>(() => collectionCheck.ApplyRule(new List<IParcelType> { }, 0, 0, 0, 0, null));
            Assert.True(ex.Data != null && ex.Data[nameof(Constants.Type)].ToString() == nameof(Constants.CollectionIsEmpty));
        }

        [Fact]
        public void CollectionCheckWithInvalidRecords()
        {
            ICollectionCheck collectionCheck = serviceProvider.GetService<ICollectionCheck>();
            IParcelType parcelType = MockedParcelServiceProvider.GetService<IParcelType>();

            IEnumerable<IParcelType> parcelTypes = new List<IParcelType> {
                parcelType.CreateTransientInstance(null, 0, 0, 0 ),
                parcelType.CreateTransientInstance(null, 0, 0, 0 ),
                parcelType.CreateTransientInstance(null, 0, 0, 0 )
            };

            Exception ex = Assert.Throws<RulesException>(() => collectionCheck.ApplyRule(parcelTypes, 0, 0, 0, 0, null));
            Assert.True(ex.Data != null && ex.Data[nameof(Constants.Type)].ToString() == nameof(Constants.CollectionInValidRecords));
        }

        [Theory]
        [InlineData(-300)]
        [InlineData(0)]
        [InlineData(-1)]
        public void LengthCheckWithInValidValues(float length)
        {
            ILengthCheck lengthCheck = serviceProvider.GetService<ILengthCheck>();

            Exception ex = Assert.Throws<RulesException>(() => lengthCheck.ApplyRule(null, length, 0, 0, 0, null));
            Assert.True(ex.Data != null && ex.Data[nameof(Constants.Type)].ToString() == nameof(Constants.LengthIsInvalid));
        }

        [Theory]
        [InlineData(-300)]
        [InlineData(0)]
        [InlineData(-1)]
        public void LengthCheckWithValidValues(float length)
        {
            ILengthCheck lengthCheck = serviceProvider.GetService<ILengthCheck>();

            Exception ex = Assert.Throws<RulesException>(() => lengthCheck.ApplyRule(null, length, 0, 0, 0, null));
            Assert.True(ex.Data != null && ex.Data[nameof(Constants.Type)].ToString() == nameof(Constants.LengthIsInvalid));
        }

        [Theory]
        [InlineData(-45300)]
        [InlineData(0)]
        [InlineData(-1)]
        public void BreathCheckWithValidValues(float breath)
        {
            IBreathCheck breathCheck = serviceProvider.GetService<IBreathCheck>();

            Exception ex = Assert.Throws<RulesException>(() => breathCheck.ApplyRule(null,0, breath, 0, 0, null));
            Assert.True(ex.Data != null && ex.Data[nameof(Constants.Type)].ToString() == nameof(Constants.BreathIsInvalid));
        }

        [Theory]
        [InlineData(-45300)]
        [InlineData(0)]
        [InlineData(-1)]
        public void HeightCheckWithValidValues(float height)
        {
            IHeightCheck heightCheck = serviceProvider.GetService<IHeightCheck>();

            Exception ex = Assert.Throws<RulesException>(() => heightCheck.ApplyRule(null, 0, 0,height, 0, null));
            Assert.True(ex.Data != null && ex.Data[nameof(Constants.Type)].ToString() == nameof(Constants.HeightIsInvalid));
        }

        [Theory]
        [InlineData(-45300)]
        [InlineData(0)]
        [InlineData(-1)]
        public void WeightCheckWithValidValues(float weight)
        {
            IWeightCheck weightCheck = serviceProvider.GetService<IWeightCheck>();

            Exception ex = Assert.Throws<RulesException>(() => weightCheck.ApplyRule(null, 0, 0, weight, 0, null));
            Assert.True(ex.Data != null && ex.Data[nameof(Constants.Type)].ToString() == nameof(Constants.WeightIsInvalid));
        }

        [Theory]
        [InlineData(200, 300, 150, 27)]
        [InlineData(1600, 200, 150, 25)]
        [InlineData(400, 200, 800, 25)]
        [InlineData(400, 3100, 150, 25)]
        public void DimensionsCheckWithInValidValues(float length, float breath, float height, float weight)
        {
            IDimensionsCheck dimensionsCheck = serviceProvider.GetService<IDimensionsCheck>();
            IParcelType parcelType = MockedParcelServiceProvider.GetService<IParcelType>();
            IParcelResult parcelResult = serviceProvider.GetService<IParcelResult>();

            IEnumerable<IParcelType> parcelTypes = new List<IParcelType> {
                parcelType.CreateTransientInstance("Small", 5.00M, 1100, 25 ),
                parcelType.CreateTransientInstance("Medium", 7.50M, 1500, 25 ),
                parcelType.CreateTransientInstance("Large", 8.50M, 2100, 25 )
            };

            Exception ex = Assert.Throws<SolutionNotFoundException>(() => dimensionsCheck.ApplyRule(parcelTypes, length, breath, height, weight, parcelResult));
            Assert.True(ex.Data != null && ex.Data[nameof(Constants.Type)].ToString() == nameof(Constants.SolutionNotFound));
        }

        [Theory]
        [InlineData(200, 300, 150, 9)]
        [InlineData(100, 200, 150, 22)]
        [InlineData(230, 200, 80, 6)]
        [InlineData(400, 31, 150, 17)]
        public void DimensionsCheckWithValidSmallPackageValues(float length, float breath, float height, float weight)
        {
            IDimensionsCheck dimensionsCheck = serviceProvider.GetService<IDimensionsCheck>();
            IParcelType parcelType = MockedParcelServiceProvider.GetService<IParcelType>();
            IParcelResult parcelResult = serviceProvider.GetService<IParcelResult>(); ;

            IEnumerable<IParcelType> parcelTypes = new List<IParcelType> {
                parcelType.CreateTransientInstance("Small", 5.00M, 1100, 25 ),
                parcelType.CreateTransientInstance("Medium", 7.50M, 1500, 25 ),
                parcelType.CreateTransientInstance("Large", 8.50M, 2100, 25 )
            };

            dimensionsCheck.ApplyRule(parcelTypes, length, breath, height, weight, parcelResult);
            Assert.True(parcelResult.ParcelType == "Small");
        }

        [Theory]
        [InlineData(500, 300, 50, 4)]
        [InlineData(200, 200, 300, 2)]
        [InlineData(400, 250, 150, 15)]
        [InlineData(200, 623, 20, 1)]
        public void DimensionsCheckWithValidMediumPackageValues(float length, float breath, float height, float weight)
        {
            IDimensionsCheck dimensionsCheck = serviceProvider.GetService<IDimensionsCheck>();
            IParcelType parcelType = MockedParcelServiceProvider.GetService<IParcelType>();
            IParcelResult parcelResult = serviceProvider.GetService<IParcelResult>(); ;

            IEnumerable<IParcelType> parcelTypes = new List<IParcelType> {
                parcelType.CreateTransientInstance("Small", 5.00M, 1100, 25 ),
                parcelType.CreateTransientInstance("Medium", 7.50M, 1500, 25 ),
                parcelType.CreateTransientInstance("Large", 8.50M, 2100, 25 )
            };

            dimensionsCheck.ApplyRule(parcelTypes, length, breath, height, weight, parcelResult);
            Assert.True(parcelResult.ParcelType == "Medium");
        }

        [Theory]
        [InlineData(700, 300, 400, 2)]
        [InlineData(1600, 100, 150, 6)]
        [InlineData(601, 250, 200, 9)]
        [InlineData(400, 600, 150, 25)]
        public void DimensionsCheckWithValidLargePackageValues(float length, float breath, float height, float weight)
        {
            IDimensionsCheck dimensionsCheck = serviceProvider.GetService<IDimensionsCheck>();
            IParcelType parcelType = MockedParcelServiceProvider.GetService<IParcelType>();
            IParcelResult parcelResult = serviceProvider.GetService<IParcelResult>(); ;

            IEnumerable<IParcelType> parcelTypes = new List<IParcelType> {
                parcelType.CreateTransientInstance("Small", 5.00M, 1100, 25 ),
                parcelType.CreateTransientInstance("Medium", 7.50M, 1500, 25 ),
                parcelType.CreateTransientInstance("Large", 8.50M, 2100, 25 )
            };

            dimensionsCheck.ApplyRule(parcelTypes, length, breath, height, weight, parcelResult);
            Assert.True(parcelResult.ParcelType == "Large");
        }
    }
}