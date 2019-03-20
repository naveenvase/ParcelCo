using System;
using System.Collections.Generic;
using System.Text;
using ParcelCo.Parcel.ModelContracts;

namespace ParcelCo.Parcel.ServiceContracts.Rules
{
    /// <summary>
    /// Encapsulates various business/validation logic for parcels.
    /// </summary>
    /// <remarks>Facliates Open of extenstion, closed for modification principle.
    /// Rather than hard code earch and every business logic/ validation and making
    /// things brittle (i.e. when a business logic needs to change the class needs
    /// to be updated) each business logic/vlidation is rule is encapsulated into
    /// a class. This class can either be applied or not from the collection with ease.
    /// When business rules change a new collection with a new set of extended rules 
    /// can be created rather than modification. 
    /// </remarks>
    public interface IRule
    {
        /// <summary>
        /// Contains the rule logic.
        /// </summary>
        /// <param name="parcelTypes">Collection of parcel types.</param>
        /// <param name="length">The length of current package that is being evaluated</param>
        /// <param name="breath">The breath. of current package that is being evaluated</param>
        /// <param name="height">The height of current package that is being evaluated</param>
        /// <param name="weight">The weight of current package that is being evaluated</param>
        /// <param name="parcelResult">The parcel result after evalutaion</param>
        /// <inheritDoc/>
        void ApplyRule(IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight, IParcelResult parcelResult);
    }

}

