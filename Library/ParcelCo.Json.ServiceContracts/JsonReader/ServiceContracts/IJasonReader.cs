namespace ParcelCo.Json.ServiceContracts
{
    /// <summary>Reads Json content</summary>
    public interface IJsonReader
    {
        /// <summary>Reads Json content from a file and puts it into a collection object</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileLocation">The file location.</param>
        /// <returns></returns>
        T ReadOjectFromJsonFile<T>(string fileLocation);
    }
}
