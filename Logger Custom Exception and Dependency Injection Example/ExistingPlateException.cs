using System.Runtime.Serialization;

namespace Logger_Custom_Exception_and_Dependency_Injection_Example
{
    [Serializable]
    internal class ExistingPlateException : Exception
    {
        public ExistingPlateException()
        {
        }

        public ExistingPlateException(string? message) : base(message)
        {
        }

        public ExistingPlateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ExistingPlateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}