using Microsoft.Extensions.DependencyInjection;
using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Parcel.ModelImplmentation;
using ParcelCo.Parcel.ServiceContracts;
using ParcelCo.Parcel.ServiceContracts.Rules;
using ParcelCo.Parcel.ServiceImplementation.Rules;
using ParcelCo.Json.ServiceContracts;
using ParcelCo.Json.ServiceImplementation;


namespace ParcelCo.InjectionHelper
{
    /// <summary>
    /// Helper class to set up dependency injection, via .net core built in DI.
    /// </summary>
    public static class ServiceInjectionHelper
    {
        /// <summary>Helper methd to set up dependency injection, via .net core built in DI.</summary>
        /// <param name="services">The .net core DI servicescollection</param>
        public static void SetServiceCollection(IServiceCollection services)
        {
            services
            .AddTransient<IRulesEngine, RulesEngine>()
            .AddTransient<ICollectionCheck, CollectionCheck>()
            .AddTransient<ILengthCheck, LengthCheck>()
            .AddTransient<IBreathCheck, BreathCheck>()
            .AddTransient<IHeightCheck, HeightCheck>()
            .AddTransient<IWeightCheck, WeightCheck>()
            .AddTransient<IDimensionsCheck, DimensionsCheck>()
            .AddTransient<IParcel, ParcelCo.Parcel.ServiceImplementation.Parcel>()
            .AddTransient<IParcelResult, ParcelResult>()
            .AddTransient<IParcelType, ParcelType>()
            .AddSingleton<IJsonReader, JsonReader>();
        }
    }
}