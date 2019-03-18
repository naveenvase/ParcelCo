using System;
using System.Collections.Generic;
using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Parcel.ServiceContracts.Rules;

namespace ParcelCo.Parcel.ServiceImplementation.Rules
{
    public class RulesEngine: IRulesEngine
    {
        private IParcelResult parcelResult = null;
        private IParcelShape parcelShape = null;

        public IList<IRule> Rules { get; private set; } = null;
        
        public RulesEngine(ISizeCheck sizeCheck, IParcelShape parcelShape, IParcelResult parcelResult)
        {
            Rules = new List<IRule> { sizeCheck };
            this.parcelResult = parcelResult;
            this.parcelShape = parcelShape;
        }
        
        public IParcelResult ApplyRules(ref IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight)
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
