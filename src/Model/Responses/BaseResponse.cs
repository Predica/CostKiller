using System.Xml.Serialization;

namespace Predica.CostkillerLib.Model.Responses
{
    [XmlRoot("response")]
    public class BaseResponse
    {
        public bool success { get; set; }
        public string code { get; set; }
        public string error { get; set; }
    }
}
