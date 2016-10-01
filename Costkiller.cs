using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Predica.Costkiller.Core.Diagnostics;
using Predica.Costkiller.Core.Extensions;
using Predica.Costkiller.Core.Model.Entities;
using Predica.Costkiller.Core.Model.Entities.CostkillerXml;
using Predica.Costkiller.Core.Model.Entities.CostkillerXml.document;
using Predica.Costkiller.Core.Model.Enums;
using Predica.Costkiller.Core.Model.Exceptions;
using Predica.Costkiller.Core.Model.Interfaces;
using Predica.Costkiller.Core.Model.Requests;
using Predica.Costkiller.Core.Model.Responses;

namespace Predica.Costkiller.Core
{
    /// <summary>
    /// Costkiller API Client
    /// </summary>
    public class Costkiller : IDisposable
    {

        #region Constructors
        public Costkiller()
        {

        }
        public Costkiller(string address, string apiKey, int companyId)
            : this(new Uri(address), apiKey, companyId)
        {
            //Overload with new Uri(address)
        }
        public Costkiller(Uri address, string apiKey, int companyId)
        {
            _address = address;
            _apiKey = apiKey;
            _companyId = companyId;
        }

        public Costkiller(ConfigStore confgStore) :
            this(confgStore.Address, confgStore.ApiKey, confgStore.CompanyId)
        {

        }
        #endregion

        #region Private Fields

        private Uri _address = null;
        private static HttpClient _client = null;
        private string _apiKey = null;
        private readonly int _companyId;
        private const string DateTimeFormat = "yyyy-MM-dd";
        //Setting this option to false will enable special HttpClient features like counting requests, etc.
        private const bool IsBareboneClient = false;
        #endregion

        #region Private Methods

        private HttpClient CreateClient()
        {
            HttpClient client;
            if (IsBareboneClient)
                client = new HttpClient();
            else
                client = new HttpClient(new RequestCountHandler(new HttpClientHandler()));
            client.BaseAddress = _address;
            return client;
        }

        #endregion
        
        #region Projects

        /// <summary>
        /// Adds new project to the project list in the budget menu
        /// </summary>
        public async Task<BaseResponse> ProjectAdd(Project project)
        {
            const string method = "CK_API_BUDGET_PROJ_ADD";
            if (project.Name.Length > 45)
                throw new ArgumentOutOfRangeException(nameof(project.Name), project.Name, "Project name cannot be longer than 45 characters");
            string payload = $"<request><company_id>{_companyId}</company_id><dimensions><proj><symbol>{project.Name}</symbol><description>{project.Description}</description></proj></dimensions></request>";
            var response = await Client.GetAsync(GetUrl(method, payload));
            var xmlResponse = await response.Content.ReadAsAsync<BaseResponse>();
            if (xmlResponse.success)
            {
                return xmlResponse;
            }
            throw new CostkillerException(xmlResponse, response.RequestMessage);
        }

        /// <summary>
        /// Deactivates a project from the budget line
        /// </summary>
        /// <param name="projectName">Costkiller's symbol</param>
        /// <returns></returns>
        public async Task<BaseResponse> ProjectDelete(string projectName)
        {
            const string method = "CK_API_BUDGET_PROJ_DELETE";
            if (projectName.Length > 45)
                throw new ArgumentOutOfRangeException(nameof(projectName), projectName, "Project name cannot be longer than 45 characters");
            string payload = $"<request><company_id>{_companyId}</company_id><dimensions><proj><symbol>{projectName}</symbol></proj></dimensions></request>";
            var response = await Client.GetAsync(GetUrl(method, payload));
            var xmlResponse = await response.Content.ReadAsAsync<BaseResponse>();
            if (xmlResponse.success)
            {
                return xmlResponse;
            }
            if (xmlResponse.error != "System removed 0 of 1 PROJs.")
                throw new CostkillerException(xmlResponse, response.RequestMessage);
            return xmlResponse;
        }
        #endregion

        #region Budget Lines
        /// <summary>
        /// Creates all budget lines combinations for a project
        /// </summary>
        /// <param name="projectName">Costkiller symbol</param>
        /// <returns>Progress 0...100 in percents</returns>
        public IEnumerable<double> AddBudgetLines(string projectName)
        {
            const string method = "CK_API_BUDGET_SYMBOL_ADD";
            if (projectName.Length > 45)
                throw new ArgumentOutOfRangeException(nameof(projectName), projectName, "Project name cannot be longer than 45 characters");
            int totalRequests = Config.DataSource.CostOrigins.Count * Config.DataSource.LineOfBusinesses.Count;
            double requestsProcessed = 0;
            foreach (var costOrigin in Config.DataSource.CostOrigins)
            {
                foreach (var lineOfBusiness in Config.DataSource.LineOfBusinesses)
                {
                    var tempProject = new Project() { Name = projectName };
                    var budgetLine = new NewBudgetLine(_companyId, lineOfBusiness, costOrigin, tempProject, String.Empty);

                    string payload = budgetLine.ToXmlString();
                    var response = Client.GetAsync(GetUrl(method, payload)).Result;
                    var xmlResponse = response.Content.ReadAsAsync<BaseResponse>().Result;
                    if (xmlResponse.success)
                    {
                        requestsProcessed++;
                        yield return requestsProcessed / totalRequests * 100; //Progress in percents
                    }
                    else
                    {
                        //Ignore zdublowany
                        if (!xmlResponse.error.Contains("zdublowany"))
                            throw new CostkillerException(xmlResponse, response.RequestMessage);
                    }
                }
            }
        }

        /// <summary>
        /// Creates all project lines for a project without returning progress 
        /// </summary>
        /// <param name="projectName">Project code (CRM) or symbol (CK)</param>
        public void AddBudgetLinesSilent(string projectName)
        {
            foreach (var progress in AddBudgetLines(projectName))
            {
                ;
            }
        }
        #endregion

        #region Documents
        /// <summary>
        /// Get single document
        /// </summary>
        /// <param name="id">Document ID</param>
        /// <returns></returns>
        public async Task<Document> GetDocuments(int id)
        {
            const string method = "CK_API_DOC_GET";
            string payload = $"<request><company_id>{_companyId}</company_id><doc_id>{id}</doc_id><ext_empl_data>1</ext_empl_data><ext_contr_data>1</ext_contr_data><items>1</items><allocations>1</allocations><decrees>1</decrees><vat>1</vat></request>";
            var response = await Client.GetAsync(GetUrl(method, payload));
            var doc = await ReadXml<Document>(response, "document");
            return doc;
        }

        public async Task<List<Document>> SearchDocuments(int monthFrom = 1, int monthTo = 12, int? year = null, DateType dateType = DateType.doc_book_date, DocumentType docType = DocumentType.Unknown)
        {
            //consts
            const int pageSize = 50;
            const string method = "CK_API_DOC_SEARCH";

            //date checks
            if (year == null)
                year = DateTime.Now.Year;
            if (monthFrom < 1 || monthFrom > 12)
                throw new ArgumentOutOfRangeException(nameof(monthFrom));
            if (monthTo < 1 || monthTo > 12)
                throw new ArgumentOutOfRangeException(nameof(monthTo));

            //optional tags initialization
            string docTypeTag = string.Empty;
            if (docType != DocumentType.Unknown)
                docTypeTag = $"<doc_type>{docType.ToDocType()}</doc_type>";

            //deftault variables initalization
            var dateRange = GetDateRange(monthFrom, monthTo, year.Value);
            var completeDocumentsList = new List<Document>();
            int pageNumber = 0;
            int lastDownloadCount = 0;
            do
            {
                string payload = $"<request><company_id>{_companyId}</company_id><page_number>{pageNumber}</page_number><page_size>{pageSize}</page_size>{docTypeTag}<date_type>{dateType}</date_type><date_from>{dateRange.Item1}</date_from><date_to>{dateRange.Item2}</date_to></request>";
                var response = await Client.GetAsync(GetUrl(method, payload));
                string xml = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode == false)
                    throw new CostkillerException(response, response.RequestMessage);
                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.LoadXml(xml);
                var docNode = XmlDoc.SelectSingleNode("/response/documents");
                var documentString = docNode.OuterXml;
                var serializer = new XmlSerializer(typeof(DocumentHolder));
                using (var reader = new StringReader(documentString))
                {
                    var documents = (DocumentHolder)serializer.Deserialize(reader);
                    completeDocumentsList.AddRange(documents.Documents);
                    lastDownloadCount = documents.Documents.Count();
                }
                pageNumber++;
            } while (lastDownloadCount == pageSize);

            return completeDocumentsList;
        }

        /// <summary>
        /// Returns tuple of Costkiller formatted date times
        /// </summary>
        /// <param name="monthFrom"></param>
        /// <param name="monthTo"></param>
        /// <param name="year"></param>
        /// <returns>Item 1 = fromDateTime, Item2 = toDateTime</returns>
        private Tuple<string, string> GetDateRange(int monthFrom, int monthTo, int year)
        {
            var fromDateTime = new DateTime(year, monthFrom, 1);
            var toDateTime = new DateTime(year, monthTo, DateTime.DaysInMonth(year, monthTo));

            return new Tuple<string, string>(
                DateTimeToCostkillerFormat(fromDateTime),
                DateTimeToCostkillerFormat(toDateTime));
        }

        private string DateTimeToCostkillerFormat(DateTime date) => $"{date.Year}-{date.Month.ToString("D2")}-{date.Day.ToString("D2")}";

        #endregion

        #region Allocations
        public async Task<List<Allocation>> GetAllocations(int monthFrom = 1, int monthTo = 12, int? year = null)
        {
            const string method = "CK_API_ALLOCATIONS_SEARCH";
            if (year == null)
                year = DateTime.Now.Year;
            if (monthFrom < 1 || monthFrom > 12)
                throw new ArgumentOutOfRangeException(nameof(monthFrom));
            if (monthTo < 1 || monthTo > 12)
                throw new ArgumentOutOfRangeException(nameof(monthTo));           
            string payload = $"<request><company_id>{_companyId}</company_id><year>{year}</year><month_from>{monthFrom}</month_from><month_to>{monthTo}</month_to></request>";
            var response = await Client.GetAsync(GetUrl(method, payload));
            var allocationsHolder = await ReadXml<AllocationHolder>(response, "allocations");
            return allocationsHolder.Allocations;
        }
        #endregion

        public async Task<List<DocumentContractor>> SearchContractors(ContractorCategory category = ContractorCategory.Contractor, string nip = null, string pesel = null, string contractorExternalId = null, bool? onlyNotImported = null)
        {
            const string method = "CK_API_CONTRACTOR_SEARCH";
            //consts
            const int pageSize = 50;
            var OptionalParametersList = new List<string>();

            if (!string.IsNullOrWhiteSpace(nip))
                OptionalParametersList.Add($"<nip>{nip}</nip>");
            if (!string.IsNullOrWhiteSpace(pesel))
                OptionalParametersList.Add($"<pesel>{pesel}</pesel>");
            if (!string.IsNullOrWhiteSpace(contractorExternalId))
                OptionalParametersList.Add($"<contr_external_id>{contractorExternalId}</contr_external_id>");
            if (onlyNotImported.HasValue)
                OptionalParametersList.Add($"<only_not_imported>{onlyNotImported.Value}</only_not_imported>");

            string optionalTags = string.Join(string.Empty, OptionalParametersList);

            var completeDocumentsList = new List<DocumentContractor>();
            int pageNumber = 0;
            int lastDownloadCount = 0;
            do
            {
                string payload = $"<request><company_id>{_companyId}</company_id><page_number>{pageNumber}</page_number><page_size>{pageSize}</page_size><category>{category.ToCostkillerId()}</category>{optionalTags}</request>";
                var response = await Client.GetAsync(GetUrl(method, payload));
                string xml = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode == false)
                    throw new CostkillerException(response, response.RequestMessage);
                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.LoadXml(xml);
                var docNode = XmlDoc.SelectSingleNode("/response/contractors");
                var documentString = docNode.OuterXml;
                var serializer = new XmlSerializer(typeof(ContractorHolder));
                using (var reader = new StringReader(documentString))
                {
                    var documents = (ContractorHolder)serializer.Deserialize(reader);
                    completeDocumentsList.AddRange(documents.Contractors);
                    lastDownloadCount = documents.Contractors.Count();
                }
                pageNumber++;
            } while (lastDownloadCount == pageSize);

            return completeDocumentsList;
        }

        #region Util Methods

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <param name="arrayRootName"></param>
        /// <returns></returns>
        private async Task<T> ReadXml<T>(HttpResponseMessage response, string arrayRootName)
        {
            var xml = await response.Content.ReadAsStringAsync();
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.LoadXml(xml);
            string arrayRoot = arrayRootName.ToLower();
            var docNode = XmlDoc.SelectSingleNode("/response/" + arrayRoot);
            if (docNode != null)
            {
                var documentString = docNode.OuterXml;
                var serializer = new XmlSerializer(typeof(T));
                using (var reader = new StringReader(documentString))
                {
                    var documents = (T)serializer.Deserialize(reader);
                    return documents;
                }
            }
            throw new CostkillerException(response, response.RequestMessage);
        }

        private string GetUrl(string method, string payload)
        {
            return GetUrl(method) + "&request=" + Uri.EscapeDataString(payload.Replace("&", "&amp;"));
        }

        private string GetUrl(string method)
        {
            return $"/api-client?key={_apiKey}&format=xml&method={method}";
        } 
        #endregion
        public HttpClient Client => _client ?? (_client = CreateClient());

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
