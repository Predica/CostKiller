using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Predica.Costkiller.Core.Model.Enums;

namespace Predica.Costkiller.Core.Model.Entities.CostkillerXml
{
    /// <remarks/>
    [XmlRoot("document")]
    public class Document
    {
        /// <remarks/>
        [XmlElement("doc_id")]
        public int DocId { get; set; }

        /// <remarks/>
        [XmlElement("contr_id")]
        public int ContrId { get; set; }

        /// <remarks/>
        [XmlElement("contr_data_id")]
        public int ContrDataId { get; set; }

        /// <remarks/>
        [XmlElement("doc_symbol")]
        public string DocSymbol { get; set; }

        [XmlElement("doc_type")]
        public string DocType { get; set; }

        public DocumentType DocumentType => GetDocumentType();

        /// <remarks/>
        [XmlElement("doc_number")]
        public string DocNumber { get; set; }

        /// <remarks/>
        [XmlElement("correction")]
        public int CorrectionInt { get; set; }

        public bool Correction => CorrectionInt == 1;

        [XmlElement("doc_sales_date")]
        public string DocSalesDate { get; set; }

        /// <remarks/>
        [XmlElement("doc_issue_date")]
        public string DocIssueDate { get; set; }

        [XmlElement("source_document_id")]
        public int CorrectedDocumentID { get; set; }

        /// <remarks/>
        [XmlElement("doc_reg_date")]
        public string DocRegDate { get; set; }

        /// <remarks/>
        [XmlElement("gl_year")]
        public int GlYear { get; set; }

        /// <remarks/>
        [XmlElement("gl_month")]
        public int GlMonth { get; set; }

        public DateTime BillingPeriod => DateTime.Parse($"{GlYear}-{GlMonth}");

        /// <remarks/>
        [XmlElement("payment_date")]
        public string PaymentDate { get; set; }

        /// <remarks/>
        [XmlElement("payment_type")]
        public string PaymentType { get; set; }

        /// <remarks/>
        [XmlElement("net")]
        public decimal Net { get; set; }

        /// <remarks/>
        [XmlElement("vat")]
        public decimal Vat { get; set; }

        /// <remarks/>
        [XmlElement("gross")]
        public decimal Gross { get; set; }

        /// <remarks/>
        [XmlElement("amount_to_pay")]
        public decimal AmountToPay { get; set; }

        /// <remarks/>
        [XmlElement("amount_paid")]
        public decimal AmountPaid { get; set; }

        /// <remarks/>
        [XmlElement("amount_remaining")]
        public decimal AmountRemaining { get; set; }

        /// <remarks/>
        [XmlElement("iban")]
        public string Iban { get; set; }

        /// <remarks/>
        [XmlElement("currency")]
        public string Currency { get; set; }

        /// <remarks/>
        [XmlElement("transaction_desc")]
        public string TransactionDesc { get; set; }

        /// <remarks/>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <remarks/>
        [XmlElement("remarks")]
        public object Remarks { get; set; }

        /// <remarks/>
        [XmlElement("contractor")]
        public DocumentContractor Contractor { get; set; }

        /// <remarks/>
        [XmlArray("items")]
        public DocumentItem[] Items { get; set; }

        public decimal exchange_rate { get; set; }

        /// <remarks/>
        public object Decrees { get; set; }

        public DocumentStatus GetDocumentStatus()
        {
            switch (Status)
            {
                case "A":
                    return DocumentStatus.Accepted;
                case "C":
                    return DocumentStatus.Corrected;
                default:
                    return DocumentStatus.Unknown;
            }
        }

        private DocumentType GetDocumentType()
        {
#if PROD
            switch (DocSymbol)
            {
                case "KO":
                case "FVS":
                case "PKD":
                    return DocumentType.Cost;
                //case "SP":
                //    return DocumentType.Sales;
                default:
                    return DocumentType.Unknown;
            }

#else
            switch (DocType)
            {
                case "C":
                    return DocumentType.Cost;
                case "S":
                    return DocumentType.Sales;
                default:
                    return DocumentType.Unknown;
            }
#endif

        }
    }
}