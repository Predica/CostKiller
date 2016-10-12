using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Predica.Costkiller.Core.Model.Enums;

namespace Predica.Costkiller.Core.Extensions
{
    public static class EnumExtensoins
    {
        public static string ToDocType(this DocumentType documentType)
        {
            return documentType.ToString().Substring(0, 1);
        }

        public static string ToCostkillerId(this ContractorCategory contractorCategory)
        {
            return contractorCategory.ToString().ToLower();
        }
    }
}
