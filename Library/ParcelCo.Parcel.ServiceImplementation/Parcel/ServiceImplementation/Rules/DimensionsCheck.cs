using System.Linq;
using System.Collections.Generic;
using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Parcel.ServiceContracts.Rules;
using ParcelCo.Parcel.Resources.Exceptions;
using ParcelCo.Parcel.Exceptions;

namespace ParcelCo.Parcel.ServiceImplementation.Rules
{
    public class DimensionsCheck : IDimensionsCheck
    {
        public void ApplyRule(IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight, IParcelResult parcelResult)
        {
            var result = (from parcel in parcelTypes.OrderBy(x => x.MaxSize) where (length + (breath * 2) + (height * 2)) <= parcel.MaxSize && weight <= parcel.MaxWeight select parcel).FirstOrDefault() ;

            if (result == null)
            {
                SolutionNotFoundException customException = new SolutionNotFoundException(Resource.ResourceManager.GetString(nameof(Constants.Exceptions.Constants.SolutionNotFound)));
                customException.Data.Add(nameof(Constants.Exceptions.Constants.Type), nameof(Constants.Exceptions.Constants.SolutionNotFound));
                throw customException;
            }
            
            parcelResult.Type = result.Type;
            parcelResult.Cost = result.Cost; 
        }
    }
}
