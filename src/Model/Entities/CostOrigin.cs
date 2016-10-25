using Predica.CostkillerLib.Model.Interfaces;

namespace Predica.CostkillerLib.Model.Entities
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
