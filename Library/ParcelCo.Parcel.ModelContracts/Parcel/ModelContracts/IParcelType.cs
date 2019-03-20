using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCo.Parcel.ModelContracts
{
    /// <summary>Model to store package/parcel type details </summary>
    public interface IParcelType
    {
        /// <summary>Gets or sets the package/parcel type.</summary>
        /// <value>The type.</value>
        string Type { get; set; }
        /// <summary>Gets or sets the package/parcel cost.</summary>
        /// <value>The cost.</value>
        decimal Cost { get; set; }
        /// <summary>Gets or sets the package/parcel maximum size.</summary>
        /// <value>The maximum size.</value>
        float MaxSize { get; set; }
        /// <summary>Gets or sets the package/parcel maximum weight.</summary>
        /// <value>The maximum weight.</value>
        float MaxWeight { get; set; }

        /// <summary>Reads package types from a json file.</summary>
        /// <param name="fileLocation">The file location.</param>
        /// <returns>A collection oject containing the package types found in the file.</returns>
        IEnumerable<IParcelType> ReadFromFile(string fileLocation);

        /// <summary>
        /// Creates a transient instance of this class. This enables the model to be 
        /// injected into another class that needs it and that class can create further
        /// instances as required without knowing of it's concrete implementation
        /// maintaining seperation of concerns a loose coupled model.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="cost">The cost.</param>
        /// <param name="maxSize">The maximum size.</param>
        /// <param name="maxWeight">The maximum weight.</param>
        /// <returns></returns>
        IParcelType CreateTransientInstance(string type = null, decimal cost = 0, float maxSize = 0, float maxWeight = 0);
    }
}
