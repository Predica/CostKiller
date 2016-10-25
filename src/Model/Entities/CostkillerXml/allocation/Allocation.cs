using System.Collections.Generic;
using System.Xml.Serialization;

namespace Predica.CostkillerLib.Model.Entities.CostkillerXml.allocation
{
    [XmlRoot("allocation")]
    public class Allocation
    {
        /// <remarks/>
        public int doc_id { get; set; }

        /// <remarks/>
        public string doc_number { get; set; }

        /// <remarks/>
        public string mpk { get; set; }

        /// <remarks/>
        public string lob { get; set; }

        /// <remarks/>
        public string proj { get; set; }

        /// <remarks/>
        public decimal amount { get; set; }

        /// <remarks/>
        public string currency { get; set; }

        /// <remarks/>
        public decimal currency_amount { get; set; }

        /// <remarks/>
        public int year { get; set; }

        /// <remarks/>
        public int month { get; set; }

        /// <remarks/>
        public string budget_symbol { get; set; }

        /// <remarks/>
        public string budget_type { get; set; }

        /// <remarks/>
        public bool is_paid { get; set; }

        [XmlArray("features")]
        [XmlArrayItem("feature")]
        public List<Feature> features { get; set; }

        public string workflow_status { get; set; }

    }
}