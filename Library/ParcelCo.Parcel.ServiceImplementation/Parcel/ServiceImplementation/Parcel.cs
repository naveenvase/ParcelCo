using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Parcel.ServiceContracts;
using ParcelCo.Parcel.ServiceContracts.Rules;
using System.Collections.Generic;

namespace ParcelCo.Parcel.ServiceImplementation
{
    /// <seealso cref="IParcel" />
    /// <inheritdoc />
    public class Parcel :IParcel
    {
        /// <summary>
        /// Contains the collection of rules that need to be satisfied
        /// </summary>
        private IRulesEngine packageRulesEngine= null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Parcel"/> class.
        /// </summary>
        /// <param name="rulesEngine">The rules engine.</param>
        /// <inheritdoc />
        public Parcel(IRulesEngine rulesEngine)
        {
            packageRulesEngine = rulesEngine;
        }

        /// <returns>
        ///   <see cref="IParcelResult"></see>;
        /// </returns>
        /// <inheritdoc />
        public IParcelResult Calculate(IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight)
        {
            return packageRulesEngine.ApplyRules(parcelTypes,  length,  breath,  height, weight);
            
        }
    }
}
