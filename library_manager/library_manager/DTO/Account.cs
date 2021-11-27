using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.DTO
{
    public class Account
    {
        public Account(string Username,  string Password = null)
        {
            this.UserName = Username;
            this.PassWord = Password;
        }

        public Account(DataRow row)
        {
            this.UserName = row["Username"].ToString();
            this.PassWord = row["Password"].ToString();
        }

        private string Username;

        public string UserName
        {
            get { return Username; }
            set { Username = value; }
        }

        private string Password;

        public string PassWord
        {
            get { return Password; }
            set { Password = value; }
        }


        
       
    }
}
