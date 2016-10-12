using System;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Predica.Costkiller.Core.Model.Enums;

namespace Predica.Costkiller.Core.Model.Entities.CostkillerXml
{
    /// <remarks/>
    [XmlRoot("contractor")]
    public class DocumentContractor
    {
        /// <remarks/>
        [XmlElement("contr_id")]
        public int ContrId { get; set; }

        /// <remarks/>
        [XmlElement("contr_data_id")]
        public int ContrDataId { get; set; }

        ///// <remarks/>
        //public string Code { get; set; }

        /// <remarks/>
        [XmlElement("category")]
        public string Category { get; set; }

        /// <remarks/>
        [XmlElement("active")]
        public bool Active { get; set; }

        /// <remarks/>
        [XmlElement("name")]
        public string Name { get; set; }

        ///// <remarks/>
        //public object Nip { get; set; }

        /// <remarks/>
        //public string Street { get; set; }

        ///// <remarks/>
        //public byte StreetNumber { get; set; }

        ///// <remarks/>
        //public object PlaceNumber { get; set; }

        ///// <remarks/>
        //public string City { get; set; }

        ///// <remarks/>
        //public ushort ZipCode { get; set; }

        /// <remarks/>
        [XmlElement("country")]
        public string Country { get; set; }

        ///// <remarks/>
        //public string PaymentType { get; set; }

        ///// <remarks/>
        //public byte PaymentDate { get; set; }

        ///// <remarks/>
        //public string Bank { get; set; }

        /// <remarks/>
        [XmlElement("iban")]
        public string Iban { get; set; }

        ///// <remarks/>
        //public object ContactPerson { get; set; }

        ///// <remarks/>
        //public object ContactPersonPhone { get; set; }

        ///// <remarks/>
        //public object ContactPersonMobile { get; set; }

        ///// <remarks/>
        //public object ContactPersonEmail { get; set; }

        ///// <remarks/>
        //public byte CashAccScheme { get; set; }

        ///// <remarks/>
        //public object Remarks { get; set; }
    }
}