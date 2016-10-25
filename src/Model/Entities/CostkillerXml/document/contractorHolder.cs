using System.Collections.Generic;
using System.Xml.Serialization;

namespace Predica.CostkillerLib.Model.Entities.CostkillerXml
{
    [XmlRoot("contractors")]
    public class ContractorHolder
    {
        [XmlElement("contractor")]
        public List<DocumentContractor> Contractors { get; set; }
    }
}
