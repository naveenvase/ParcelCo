using System;
using System.Collections.Generic;
using System.Text;
using ParcelCo.Parcel.ModelContracts;

namespace ParcelCo.Parcel.ServiceContracts.Rules
{
    /// <summary>
    /// This interface encapsulates business/validation logic for parcels.
    /// </summary>
    public interface IRule
    {
        /// <summary>
        /// Method that contains the rules/check/validation logic
        /// </summary>
        void ApplyRule(IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight, IParcelResult parcelResult);
    }

}

