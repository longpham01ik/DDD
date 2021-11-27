using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.DTO
{
    public class AuthorDTO
    {
        public AuthorDTO(string AuthoriD, string Authorname,DateTime? doB)
        {
            this.AuthorID = AuthoriD;
            this.AuthorName = Authorname;
            this.DoB = doB;
        }

        public AuthorDTO(DataRow row)
        {
            this.AuthorID = row["AuthoriD"].ToString();
            this.AuthorName = row["Authorname"].ToString();
            this.DoB = (DateTime?)row["doB"];
        }
        private string AuthoriD;

        public string AuthorID
        {
            get { return AuthoriD; }
            set { AuthoriD = value; }
        }
        private string Authorname;

        public string AuthorName
        {
            get { return Authorname; }
            set { Authorname = value; }
        }

        private DateTime? doB;

        public DateTime? DoB
        {
            get { return doB; }
            set { doB = value; }
        }

    }
}
