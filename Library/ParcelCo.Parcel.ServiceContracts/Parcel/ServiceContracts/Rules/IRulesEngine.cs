using System;
using System.Collections.Generic;
using System.Text;
using ParcelCo.Parcel.ModelContracts;

namespace ParcelCo.Parcel.ServiceContracts.Rules
{
    /// <summary>
    /// This interfce acts as a factory. It is desgined to store a bunch of 
    /// strategy classes that contain rules/business logic 
    /// </summary>
    public interface IRulesEngine
    {
        /// <summary>
        /// A collection of rules that need to be satisfied
        /// </summary>
        IList<IRule> Rules { get; }

        /// <summary>
        /// Method that runs all the rules in the <see cref="Rules"/> collection.
        /// </summary>
        /// <param name="parcelTypes">The parcel types.</param>
        /// <param name="length">The length.</param>
        /// <param name="breath">The breath.</param>
        /// <param name="height">The height.</param>
        /// <param name="weight">The weight.</param>
        /// <returns>Return <see cref="IParcelResult"/> object</returns>
        IParcelResult ApplyRules(IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight);
    }

}
