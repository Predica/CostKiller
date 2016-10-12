using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Predica.Costkiller.Core.Model.Entities.CostkillerXml.document
{
    [XmlRoot("contractors")]
    public class ContractorHolder
    {
        [XmlElement("contractor")]
        public List<DocumentContractor> Contractors { get; set; }
    }
}
