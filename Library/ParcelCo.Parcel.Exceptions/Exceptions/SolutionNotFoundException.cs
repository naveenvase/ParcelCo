using System;
using System.Runtime.Serialization;

namespace ParcelCo.Parcel.Exceptions
{
    [Serializable]
    public class SolutionNotFoundException : Exception
    {
        public SolutionNotFoundException()
        {
        }

        public SolutionNotFoundException(string message): base(message)
        {
        }

        public SolutionNotFoundException(string message, Exception inner): base(message, inner)
        {
        }

        protected SolutionNotFoundException(SerializationInfo info, StreamingContext context): base(info, context)
        {
        }
    }
}
