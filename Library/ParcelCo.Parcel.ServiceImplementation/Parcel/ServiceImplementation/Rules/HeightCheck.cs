using System.Collections.Generic;
using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Parcel.ServiceContracts.Rules;
using ParcelCo.Parcel.Resources.Exceptions;
using ParcelCo.Parcel.Exceptions;

namespace ParcelCo.Parcel.ServiceImplementation.Rules
{
    /// <seealso cref="IHeightCheck" />
    /// <inheritdoc />
    public class HeightCheck : IHeightCheck
    {
        /// <summary>
        /// Ensures height is valid
        /// </summary>
        /// <exception cref="RulesException">Thrown when rule fails</exception>
        /// <inheritdoc />
        public void ApplyRule(IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight, IParcelResult parcelResult)
        {
            if (height <= 0)
            {
                RulesException customException = new RulesException(Resource.ResourceManager.GetString(nameof(Constants.Exceptions.Constants.HeightIsInvalid)));
                customException.Data.Add(nameof(Constants.Exceptions.Constants.Type), nameof(Constants.Exceptions.Constants.HeightIsInvalid));
                throw customException;
            }
        }
    }
}
