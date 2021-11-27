using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.DTO
{
    public class UserDTO
    {
        public UserDTO(string UseriD, string Username, DateTime? doB, string address, string email, int Phonenumber)
        {
            this.UserID = UseriD;
            this.UserName = Username;
            this.DoB = doB;
            this.Address = address;
            this.Email = email;
            this.PhoneNumber = Phonenumber;

        }

        public UserDTO(DataRow row)
        {
            this.UserID = row["UseriD"].ToString();
            this.UserName = row["Username"].ToString();
            this.DoB = (DateTime?)row["doB"];
            this.Address = row["address"].ToString();
            this.Email = row["email"].ToString();
            this.PhoneNumber = (int)row["Phonenumber"];

        }
        private string UseriD;

        public string UserID
        {
            get { return UseriD; }
            set { UseriD = value; }
        }
        private string Username;

        public string UserName
        {
            get { return Username; }
            set { Username = value; }
        }

        private string address;

        private DateTime? doB;

        public DateTime? DoB
        {
            get { return doB; }
            set { doB = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private int Phonenumber;
        public int PhoneNumber
        {
            get { return Phonenumber; }
            set { Phonenumber = value; }
        }
    }
}
