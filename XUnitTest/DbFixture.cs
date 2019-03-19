using Microsoft.Extensions.DependencyInjection;
using ParcelCo.InjectionHelper;
using ParcelCo.Json.ServiceContracts;
using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Parcel.ServiceContracts;
using ParcelCo.Parcel.ServiceContracts.Rules;
using ParcelCo.Parcel.ServiceImplementation.Rules;
using ParcelCo.Parcel.ModelImplmentation;

namespace XUnitTest
{
    public class DbFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }
        public ServiceProvider MockedParcelServiceProvider { get; private set; }

        public DbFixture()
        {
            //setup  DI
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            MockedParcelServiceProvider = new ServiceCollection()
            .AddTransient<IRulesEngine, RulesEngine>()
            .AddTransient<IJsonReader, Mocks.MockedJsonReader>()
            .AddTransient<ICollectionCheck, CollectionCheck>()
            .AddTransient<ILengthCheck, LengthCheck>()
            .AddTransient<IBreathCheck, BreathCheck>()
            .AddTransient<IHeightCheck, HeightCheck>()
            .AddTransient<IWeightCheck, WeightCheck>()
            .AddTransient<IDimensionsCheck, DimensionsCheck>()
            .AddTransient<IParcel, ParcelCo.Parcel.ServiceImplementation.Parcel>()
            .AddTransient<IParcelResult, ParcelResult>()
            .AddTransient<IParcelType, ParcelType>()
             .BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection Services)
        {
            ServiceInjectionHelper.SetServiceCollection(Services);
        }
    }
}
