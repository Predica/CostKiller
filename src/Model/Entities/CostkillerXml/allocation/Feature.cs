using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Predica.Costkiller.Core.Model.Entities.CostkillerXml.allocation
{
    [XmlRoot("feature")]
    public class Feature
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
