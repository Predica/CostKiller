using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predica.Costkiller.Core.Model.Interfaces
{
    interface ICostkillerParameter : ICostkillerObject
    {
        string ToXmlParameterString();
    }
}
