using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Json.ServiceContracts;
using System.Collections.Generic;
using ParcelCo.Parcel.Resources.Exceptions;
using System.Linq;

namespace ParcelCo.Parcel.ModelImplmentation
{
    /// <inheritdoc/>
    public class ParcelType :IParcelType
    {
        /// <inheritdoc/>
        public string Type { get; set; }
        /// <inheritdoc/>
        public decimal Cost { get; set; }
        /// <inheritdoc/>
        public float MaxSize { get; set; }
        /// <inheritdoc />
        public float MaxWeight { get; set; }
        /// <inheritdoc />
        private IJsonReader jsonReader = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelType"/> class.
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
