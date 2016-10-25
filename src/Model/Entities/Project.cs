using Predica.CostkillerLib.Model.Interfaces;

namespace Predica.CostkillerLib.Model.Entities
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
