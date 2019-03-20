using ParcelCo.Parcel.ModelContracts;
using System.Collections.Generic;

namespace ParcelCo.Parcel.ServiceContracts
{
    /// <summary>
    /// Parcel service. Contains method to identify the best package size/type 
    /// for the supplied pacakge dimensions.
    /// </summary>
    public interface IParcel
    {
        /// <summary>
        /// Runs a bunch of rules.
        /// Once all the rules are run the method ends up
        /// recommending the best package size/type for the supplied
        /// package dimensions.
        /// </summary>
        /// <param name="parcelTypes">Collection of parcel types/sizes that can be
        /// accoommodated.</param>
        /// <param name="length">The length.</param>
        /// <param name="breath">The breath.</param>
        /// <param name="height">The height.</param>
        /// <param name="weight">The weight.</param>
        /// <returns><see cref="IParcelResult"></see>/></returns>
        IParcelResult Calculate(IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight);
    }
}
