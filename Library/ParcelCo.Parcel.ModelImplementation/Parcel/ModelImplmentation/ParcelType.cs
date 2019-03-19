using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Json.ServiceContracts;
using System.Collections.Generic;
using ParcelCo.Parcel.Resources.Exceptions;
using System.Linq;

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

        public IParcelType CreateTransientInstance(string type = null, decimal cost = 0, float maxSize = 0, float maxWeight = 0)
        {
            IParcelType instance = (IParcelType)MemberwiseClone();

            instance.Type = type;
            instance.Cost = cost;
            instance.MaxSize = maxSize;
            instance.MaxWeight = maxWeight;

            return instance;
        }
    }

}
