using ParcelCo.Parcel.ModelContracts;
using System.Collections.Generic;

namespace ParcelCo.Parcel.ServiceContracts
{
    /// <summary>
    /// Parcel service. Contains methods to identify the best package size/type based on
    /// pacakge dimensions.
    /// </summary>
    public interface IParcel
    {
        /// <summary>
        /// Identifies the best package size/type based on
        /// default package types/sizes that can be accommdiated
        /// </summary>
        /// <param name="parcelTypes">Collection of parcel types/sizes that can be
        /// accoommodated.</param>
        /// <param name="length">The length.</param>
        /// <param name="breath">The breath.</param>
        /// <param name="height">The height.</param>
        /// <param name="weight">The weight.</param>
        /// <returns></returns>
        /// <remarks>
        /// Uses linq to match the package dimensions provided with
        /// the default package types/sizes that can be accommodated
        /// </remarks>
        IParcelResult Calculate(IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight);
    }
}
