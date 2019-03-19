using ParcelCo.Json.ServiceContracts;

namespace XUnitTest.Mocks
{
    public class MockedJsonReader : IJsonReader
    {
        public T ReadOjectFromJsonFile<T>(string fileLocation)
        {
            return default(T);
        }
    }
}
