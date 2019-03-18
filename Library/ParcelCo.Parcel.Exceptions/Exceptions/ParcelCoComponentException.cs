using System;
using System.Runtime.Serialization;

namespace ParcelCo.Parcel.Exceptions
{
    [Serializable]
    public class ParcelCoComponentException : Exception
    {
        public ParcelCoComponentException()
        {
        }

        public ParcelCoComponentException(string message): base(message)
        {
        }

        public ParcelCoComponentException(string message, Exception inner): base(message, inner)
        {
        }

        protected ParcelCoComponentException(SerializationInfo info, StreamingContext context): base(info, context)
        {
        }
    }
}
