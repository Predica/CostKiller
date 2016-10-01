using System;
using System.Linq;

namespace Predica.Costkiller.Core
{
    /// <summary>
    /// Connection string handler that exposes properties like Address, API Key and Company ID
    /// </summary>
    public class ConfigStore
    {
        private const string _addressCID = "Address=";
        private const string _apiKeyCID = "ApiKey=";
        private const string _companyCID = "CompanyId=";
        private readonly string _configString;

        /// <summary>
        /// Connection string handler that exposes properties like Address, API Key and Company ID
        /// Accepted format: ID=123;API=ABC;
        /// Accepted IDs: Address, ApiKey, CompanyId
        /// For example: Address=http://XXX.costkiller.pl/;ApiKey=XXXXXXXXXX;CompanyId=XXX;
        /// </summary>
        /// <param name="secureString">Connection string</param>
        public ConfigStore(string secureString)
        {
            this._configString = secureString;

            string[] parameters = _configString.Split(';');
            Address = RetrieveConfig(parameters, _addressCID);
            ApiKey = RetrieveConfig(parameters, _apiKeyCID);
            CompanyId = Convert.ToInt32(RetrieveConfig(parameters, _companyCID));
        }

        private string RetrieveConfig(string[] sourceArray, string configId)
        {
            string source = sourceArray.FirstOrDefault(x => x.Contains(configId));
            if(source == null)
                throw new ArgumentException($"String does not contain {configId.Replace("=", String.Empty)}");

            return source.Remove(0, configId.Length)
                    .Replace(";", String.Empty);
        }

        public string Address { get; private set; }
        public string ApiKey { get; private set; }
        public int CompanyId { get; private set; }
    }
}
