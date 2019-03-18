using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCo.Parcel.ModelContracts
{
    public interface IParcelType
    {
        string Type { get; set; }
        decimal Cost { get; set; }
        float MaxSize { get; set; }
        float MaxWeight { get; set; }

        IEnumerable<IParcelType> ReadFromFile(string fileLocation);
    }
}
