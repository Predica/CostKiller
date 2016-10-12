using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Predica.Costkiller.Core.Model.Entities.CostkillerXml
{
    [XmlRoot("documents")]
    public class DocumentHolder
    {
        [XmlElement("document")]
        public List<Document> Documents { get; set; }
    }
}
