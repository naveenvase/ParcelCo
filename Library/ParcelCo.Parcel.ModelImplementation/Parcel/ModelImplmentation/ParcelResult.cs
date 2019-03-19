using System;
using System.Collections.Generic;
using System.Text;
using ParcelCo.Parcel.ModelContracts;

namespace ParcelCo.Parcel.ModelImplmentation
{
    public class ParcelResult : IParcelResult
    {
        public decimal Cost {get;set;}
        public string ParcelType { get; set; }
        
        public IParcelResult CreateTransientInstance(string type = null, decimal cost = 0)
        {
            IParcelResult instance = (IParcelResult)MemberwiseClone();
            instance.Cost = cost;
            instance.ParcelType = type;

            return instance;
        }


    }
}
