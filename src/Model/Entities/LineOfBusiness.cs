using Predica.CostkillerLib.Model.Enums;
using Predica.CostkillerLib.Model.Interfaces;

namespace Predica.CostkillerLib.Model.Entities
{
    /// <summary>
    /// LOB
    /// </summary>
    public class LineOfBusiness : ICostkillerObject
    {
        private string body = "<lob><symbol>{0}</symbol><type>{1}</type></lob>";

        public LineOfBusiness()
        {
            
        }

        public LineOfBusiness(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public CostType CostType { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public string ToXmlString()
        {
            return string.Format(body, Name, CostType.ToString().Substring(0, 1));
        }
    }
}
