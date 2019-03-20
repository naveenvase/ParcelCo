using System;
using System.Collections.Generic;
using System.Text;
using ParcelCo.Parcel.ModelContracts;

namespace ParcelCo.Parcel.ModelImplmentation
{
    /// <inheritdoc/>
    public class ParcelResult : IParcelResult
    {
        /// <inheritdoc/>
        public decimal Cost {get;set;}
        /// <inheritdoc/>
        public string Type { get; set; }

        /// <inheritdoc/>
        public IParcelResult CreateTransientInstance(string type = null, decimal cost = 0)
        {
            IParcelResult instance = (IParcelResult)MemberwiseClone();
            instance.Cost = cost;
            instance.Type = type;

            return instance;
        }
    }
}
