using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Predica.Costkiller.Core.Model.Entities;

namespace Predica.Costkiller.Core.Model.Interfaces
{
    /// <summary>
    /// Data source interface that holds MPK/LOBs
    /// </summary>
    public interface IDataSource
    {
        ICollection<LineOfBusiness> LineOfBusinesses { get; set; }
        ICollection<Project> Projects { get; set; }
        ICollection<CostOrigin> CostOrigins { get; set; }  
    }
}
