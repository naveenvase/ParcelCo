using Microsoft.Extensions.DependencyInjection;
using ParcelCo.InjectionHelper;

namespace XUnitTest
{
    public class DbFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }
  
        public DbFixture()
        {
            //setup  DI
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection Services)
        {
            ServiceInjectionHelper.SetServiceCollection(Services);
        }
    }
}
