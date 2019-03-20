using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Json.ServiceContracts;
using System.Collections.Generic;

namespace ParcelCo.Parcel.ModelImplmentation
{
    /// <seealso cref="IParcelType" />
    /// <inheritdoc />
    public class ParcelType :IParcelType
    {
        /// <inheritdoc/>
        public string Type { get; set; }
        /// <inheritdoc/>
        public decimal Cost { get; set; }
        /// <inheritdoc/>
        public float OverallSize { get; set; }
        /// <inheritdoc />
        public float MaxWeight { get; set; }
        /// <inheritdoc />
        private IJsonReader jsonReader = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelType"/> class. The 
        /// parameters are injected from DI.
        /// </summary>
        /// <param name="jsonReader">The json file reader.</param>
        public ParcelType(IJsonReader jsonReader)
        {
            this.jsonReader = jsonReader;
        }

        /// <inheritdoc />
        public IEnumerable<IParcelType> ReadFromFile(string fileLocation)
        {
            return jsonReader.ReadOjectFromJsonFile<IEnumerable<ParcelType>>(fileLocation);
        }

        /// <inheritdoc />
        public IParcelType CreateTransientInstance(string type = null, decimal cost = 0, float overallSize = 0, float maxWeight = 0)
        {
            IParcelType instance = (IParcelType)MemberwiseClone();

            instance.Type = type;
            instance.Cost = cost;
            instance.OverallSize = overallSize;
            instance.MaxWeight = maxWeight;

            return instance;
        }
    }

}
