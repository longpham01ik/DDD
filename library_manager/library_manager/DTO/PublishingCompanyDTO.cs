using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.DTO
{
    public class PublishingCompanyDTO
    {
        public PublishingCompanyDTO(string PublishingCompanyiD, string PublishingCompanyname, string address, int hotline, string email)
        {
            this.PublishingCompanyID = PublishingCompanyiD;
            this.PublishingCompanyName = PublishingCompanyname;
            this.Address = address;
            this.Hotline = hotline;
            this.Email = email;
        }

        public PublishingCompanyDTO(DataRow row)
        {
            this.PublishingCompanyID = row["PublishingCompanyiD"].ToString();
            this.PublishingCompanyName = row["PublishingCompanyname"].ToString();
            this.Address = row["address"].ToString();
            this.Hotline = (int)row["hotline"];
            this.Email = row["email"].ToString();
        }
        private string PublishingCompanyiD;

        public string PublishingCompanyID
        {
            get { return PublishingCompanyiD; }
            set { PublishingCompanyiD = value; }
        }
        private string PublishingCompanyname;

        public string PublishingCompanyName
        {
            get { return PublishingCompanyname; }
            set { PublishingCompanyname = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private int hotline;
        public int Hotline
        {
            get { return hotline; }
            set { hotline = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}
