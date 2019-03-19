using System;
using System.Collections.Generic;
using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Parcel.ServiceContracts.Rules;

namespace ParcelCo.Parcel.ServiceImplementation.Rules
{
    public class RulesEngine: IRulesEngine
    {
        private IParcelResult parcelResult = null;

        public IList<IRule> Rules { get; private set; } = null;
        
        public RulesEngine(ICollectionCheck CollectionCheck, ILengthCheck lengthCheck, IBreathCheck breathCheck, IHeightCheck heightCheck, IWeightCheck weightCheck, IDimensionsCheck dimensionsCheck, IParcelResult parcelResult)
        {
            Rules = new List<IRule> { CollectionCheck, lengthCheck, breathCheck, heightCheck, weightCheck, dimensionsCheck };
            this.parcelResult = parcelResult;
        }
        
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
