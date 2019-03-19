using System.Collections.Generic;
using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Parcel.ServiceContracts.Rules;
using ParcelCo.Parcel.Resources.Exceptions;
using ParcelCo.Parcel.Exceptions;
using System.Linq;

namespace ParcelCo.Parcel.ServiceImplementation.Rules
{
    public class CollectionCheck : ICollectionCheck
    {
        public void ApplyRule(IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight, IParcelResult parcelResult)
        {
            if (parcelTypes == null || (parcelTypes != null && parcelTypes.Count() == 0) )
            {
                RulesException customException = new RulesException(Resource.ResourceManager.GetString(nameof(Constants.Exceptions.Constants.CollectionIsEmpty)));
                customException.Data.Add(nameof(Constants.Exceptions.Constants.Type), nameof(Constants.Exceptions.Constants.CollectionIsEmpty));
                throw customException;
            }
        }
    }
}
