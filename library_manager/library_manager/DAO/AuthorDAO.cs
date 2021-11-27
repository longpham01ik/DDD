using library_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.DAO
{
    public class AuthorDAO

    {
        private static AuthorDAO instance;

        public static AuthorDAO Instance
        {
            get { if (instance == null) instance = new AuthorDAO(); return AuthorDAO.instance; }
            private set { AuthorDAO.instance = value; }
        }

        private AuthorDAO() { }

        public List<AuthorDTO> GetListAuthor()
        {
            List<AuthorDTO> list = new List<AuthorDTO>();

            string query = "select * from Author";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                AuthorDTO author = new AuthorDTO(item);
                list.Add(author);
            }

            return list;
        }

        public List<AuthorDTO> SearchAuthorByName(string AuthorName)
        {

            List<AuthorDTO> list = new List<AuthorDTO>();

            // string query = string.Format("SELECT * FROM dbo.Author WHERE dbo.fuConvertToUnsign1(AuthorName) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", AuthorName);

            string query = "SELECT * FROM dbo.Author WHERE dbo.fuConvertToUnsign1(AuthorName) LIKE N'%' + dbo.fuConvertToUnsign1(N'" + AuthorName + "') + '%'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                AuthorDTO author = new AuthorDTO(item);
                list.Add(author);
            }

            return list;
        }
        public AuthorDTO GetAuthorByID(string AuthorID)
        {
            AuthorDTO author = null;

            string query = "select * from Author where AuthorID = " + AuthorID;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                author = new AuthorDTO(item);
                return author;
            }

            return author;

        }
        public bool InsertAuthor(string AuthorID, string AuthorName, string DoB)
        {
            string query = "INSERT into Author ([AuthorID], [AuthorName] ,[DoB]) VALUES  ( '" + AuthorID + "' , N'" + AuthorName + "', '" + DoB + "')";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;



        }

        public bool UpdateAuthor(string AuthorID, string AuthorName, string DoB)
        {
            string query = "UPDATE dbo.Author SET AuthorName = N'" + AuthorName + "', DoB = '" + DoB + "'  WHERE AuthorID = '" + AuthorID + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAuthor(string AuthorID)
        {
            //  BillDAO.Instance.DeleteBillByBookID(BookID);

            string query = "Delete Author where AuthorID = '" + AuthorID + "' ";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
