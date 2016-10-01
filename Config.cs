using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Predica.Costkiller.Core.Model.Interfaces;

namespace Predica.Costkiller.Core
{
    public static class Config
    {
        public static ILogger Logger { get; set; }
        /// <summary>
        /// MPK/LOBs are retrieved from this dataSource. Create your own datasource and set it before creating new CostKiller object
        /// </summary>
        public static IDataSource DataSource { get; set; }
    }
}
