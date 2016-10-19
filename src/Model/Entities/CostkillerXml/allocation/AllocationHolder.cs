using System.Collections.Generic;
using System.Xml.Serialization;

namespace Predica.CostkillerLib.Model.Entities.CostkillerXml.allocation
{
    [XmlRoot("allocations")]
    public class AllocationHolder
    {
        [XmlElement("allocation")]
        public List<Allocation> Allocations { get; set; }
    }
}
