﻿using Newtonsoft.Json;
using System.IO;
using ParcelCo.Json.ServiceContracts;


namespace ParcelCo.Json.ServiceImplementation
{
    public class JsonReader : IJsonReader
    {
        public T ReadOjectFromJsonFile<T>(string fileLocation)
        {
            using (StreamReader file = File.OpenText(fileLocation))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (T)serializer.Deserialize(file, typeof(T));
            }
        }
    }
}
