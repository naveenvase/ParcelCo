using ParcelCo.Json.ServiceContracts;

namespace XUnitTest.Mocks
{
    /// <summary>
    /// Mocked JsonReader so it does nothing to ensure this does not cause
    /// unit test to fail
    /// </summary>
    /// <seealso cref="ParcelCo.Json.ServiceContracts.IJsonReader" />
    public class MockedJsonReader : IJsonReader
    {
        public T ReadOjectFromJsonFile<T>(string fileLocation)
        {
            return default(T);
        }
    }
}
