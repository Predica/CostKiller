using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Predica.Costkiller.Core.Model.Entities.CostkillerXml
{
    [XmlRoot("allocations")]
    public class AllocationHolder
    {
        [XmlElement("allocation")]
        public List<Allocation> Allocations { get; set; }
    }
}
