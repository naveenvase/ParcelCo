using System.Collections.Generic;
using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Parcel.ServiceContracts.Rules;
using ParcelCo.Parcel.Resources.Exceptions;
using ParcelCo.Parcel.Exceptions;
using System.Linq;

namespace ParcelCo.Parcel.ServiceImplementation.Rules
{

    /// <seealso cref="ICollectionCheck" />
    /// <inheritdoc />
    public class CollectionCheck : ICollectionCheck
    {
        /// <summary>
        /// This rule ensures collection parameter has a valid collection object 
        /// with valid records.
        /// </summary>
        /// <exception cref="RulesException">Thrown when collection object parameter 
        /// is null or has no records or has invalid records</exception>
        /// <inheritdoc />
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
                RulesException customException = new RulesException(Resource.ResourceManager.GetString(nameof(Constants.Exceptions.Constants.CollectionInvalidRecords)));
                customException.Data.Add(nameof(Constants.Exceptions.Constants.Type), nameof(Constants.Exceptions.Constants.CollectionInvalidRecords));
                throw customException;
            }
        }
    }
}
