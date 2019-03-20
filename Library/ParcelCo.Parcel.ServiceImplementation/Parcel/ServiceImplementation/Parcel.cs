﻿using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Parcel.ServiceContracts;
using ParcelCo.Parcel.ServiceContracts.Rules;
using System.Collections.Generic;

namespace ParcelCo.Parcel.ServiceImplementation
{
    /// <inheritdoc />
    public class Parcel :IParcel
    {
        /// <summary>
        /// Contains the collection of rules that need to be satisfied
        /// </summary>
        private IRulesEngine PackageCalculator= null;

        /// <inheritdoc />
        public Parcel(IRulesEngine rulesEngine)
        {
            PackageCalculator = rulesEngine;
        }

        /// <inheritdoc />
        public IParcelResult Calculate(IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight)
        {
            return PackageCalculator.ApplyRules(parcelTypes,  length,  breath,  height, weight);
            
        }
    }
}
