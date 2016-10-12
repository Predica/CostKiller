namespace Predica.Costkiller.Core.Model.Requests
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Request
    {
        /// <remarks/>
        public byte CompanyId { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("budget", IsNullable = false)]
        public RequestBudget[] Budgets { get; set; }
    }
}
