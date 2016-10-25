using Predica.CostkillerLib.Model.Enums;

namespace Predica.CostkillerLib.Extensions
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
