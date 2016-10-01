namespace Predica.Costkiller.Core.Model.Entities.CostkillerXml
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class DocumentItemAllocationsAllocation
    {
        /// <remarks/>
        public string Mpk { get; set; }

        /// <remarks/>
        public string Lob { get; set; }

        /// <remarks/>
        public string Proj { get; set; }

        /// <remarks/>
        public sbyte Amount { get; set; }

        /// <remarks/>
        public ushort Year { get; set; }

        /// <remarks/>
        public byte Month { get; set; }

        /// <remarks/>
        public string BudgetSymbol { get; set; }

        /// <remarks/>
        public object BudgetDesc { get; set; }

        /// <remarks/>
        public string BudgetType { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("feature", IsNullable = false)]
        public DocumentItemAllocationsAllocationFeature[] Features { get; set; }
    }
}