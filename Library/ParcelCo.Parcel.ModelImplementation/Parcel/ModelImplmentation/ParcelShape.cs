using ParcelCo.Parcel.ModelContracts;

namespace ParcelCo.Parcel.ModelImplmentation
{
    public class ParcelShape : IParcelShape
    {
        public float Length { get; set; }
        public float Breath { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }

        public IParcelShape CreateTransientInstance(float length =0,float breath = 0,float height = 0, float weight = 0 )
        {
            IParcelShape instance = (IParcelShape)MemberwiseClone();

            instance.Length = length;
            instance.Breath = breath;
            instance.Height = height;
            instance.Weight = weight;

            return instance;
        }

    }
}
