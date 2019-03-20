namespace ParcelCo.Parcel.ModelContracts
{
    /// <summary>Model to store package solution result</summary>
    public interface IParcelResult
    {
        /// <summary>Gets or sets the type.</summary>
        /// <value>The package type.</value>
        string Type { get; set; }

        /// <summary>Gets or sets the cost.</summary>
        /// <value>The package cost.</value>
        decimal Cost { get; set; }
        /// <summary>Creates a new transient instance of this class</summary>
        /// <param name="type">The type.</param>
        /// <param name="cost">The cost.</param>
        /// <returns></returns>
        IParcelResult CreateTransientInstance(string type = null, decimal cost = 0);
    }
}
