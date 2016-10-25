using System.Collections.Generic;
using System.Xml.Serialization;

namespace Predica.CostkillerLib.Model.Entities.CostkillerXml
{
    [XmlRoot("documents")]
    public class DocumentHolder
    {
        [XmlElement("document")]
        public List<Document> Documents { get; set; }
    }
}
