using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace library_manager.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string UserName, string PassWord)
        {
            /* string query = "SELECT * FROM Account WHERE UserName = '" + UserName + "' AND PassWord = '" + PassWord + "' ";

            DataTable result = DataProvider.Instance.ExecuteQuery(query); */
            string query = "USP_Login @UserName , @PassWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { UserName, PassWord });

            return result.Rows.Count > 0;
        }
    }
}
