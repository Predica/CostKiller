namespace Predica.Costkiller.Core.Model.Requests
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class RequestBudget
    {
        /// <remarks/>
        public RequestBudgetLob Lob { get; set; }

        /// <remarks/>
        public RequestBudgetProj Proj { get; set; }

        /// <remarks/>
        public RequestBudgetMpk Mpk { get; set; }
    }
}