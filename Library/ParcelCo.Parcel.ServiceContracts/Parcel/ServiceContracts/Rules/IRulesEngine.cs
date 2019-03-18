using System;
using System.Collections.Generic;
using System.Text;
using ParcelCo.Parcel.ModelContracts;

namespace ParcelCo.Parcel.ServiceContracts.Rules
{
    /// <summary>
    /// This interfce acts as a factory interface. It is desgined to create a bunch of strategy classes that contain rules/business logic 
    /// </summary>
    public interface IRulesEngine
    {
        /// <summary>
        /// A collection of rules that need to be satisfied
        /// </summary>
        IList<IRule> Rules { get; }

        /// <summary>
        /// Method that runs all the rules in a given factory of classes.
        /// </summary>
        IParcelResult ApplyRules(ref IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight);
    }

}
