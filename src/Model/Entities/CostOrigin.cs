using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Predica.Costkiller.Core.Model.Interfaces;

namespace Predica.Costkiller.Core.Model.Entities
{
    /// <summary>
    /// MPK
    /// </summary>
    public class CostOrigin : ICostkillerObject
    {
        private const string body = "<mpk><symbol>{0}</symbol></mpk>";
        public CostOrigin()
        {
            
        }
        public CostOrigin(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public string ToXmlString()
        {
            return string.Format(body, Name);
        }
    }
}
