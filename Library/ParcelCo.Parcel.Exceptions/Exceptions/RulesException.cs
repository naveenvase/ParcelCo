using System;
using System.Runtime.Serialization;

namespace ParcelCo.Parcel.Exceptions
{
    [Serializable]
    public class RulesException : Exception
    {
        public RulesException()
        {
        }

        public RulesException(string message): base(message)
        {
        }

        public RulesException(string message, Exception inner): base(message, inner)
        {
        }

        protected RulesException(SerializationInfo info, StreamingContext context): base(info, context)
        {
        }
    }
}
