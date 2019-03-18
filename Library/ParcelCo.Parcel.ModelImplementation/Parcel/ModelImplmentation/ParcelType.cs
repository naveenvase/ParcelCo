using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Json.ServiceContracts;
using System.Collections.Generic;

namespace ParcelCo.Parcel.ModelImplmentation
{
    public class ParcelType :IParcelType
    {
        public string Type { get; set; }
        public decimal Cost { get; set; }
        public float MaxSize { get; set; }
        public float MaxWeight { get; set; }
        private IJsonReader jsonReader = null;

        public ParcelType(IJsonReader jsonReader)
        {
            this.jsonReader = jsonReader;
        }
        
        public IEnumerable<IParcelType> ReadFromFile(string fileLocation)
        {
            return jsonReader.ReadOjectFromJsonFile<IEnumerable<ParcelType>>(fileLocation);
        }
    }

}
