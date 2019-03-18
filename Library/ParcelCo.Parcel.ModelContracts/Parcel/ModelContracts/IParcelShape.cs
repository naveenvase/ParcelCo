using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCo.Parcel.ModelContracts
{
    public interface IParcelShape
    {
        float Length { get; set; }
        float Breath { get; set; }
        float Height { get; set; }
        float Weight { get; set; }

        IParcelShape CreateTransientInstance(float length = 0, float breath = 0, float height = 0, float weight = 0);
    }
}
