using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predica.Costkiller.Core.Model.Exceptions
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
