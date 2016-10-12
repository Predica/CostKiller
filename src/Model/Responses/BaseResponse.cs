using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Predica.Costkiller.Core.Model.Responses
{
    [XmlRoot("response")]
    public class BaseResponse
    {
        public bool success { get; set; }
        public string code { get; set; }
        public string error { get; set; }
    }
}
