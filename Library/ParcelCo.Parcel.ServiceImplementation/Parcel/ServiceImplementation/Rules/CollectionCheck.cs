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
            var recordCount = parcelTypes?.Count();

            if (parcelTypes == null || (recordCount == 0) )
            {
                RulesException customException = new RulesException(Resource.ResourceManager.GetString(nameof(Constants.Exceptions.Constants.CollectionIsEmpty)));
                customException.Data.Add(nameof(Constants.Exceptions.Constants.Type), nameof(Constants.Exceptions.Constants.CollectionIsEmpty));
                throw customException;
            }
            else if ( (recordCount > 0 && parcelTypes.Where(x => x.Type == null).Count() == recordCount))
            {
                RulesException customException = new RulesException(Resource.ResourceManager.GetString(nameof(Constants.Exceptions.Constants.CollectionInValidRecords)));
                customException.Data.Add(nameof(Constants.Exceptions.Constants.Type), nameof(Constants.Exceptions.Constants.CollectionInValidRecords));
                throw customException;
            }
        }
    }
}
