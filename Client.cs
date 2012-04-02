namespace BillingAPI
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;

    public class Client
    {
        private string email = string.Empty;
        private string fax = string.Empty;
        private string firstName = string.Empty;
        private int freshBookIdClient;
        private string homePhone = string.Empty;
        private string lastName = string.Empty;
        private string mobile = string.Empty;
        private string notes = string.Empty;
        private string organization = string.Empty;
        private string password = string.Empty;
        private string pcity = string.Empty;
        private string pcode = string.Empty;
        private string pcountry = string.Empty;
        private string pstate = string.Empty;
        private string pstreet1 = string.Empty;
        private string pstreet2 = string.Empty;
        private string scity = string.Empty;
        private string scode = string.Empty;
        private string scountry = string.Empty;
        private string sstate = string.Empty;
        private string sstreet1 = string.Empty;
        private string sstreet2 = string.Empty;
        private string username;
        private string workPhone = string.Empty;

        internal string GetCreateClientXml()
        {
            MemoryStream w = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(w, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("request");
            writer.WriteStartAttribute("method");
            writer.WriteValue("client.create");
            writer.WriteEndAttribute();
            writer.WriteStartElement("client");
            writer.WriteStartElement("first_name");
            writer.WriteValue(this.firstName);
            writer.WriteEndElement();
            writer.WriteStartElement("last_name");
            writer.WriteValue(this.lastName);
            writer.WriteEndElement();
            writer.WriteStartElement("organization");
            writer.WriteValue(this.organization);
            writer.WriteEndElement();
            writer.WriteStartElement("email");
            writer.WriteValue(this.email);
            writer.WriteEndElement();
            writer.WriteStartElement("username");
            writer.WriteValue(this.username);
            writer.WriteEndElement();
            writer.WriteStartElement("password");
            writer.WriteValue(this.password);
            writer.WriteEndElement();
            writer.WriteStartElement("work_phone");
            writer.WriteValue(this.workPhone);
            writer.WriteEndElement();
            writer.WriteStartElement("home_phone");
            writer.WriteValue(this.homePhone);
            writer.WriteEndElement();
            writer.WriteStartElement("mobile");
            writer.WriteValue(this.mobile);
            writer.WriteEndElement();
            writer.WriteStartElement("fax");
            writer.WriteValue(this.fax);
            writer.WriteEndElement();
            writer.WriteStartElement("notes");
            writer.WriteValue(this.notes);
            writer.WriteEndElement();
            writer.WriteStartElement("p_street1");
            writer.WriteValue(this.pstreet1);
            writer.WriteEndElement();
            writer.WriteStartElement("p_street2");
            writer.WriteValue(this.pstreet2);
            writer.WriteEndElement();
            writer.WriteStartElement("p_city");
            writer.WriteValue(this.pcity);
            writer.WriteEndElement();
            writer.WriteStartElement("p_state");
            writer.WriteValue(this.pstate);
            writer.WriteEndElement();
            writer.WriteStartElement("p_country");
            writer.WriteValue(this.pcountry);
            writer.WriteEndElement();
            writer.WriteStartElement("p_code");
            writer.WriteValue(this.pcode);
            writer.WriteEndElement();
            writer.WriteStartElement("s_street1");
            writer.WriteValue(this.sstreet1);
            writer.WriteEndElement();
            writer.WriteStartElement("s_street2");
            writer.WriteValue(this.sstreet2);
            writer.WriteEndElement();
            writer.WriteStartElement("s_city");
            writer.WriteValue(this.scity);
            writer.WriteEndElement();
            writer.WriteStartElement("s_state");
            writer.WriteValue(this.sstate);
            writer.WriteEndElement();
            writer.WriteStartElement("s_country");
            writer.WriteValue(this.scountry);
            writer.WriteEndElement();
            writer.WriteStartElement("s_code");
            writer.WriteValue(this.scode);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            string input = Encoding.UTF8.GetString(w.GetBuffer());
            Regex.Replace(input, "<.* />", "");
            return input;
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public string Fax
        {
            get
            {
                return this.fax;
            }
            set
            {
                this.fax = value;
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

        public int FreshBookIdClient
        {
            get
            {
                return this.freshBookIdClient;
            }
            set
            {
                this.freshBookIdClient = value;
            }
        }

        public string HomePhone
        {
            get
            {
                return this.homePhone;
            }
            set
            {
                this.homePhone = value;
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

        public string Mobile
        {
            get
            {
                return this.mobile;
            }
            set
            {
                this.mobile = value;
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

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public string PCity
        {
            get
            {
                return this.pcity;
            }
            set
            {
                this.pcity = value;
            }
        }

        public string PCode
        {
            get
            {
                return this.pcode;
            }
            set
            {
                this.pcode = value;
            }
        }

        public string PCountry
        {
            get
            {
                return this.pcountry;
            }
            set
            {
                this.pcountry = value;
            }
        }

        public string PState
        {
            get
            {
                return this.pstate;
            }
            set
            {
                this.pstate = value;
            }
        }

        public string PStreet1
        {
            get
            {
                return this.pstreet1;
            }
            set
            {
                this.pstreet1 = value;
            }
        }

        public string PStreet2
        {
            get
            {
                return this.pstreet2;
            }
            set
            {
                this.pstreet2 = value;
            }
        }

        public string SCity
        {
            get
            {
                return this.scity;
            }
            set
            {
                this.scity = value;
            }
        }

        public string SCode
        {
            get
            {
                return this.scode;
            }
            set
            {
                this.scode = value;
            }
        }

        public string SCountry
        {
            get
            {
                return this.scountry;
            }
            set
            {
                this.scountry = value;
            }
        }

        public string SState
        {
            get
            {
                return this.sstate;
            }
            set
            {
                this.sstate = value;
            }
        }

        public string SStreet1
        {
            get
            {
                return this.sstreet1;
            }
            set
            {
                this.sstreet1 = value;
            }
        }

        public string SStreet2
        {
            get
            {
                return this.sstreet2;
            }
            set
            {
                this.sstreet2 = value;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
            }
        }

        public string WorkPhone
        {
            get
            {
                return this.workPhone;
            }
            set
            {
                this.workPhone = value;
            }
        }
    }
}

