using System;

namespace Predica.CostkillerLib.Model.Exceptions
{
    class SerializerException : Exception
    {
        public string SerializedString { get; set; }
        public SerializerException(string message, string serializedString) : base(message)
        {
            this.SerializedString = serializedString;
        }
    }
}
