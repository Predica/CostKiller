using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Predica.Costkiller.Core.Model.Interfaces;

namespace Predica.Costkiller.Core.Model.Entities
{
    public class Project : ICostkillerParameter
    {
        public Project()
        {
            
        }

        public Project(string name)
        {
            this.Name = name;
        }

        private const string paramterBody = "<proj><symbol>{0}</symbol></proj>";
        private const string fullBody = "<proj><symbol>{0}</symbol><description>{1}</description></proj>";
        public string Name { get; set; }

        public string Description { get; set; }
        public string ToXmlParameterString()
        {
            return string.Format(paramterBody, Name);
        }

        public string ToXmlString()
        {
            return string.Format(fullBody, Name, Description);
        }
    }
}
