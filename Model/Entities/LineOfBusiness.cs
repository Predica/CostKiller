using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Predica.Costkiller.Core.Model.Enums;
using Predica.Costkiller.Core.Model.Interfaces;

namespace Predica.Costkiller.Core.Model.Entities
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
