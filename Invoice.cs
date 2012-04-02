namespace BillingAPI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;

    public class Invoice
    {
        private string city = string.Empty;
        private int clientId = 0;
        private string code;
        private string country;
        private DateTime date;
        private int discount;
        private string firstName = string.Empty;
        private int invoiceFreshbooksId;
        private List<InvoiceItem> invoiceItems;
        private string lastName = string.Empty;
        private string notes = string.Empty;
        private string number = string.Empty;
        private string organization;
        private int purchaseOrderNumber;
        private string state;
        private InvoiceStatus status;
        private string street1;
        private string street2;
        private string terms = string.Empty;
        private string currencyCode = string.Empty;


        public Invoice()
        {
            this.Status = InvoiceStatus.draft;
            this.organization = string.Empty;
            this.street1 = string.Empty;
            this.street2 = string.Empty;
            this.state = string.Empty;
            this.country = string.Empty;
            this.code = string.Empty;
            this.invoiceItems = new List<InvoiceItem>();
            this.date = DateTime.Now;
            this.discount = 0;
            this.invoiceFreshbooksId = 0;
            this.purchaseOrderNumber = 0;
        }

        internal string GetInvoiceByEmailXml()
        {
            MemoryStream w = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(w, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("request");
            writer.WriteStartAttribute("method");
            writer.WriteValue("invoice.sendByEmail");
            writer.WriteEndAttribute();
            writer.WriteStartElement("invoice");
            writer.WriteStartElement("invoice_id");
            writer.WriteValue(this.invoiceFreshbooksId);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            string input = Encoding.UTF8.GetString(w.GetBuffer());
            Regex.Replace(input, "<.* />", "");
            return input;
        }

        internal string GetInvoiceByEmailXml(string subject,string message)
        {
            if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message))
            {
                throw new Exception("Subject and Message both must be defined");
            }


            MemoryStream w = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(w, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("request");
            writer.WriteStartAttribute("method");
            writer.WriteValue("invoice.sendByEmail");
            writer.WriteEndAttribute();
            writer.WriteStartElement("invoice");
            writer.WriteStartElement("invoice_id");
            writer.WriteValue(this.invoiceFreshbooksId);
            writer.WriteEndElement();

            writer.WriteStartElement("subject");
            writer.WriteValue(subject);
            writer.WriteEndElement();

            writer.WriteStartElement("message");
            writer.WriteValue(message);
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            string input = Encoding.UTF8.GetString(w.GetBuffer());
            Regex.Replace(input, "<.* />", "");
            return input;
        }

        internal string GetInvoiceCreationXml()
        {
            MemoryStream w = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(w, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("request");
            writer.WriteStartAttribute("method");
            writer.WriteValue("invoice.create");
            writer.WriteEndAttribute();
            writer.WriteStartElement("invoice");
            writer.WriteStartElement("client_id");
            writer.WriteValue(this.clientId);
            writer.WriteEndElement();
            writer.WriteStartElement("number");
            writer.WriteValue(this.number);
            writer.WriteEndElement();
            writer.WriteStartElement("status");
            writer.WriteValue(this.status.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("date");
            writer.WriteValue(this.date.ToString("yyyy-MM-dd"));
            writer.WriteEndElement();
            writer.WriteStartElement("po_number");
            writer.WriteValue(this.purchaseOrderNumber);
            writer.WriteEndElement();
            writer.WriteStartElement("discount");
            writer.WriteValue(this.discount);
            writer.WriteEndElement();
            writer.WriteStartElement("notes");
            writer.WriteValue(this.notes);
            writer.WriteEndElement();
            writer.WriteStartElement("terms");
            writer.WriteValue(this.terms);
            writer.WriteEndElement();
            writer.WriteStartElement("first_name");
            writer.WriteValue(this.firstName);
            writer.WriteEndElement();
            writer.WriteStartElement("last_name");
            writer.WriteValue(this.lastName);
            writer.WriteEndElement();
            writer.WriteStartElement("organization");
            writer.WriteValue(this.organization);
            writer.WriteEndElement();
            writer.WriteStartElement("p_street1");
            writer.WriteValue(this.street1);
            writer.WriteEndElement();
            writer.WriteStartElement("p_street2");
            writer.WriteValue(this.street2);
            writer.WriteEndElement();
            writer.WriteStartElement("p_city");
            writer.WriteValue(this.city);
            writer.WriteEndElement();
            writer.WriteStartElement("p_state");
            writer.WriteValue(this.state);
            writer.WriteEndElement();
            writer.WriteStartElement("p_country");
            writer.WriteValue(this.country);
            writer.WriteEndElement();
            writer.WriteStartElement("p_code");
            writer.WriteValue(this.code);
            writer.WriteEndElement();

            writer.WriteStartElement("currency_code");
            writer.WriteValue(this.currencyCode);
            writer.WriteEndElement();
        

            writer.WriteStartElement("lines");
            foreach (InvoiceItem item in this.invoiceItems)
            {
                writer.WriteStartElement("line");
                writer.WriteStartElement("name");
                writer.WriteValue(item.Name);
                writer.WriteEndElement();
                writer.WriteStartElement("description");
                writer.WriteValue(item.Description);
                writer.WriteEndElement();
                writer.WriteStartElement("unit_cost");
                writer.WriteValue(item.UnitCost);
                writer.WriteEndElement();
                writer.WriteStartElement("quantity");
                writer.WriteValue(item.Quantity);
                writer.WriteEndElement();
                writer.WriteStartElement("tax1_name");
                writer.WriteValue(item.Tax1Name);
                writer.WriteEndElement();
                writer.WriteStartElement("tax2_name");
                writer.WriteValue(item.Tax2Name);
                writer.WriteEndElement();
                writer.WriteStartElement("tax1_percent");
                writer.WriteValue(item.Tax1Percent);
                writer.WriteEndElement();
                writer.WriteStartElement("tax2_percent");
                writer.WriteValue(item.Tax2Percent);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            string input = Encoding.UTF8.GetString(w.GetBuffer());
            Regex.Replace(input, "<.* />", "");
            return input;
        }

        internal string GetInvoiceDeleteXml()
        {
            MemoryStream w = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(w, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("request");
            writer.WriteStartAttribute("method");
            writer.WriteValue("invoice.delete");
            writer.WriteEndAttribute();
            writer.WriteStartElement("invoice");
            writer.WriteStartElement("invoice_id");
            writer.WriteValue(this.invoiceFreshbooksId);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            string input = Encoding.UTF8.GetString(w.GetBuffer());
            Regex.Replace(input, "<.* />", "");
            return input;
        }

        internal string GetInvoiceUpdateXml()
        {
            MemoryStream w = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(w, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("request");
            writer.WriteStartAttribute("method");
            writer.WriteValue("invoice.update");
            writer.WriteEndAttribute();
            writer.WriteStartElement("invoice");
            writer.WriteStartElement("invoice_id");
            writer.WriteValue(this.invoiceFreshbooksId);
            writer.WriteEndElement();
            writer.WriteStartElement("client_id");
            writer.WriteValue(this.clientId);
            writer.WriteEndElement();
            writer.WriteStartElement("number");
            writer.WriteValue(this.number);
            writer.WriteEndElement();
            writer.WriteStartElement("status");
            writer.WriteValue(this.status.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("date");
            writer.WriteValue(this.date.ToString("yyyy-MM-dd"));
            writer.WriteEndElement();
            writer.WriteStartElement("po_number");
            writer.WriteValue(this.purchaseOrderNumber);
            writer.WriteEndElement();
            writer.WriteStartElement("discount");
            writer.WriteValue(this.discount);
            writer.WriteEndElement();
            writer.WriteStartElement("notes");
            writer.WriteValue(this.notes);
            writer.WriteEndElement();
            writer.WriteStartElement("terms");
            writer.WriteValue(this.terms);
            writer.WriteEndElement();
            writer.WriteStartElement("first_name");
            writer.WriteValue(this.firstName);
            writer.WriteEndElement();
            writer.WriteStartElement("last_name");
            writer.WriteValue(this.lastName);
            writer.WriteEndElement();
            writer.WriteStartElement("organization");
            writer.WriteValue(this.organization);
            writer.WriteEndElement();
            writer.WriteStartElement("p_street1");
            writer.WriteValue(this.street1);
            writer.WriteEndElement();
            writer.WriteStartElement("p_street2");
            writer.WriteValue(this.street2);
            writer.WriteEndElement();
            writer.WriteStartElement("p_city");
            writer.WriteValue(this.city);
            writer.WriteEndElement();
            writer.WriteStartElement("p_state");
            writer.WriteValue(this.state);
            writer.WriteEndElement();
            writer.WriteStartElement("p_country");
            writer.WriteValue(this.country);
            writer.WriteEndElement();
            writer.WriteStartElement("p_code");
            writer.WriteValue(this.code);
            writer.WriteEndElement();
        
            writer.WriteStartElement("currency_code");
            writer.WriteValue(this.currencyCode);
            writer.WriteEndElement();
        
            writer.WriteStartElement("lines");
            foreach (InvoiceItem item in this.invoiceItems)
            {
                writer.WriteStartElement("line");
                writer.WriteStartElement("name");
                writer.WriteValue(item.Name);
                writer.WriteEndElement();
                writer.WriteStartElement("description");
                writer.WriteValue(item.Description);
                writer.WriteEndElement();
                writer.WriteStartElement("unit_cost");
                writer.WriteValue(item.UnitCost);
                writer.WriteEndElement();
                writer.WriteStartElement("quantity");
                writer.WriteValue(item.Quantity);
                writer.WriteEndElement();
                writer.WriteStartElement("tax1_name");
                writer.WriteValue(item.Tax1Name);
                writer.WriteEndElement();
                writer.WriteStartElement("tax2_name");
                writer.WriteValue(item.Tax2Name);
                writer.WriteEndElement();
                writer.WriteStartElement("tax1_percent");
                writer.WriteValue(item.Tax1Percent);
                writer.WriteEndElement();
                writer.WriteStartElement("tax2_percent");
                writer.WriteValue(item.Tax2Percent);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            string input = Encoding.UTF8.GetString(w.GetBuffer());
            Regex.Replace(input, "<.* />", "");
            return input;
        }

        internal string GetInvoiceXml()
        {
            MemoryStream w = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(w, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("request");
            writer.WriteStartAttribute("method");
            writer.WriteValue("invoice.update");
            writer.WriteEndAttribute();
            writer.WriteStartElement("invoice");
            writer.WriteStartElement("invoice_id");
            writer.WriteValue(this.invoiceFreshbooksId);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            string input = Encoding.UTF8.GetString(w.GetBuffer());
            Regex.Replace(input, "<.* />", "");
            return input;
        }

        #region Properties

        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
            }
        }

        public int ClientID
        {
            get
            {
                return this.clientId;
            }
            set
            {
                this.clientId = value;
            }
        }

        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                this.country = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public int Discount
        {
            get
            {
                return this.discount;
            }
            set
            {
                this.discount = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public List<InvoiceItem> InvoceItems
        {
            get
            {
                return this.invoiceItems;
            }
            set
            {
                this.invoiceItems = value;
            }
        }

        public int InvoiceFreshBooksId
        {
            get
            {
                return this.invoiceFreshbooksId;
            }
            set
            {
                this.invoiceFreshbooksId = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public string Notes
        {
            get
            {
                return this.notes;
            }
            set
            {
                this.notes = value;
            }
        }

        public string Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }

        public string Organization
        {
            get
            {
                return this.organization;
            }
            set
            {
                this.organization = value;
            }
        }

        public int PurchaseOrderNumber
        {
            get
            {
                return this.purchaseOrderNumber;
            }
            set
            {
                this.purchaseOrderNumber = value;
            }
        }

        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }

        public InvoiceStatus Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        public string Street1
        {
            get
            {
                return this.street1;
            }
            set
            {
                this.street1 = value;
            }
        }

        public string Street2
        {
            get
            {
                return this.street2;
            }
            set
            {
                this.street2 = value;
            }
        }

        public string Terms
        {
            get
            {
                return this.terms;
            }
            set
            {
                this.terms = value;
            }
        }

        public string CurrencyCode
        {
            get 
            {
                return this.currencyCode; 
            }
            set
            {
                this.currencyCode = value;
            }

        }

        #endregion
    }
}

