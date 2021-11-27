using library_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace library_manager.DAO
{
    public class BookDAO
    {
        private static BookDAO instance;

        public static BookDAO Instance
        {
            get { if (instance == null) instance = new BookDAO(); return BookDAO.instance; }
            private set { BookDAO.instance = value; }
        }

        private BookDAO() { }
        /*
        public List<BookDTO> GetFoodByCategoryID(int id)
        {
            List<BookDTO> list = new List<BookDTO>();

            string query = "select * from Food where idCategory = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BookDTO book = new BookDTO(item);
                list.Add(book);
            }

            return list;
        }
        */
        public List<BookDTO> GetListBook()
        {
            List<BookDTO> list = new List<BookDTO>();

            string query = "select * from Book";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BookDTO book = new BookDTO(item);
                list.Add(book);
            }

            return list;
        }

        public List<BookDTO> SearchBookByName(string BookTitle)
        {

            List<BookDTO> list = new List<BookDTO>();

            // string query = string.Format("SELECT * FROM dbo.Book WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", BookTitle);

            string query = "SELECT * FROM dbo.Book WHERE dbo.fuConvertToUnsign1(BookTitle) LIKE N'%' + dbo.fuConvertToUnsign1(N'" + BookTitle + "') + '%'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BookDTO book = new BookDTO(item);
                list.Add(book);
            }

            return list;
        }

        public bool InsertBook(string BookID, string BookTitle, string AuthorID, string PublishingCompanyID, string BookCategoryID, int PublishingYear, int Price)
        {
            string query = "INSERT into Book ([BookID], [BookTitle] ,[AuthorID],  [PublishingCompanyID], [BookCategoryID], [PublishingYear], [Price]) VALUES  ( '" + BookID + "' , N'" + BookTitle + "', '" + AuthorID + "', '" + PublishingCompanyID + "' , '" + BookCategoryID + "' , '" + PublishingYear + "' , '" + Price + "')";
            //  string query = string.Format("INSERT into Book (BookID, BookTitle, AuthorID, PublishingCompanyID, BookCategoryID, PublishingYear, Price) VALUES  ('{0}', N'{1}', '{2}', '{4}', '{5}', {6}), {7}", BookID, BookTitle, AuthorID, PublishingCompanyID, BookCategoryID, PublishingYear, Price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;



        }

        public bool UpdateBook( string BookID, string BookTitle, string AuthorID, string PublishingCompanyID, string BookCategoryID, int PublishingYear, int Price)
        {
            //string query = string.Format("UPDATE dbo.Book SET BookTitle = N'{0}', AuthorID = '{1}', PublishingCompanyID = '{2}',BookCategoryID = '{3}', PublishingYear = {4}, Price = {5}  WHERE BookID = '{6}'", BookTitle, AuthorID, PublishingCompanyID, BookCategoryID, PublishingYear, Price, BookID);
            string query = "UPDATE dbo.Book SET BookTitle = N'" + BookTitle + "', AuthorID = '" + AuthorID + "', PublishingCompanyID = '" + PublishingCompanyID + "',BookCategoryID = '" + BookCategoryID + "', PublishingYear = '" + PublishingYear + "', Price = '" + Price + "'  WHERE BookID = '" + BookID + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteBook(string BookID)
        {
          //  BillDAO.Instance.DeleteBillByBookID(BookID);

            // string query = string.Format("Delete Book where BookID= {0}", BookID);
             string query = "Delete Book where BookID = '" + BookID + "' ";
             int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
