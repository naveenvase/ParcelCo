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
    public static class ServiceInjectionHelper
    {
        public static void SetServiceCollection(IServiceCollection services)
        {
           services
           .AddTransient<IRulesEngine, RulesEngine>()
           .AddTransient<ISizeCheck, SizeCheck>()
           .AddTransient<IParcel, ParcelCo.Parcel.ServiceImplementation.Parcel>()
           .AddTransient<IParcelResult, ParcelResult>()
           .AddTransient<IParcelType, ParcelType>()
           .AddSingleton<IJsonReader,JsonReader>()
           .AddTransient<IParcelShape, ParcelShape>();
        }
    }
}