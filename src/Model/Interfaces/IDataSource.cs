using System.Collections.Generic;
using Predica.CostkillerLib.Model.Entities;

namespace Predica.CostkillerLib.Model.Interfaces
{
    /// <summary>
    /// Data source interface that holds MPK/LOBs
    /// </summary>
    public interface IDataSource
    {
        ICollection<LineOfBusiness> LineOfBusinesses { get; }
        ICollection<Project> Projects { get; }
        ICollection<CostOrigin> CostOrigins { get; }  
    }
}
