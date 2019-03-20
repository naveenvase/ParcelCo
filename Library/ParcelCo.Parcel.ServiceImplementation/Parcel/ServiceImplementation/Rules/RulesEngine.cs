using System;
using System.Collections.Generic;
using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Parcel.ServiceContracts.Rules;

namespace ParcelCo.Parcel.ServiceImplementation.Rules
{
    /// <inheritdoc />
    public class RulesEngine: IRulesEngine
    {
        /// <summary>
        /// The parcel result object contains the recommended package type
        /// </summary>
        private IParcelResult parcelResult = null;
        /// <inheritdoc />
        public IList<IRule> Rules { get; private set; } = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RulesEngine"/> class.
        /// </summary>
        /// <remarks>The parameters are injected via DIcontainer</remarks>
        /// <param name="CollectionCheck">The collection check.</param>
        /// <param name="lengthCheck">The length check.</param>
        /// <param name="breathCheck">The breath check.</param>
        /// <param name="heightCheck">The height check.</param>
        /// <param name="weightCheck">The weight check.</param>
        /// <param name="dimensionsCheck">The dimensions check.</param>
        /// <param name="parcelResult">The parcel result.</param>
        public RulesEngine(ICollectionCheck CollectionCheck, ILengthCheck lengthCheck, IBreathCheck breathCheck, IHeightCheck heightCheck, IWeightCheck weightCheck, IDimensionsCheck dimensionsCheck, IParcelResult parcelResult)
        {
            Rules = new List<IRule> { CollectionCheck, lengthCheck, breathCheck, heightCheck, weightCheck, dimensionsCheck };
            this.parcelResult = parcelResult;
        }

        /// <inheritdoc />
        public IParcelResult ApplyRules(IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight)
        {
            IParcelResult parcelRes = parcelResult.CreateTransientInstance();
            
            //loop through the rules and use the rule algorthim to verify business logic 
            for (int i = 0; i < Rules.Count; i++)
            {
                Rules[i].ApplyRule(parcelTypes,  length,  breath,  height,  weight, parcelRes);
            }
            return parcelRes;
        }
    }
}
