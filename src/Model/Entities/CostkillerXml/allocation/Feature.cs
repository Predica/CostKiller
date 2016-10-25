using System.Xml.Serialization;

namespace Predica.CostkillerLib.Model.Entities.CostkillerXml.allocation
{
    [XmlRoot("feature")]
    public class Feature
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
