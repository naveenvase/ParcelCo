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
            var res = jsonReader.ReadOjectFromJsonFile<IEnumerable<ParcelType>>(fileLocation);
            var recordCount = res != null ? res.Count() : 0;

            if (res == null )
            {
                System.IO.IOException customException = new System.IO.IOException(Resource.ResourceManager.GetString(nameof(Constants.Exceptions.Constants.FileIsEmpty)));
                customException.Data.Add(nameof(Constants.Exceptions.Constants.Type), nameof(Constants.Exceptions.Constants.FileIsEmpty));
                throw customException;
            }
            else if ((recordCount == 0) || (recordCount > 0 && res.Where(x => x.Type == null).Count() == recordCount))
            {
                System.IO.IOException customException = new System.IO.IOException(Resource.ResourceManager.GetString(nameof(Constants.Exceptions.Constants.FileContentsIsInValid)));
                customException.Data.Add(nameof(Constants.Exceptions.Constants.Type), nameof(Constants.Exceptions.Constants.FileContentsIsInValid));
                throw customException;
            }
            return res;
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
