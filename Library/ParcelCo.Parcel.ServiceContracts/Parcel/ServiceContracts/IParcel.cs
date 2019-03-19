using ParcelCo.Parcel.ModelContracts;
using System.Collections.Generic;

namespace ParcelCo.Parcel.ServiceContracts
{
    public interface IParcel
    {
        IParcelResult Calculate(IEnumerable<IParcelType> parcelTypes, float length, float breath, float height, float weight);
    }
}
