namespace BillingAPI
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml;

    public class Billing
    {
        private Uri accessUrl;
        private XmlNodeList actualResponse;
        private string authenticationToken;

        public Billing()
        {
        }

        public Billing(Uri AccessLink, string Token)
        {
            this.accessUrl = AccessLink;
            this.authenticationToken = Token;
        }

        public void CreateClient(Client currentClient)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(currentClient.GetCreateClientXml());
            WebRequest request = WebRequest.Create(this.accessUrl);
            request.Credentials = new NetworkCredential(this.authenticationToken, "X");
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                this.actualResponse = this.ProcessResponse(response);
            }
            catch (Exception exception)
            {
                throw new ApplicationException(exception.Message);
            }
        }

        public void CreateInvoice(Invoice currentInvoice)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(currentInvoice.GetInvoiceCreationXml());
            WebRequest request = WebRequest.Create(this.accessUrl);
            request.Credentials = new NetworkCredential(this.authenticationToken, "X");
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                this.actualResponse = this.ProcessResponse(response);
            }
            catch (Exception exception)
            {
                throw new ApplicationException(exception.Message);
            }
        }

        public void DeleteInvoice(Invoice currentInvoice)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(currentInvoice.GetInvoiceDeleteXml());
            WebRequest request = WebRequest.Create(this.accessUrl);
            request.Credentials = new NetworkCredential(this.authenticationToken, "X");
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                this.actualResponse = this.ProcessResponse(response);
            }
            catch (Exception exception)
            {
                throw new ApplicationException(exception.Message);
            }
        }

        public static Invoice RetrieveInvoice(int invoice)
        {
            Invoice invoice2 = new Invoice();
            invoice2.InvoiceFreshBooksId = invoice;
            return invoice2;
        }

        public void SendByEmailInvoice(Invoice currentInvoice)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(currentInvoice.GetInvoiceByEmailXml());
            WebRequest request = WebRequest.Create(this.accessUrl);
            request.Credentials = new NetworkCredential(this.authenticationToken, "X");
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                this.actualResponse = this.ProcessResponse(response);
            }
            catch (Exception exception)
            {
                throw new ApplicationException(exception.Message);
            }
        }

        public void SendByEmailInvoiceCustomMessage(Invoice currentInvoice,string subject,string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(currentInvoice.GetInvoiceByEmailXml(subject,message));
            WebRequest request = WebRequest.Create(this.accessUrl);
            request.Credentials = new NetworkCredential(this.authenticationToken, "X");
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                this.actualResponse = this.ProcessResponse(response);
            }
            catch (Exception exception)
            {
                throw new ApplicationException(exception.Message);
            }
        }

        public XmlNodeList ProcessResponse(HttpWebResponse response)
        {
            XmlDocument document = new XmlDocument();
            document.Load(response.GetResponseStream());
            XmlNodeList elementsByTagName = document.GetElementsByTagName("response");
            if (!elementsByTagName[0].Attributes["status"].Value.Equals("ok"))
            {
                throw new ApplicationException(elementsByTagName[0].FirstChild.InnerText);
            }
            return elementsByTagName;
        }

        public void UpdateInvoice(Invoice currentInvoice)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(currentInvoice.GetInvoiceUpdateXml());
            WebRequest request = WebRequest.Create(this.accessUrl);
            request.Credentials = new NetworkCredential(this.authenticationToken, "X");
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                this.actualResponse = this.ProcessResponse(response);
            }
            catch (Exception exception)
            {
                throw new ApplicationException(exception.Message);
            }
        }

        public Uri AccessUrl
        {
            get
            {
                return this.accessUrl;
            }
            set
            {
                this.accessUrl = value;
            }
        }

        public XmlNodeList ActualResponse
        {
            get
            {
                return this.actualResponse;
            }
            set
            {
                this.actualResponse = value;
            }
        }

        public string AuthenticationToken
        {
            get
            {
                return this.authenticationToken;
            }
            set
            {
                this.authenticationToken = value;
            }
        }
    }
}

