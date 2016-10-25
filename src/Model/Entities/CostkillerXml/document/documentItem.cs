namespace Predica.CostkillerLib.Model.Entities.CostkillerXml
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class DocumentItem
    {
        /// <remarks/>
        public uint ItemId { get; set; }

        /// <remarks/>
        public byte OrderNumber { get; set; }

        /// <remarks/>
        public string Symbol { get; set; }

        /// <remarks/>
        public byte Corrected { get; set; }

        /// <remarks/>
        public uint CorrectedItemId { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CorrectedItemIdSpecified { get; set; }

        /// <remarks/>
        public sbyte NetPrice { get; set; }

        /// <remarks/>
        public byte Qty { get; set; }

        /// <remarks/>
        public object Unit { get; set; }

        /// <remarks/>
        public sbyte Net { get; set; }

        /// <remarks/>
        public byte VatRate { get; set; }

        /// <remarks/>
        public decimal Gross { get; set; }

        /// <remarks/>
        public byte CurrencyGrossPrice { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrencyGrossPriceSpecified { get; set; }

        /// <remarks/>
        public byte CurrencyNetPrice { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrencyNetPriceSpecified { get; set; }

        /// <remarks/>
        public byte CurrencyNetAmount { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrencyNetAmountSpecified { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public DocumentItemAllocations Allocations { get; set; }
    }
}