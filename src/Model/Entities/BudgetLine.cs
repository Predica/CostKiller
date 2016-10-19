using Predica.CostkillerLib.Model.Enums;

namespace Predica.CostkillerLib.Model.Entities
{
    public class BudgetLine
    {
        public CostType Type { get; set; }
        public LineOfBusiness LineOfBusiness { get; set; }
        public Project Project { get; set; }
    }
}
