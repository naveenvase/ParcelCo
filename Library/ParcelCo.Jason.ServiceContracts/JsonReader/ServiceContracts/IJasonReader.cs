namespace ParcelCo.Json.ServiceContracts
{
    public interface IJsonReader
    {
        T ReadOjectFromJsonFile<T>(string fileLocation);
    }
}
