using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Parcel.ServiceContracts;
using ParcelCo.Parcel.ServiceContracts.Rules;
using System.Collections.Generic;

namespace ParcelCo.Parcel.ServiceImplementation
{
    public class Parcel :IParcel
    {
        private IRulesEngine PackageCalculator= null;

        public Parcel(IRulesEngine rulesEngine)
        {
            PackageCalculator = rulesEngine;
            
        }

        public IParcelResult Calculate(IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight)
        {
            return PackageCalculator.ApplyRules(parcelTypes,  length,  breath,  height, weight);
            
        }
    }
}
