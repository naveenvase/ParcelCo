using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCo.Parcel.ModelContracts
{
    public interface IParcelResult
    {
        string Type { get; set; }
        decimal Cost { get; set; }
        IParcelResult CreateTransientInstance(string type = null, decimal cost = 0);
    }
}
