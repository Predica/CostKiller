using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Predica.Costkiller.Core.Model.Entities;
using Predica.Costkiller.Core.Model.Interfaces;

namespace Predica.Costkiller.Core.Model.Requests
{
    public class NewBudgetLine : ICostkillerObject
    {
        private const string head = "<request><company_id>{0}</company_id><budgets><budget>";
        private const string yearBody = "<year>{0}</year>";
        private const string symbolBody = "<symbol>{0}</symbol>";
        private const string descriptionBody = "<description>{0}</description>";
        private const string bodyEnd = "</budget></budgets></request>";

        public NewBudgetLine(int companyId, LineOfBusiness lob, CostOrigin mpk, Project proj,
            string description = null, int? year = null)
        {
            this._companyId = companyId;
            this._description = description;
            this._year = year;
            this._lob = lob;
            this._mpk = mpk;
            this._proj = proj;

            _symbolName = string.Format("{0} {1} {2} {3}",
                _lob.CostType.ToString().Substring(0, 1),
                _mpk.Name,
                _lob.Name,
                _proj.Name);
            if (_symbolName.Length > 45)
            {
                Config.Logger?.LogWarning($"\nSymbol name \"{_symbolName}\" is longer than 45 characters - truncating...");
                _symbolName = _symbolName.Substring(0, 45);
            }

        }
        private string _symbolName = null;
        private int _companyId;
        private string _description = null;
        private int? _year = null;
        private Project _proj = null;
        private LineOfBusiness _lob = null;
        private CostOrigin _mpk = null;

        public string ToXmlString()
        {
            string body = string.Format(head, _companyId);
            if (_year != null)
                body = body + String.Format(yearBody, _year.Value);
            body = body + string.Format(symbolBody, _symbolName);
            if (_description != null)
                body = body + String.Format(descriptionBody, _description);
            body = body + _lob.ToXmlString();
            body = body + _proj.ToXmlParameterString();
            body = body + _mpk.ToXmlString();
            body = body + bodyEnd;
            return body;
        }
    }
}
