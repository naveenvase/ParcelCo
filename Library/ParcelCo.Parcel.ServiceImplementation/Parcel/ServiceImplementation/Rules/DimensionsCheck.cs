using System.Linq;
using System.Collections.Generic;
using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Parcel.ServiceContracts.Rules;
using ParcelCo.Parcel.Resources.Exceptions;
using ParcelCo.Parcel.Exceptions;

namespace ParcelCo.Parcel.ServiceImplementation.Rules
{
    /// <seealso cref="IDimensionsCheck" />
    /// <inheritdoc />
    public class DimensionsCheck : IDimensionsCheck
    {
        /// <summary>
        /// Applies the rule.
        /// </summary>
        /// <remarks>
        /// This rule determines the overall size of the user 
        /// entered package dimensions. Formula used for this:
        /// length + breath * 2 + height * 2
        /// It finds the closest record that matches this OverallSize 
        /// from the collection of approved/recommended packages the business
        /// deals with. Uses linq to find the best match. If none can be found then
        /// throws an exception.
        /// </remarks>
        /// <exception cref="SolutionNotFoundException">Thrown when no good match
        /// can be found </exception>
        /// <inheritdoc />
        public void ApplyRule(IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight, IParcelResult parcelResult)
        {
            var result = (from parcel in parcelTypes.OrderBy(x => x.OverallSize) where (length + (breath * 2) + (height * 2)) <= parcel.OverallSize && weight <= parcel.MaxWeight select parcel).FirstOrDefault() ;

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
