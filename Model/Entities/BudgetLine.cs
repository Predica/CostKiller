using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Predica.Costkiller.Core.Model.Enums;

namespace Predica.Costkiller.Core.Model.Entities
{
    public class BudgetLine
    {
        public CostType Type { get; set; }
        public LineOfBusiness LineOfBusiness { get; set; }
        public Project Project { get; set; }
    }
}
