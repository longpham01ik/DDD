using library_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.DAO
{
    public class BookCategoryDAO
    {
        private static BookCategoryDAO instance;

        public static BookCategoryDAO Instance
        {
            get { if (instance == null) instance = new BookCategoryDAO(); return BookCategoryDAO.instance; }
            private set { BookCategoryDAO.instance = value; }
        }

        private BookCategoryDAO() { }
        public List<BookCategoryDTO> SearchBookCategoryByName(string BookCategoryName)
        {

            List<BookCategoryDTO> list = new List<BookCategoryDTO>();

            // string query = string.Format("SELECT * FROM dbo.Author WHERE dbo.fuConvertToUnsign1(AuthorName) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", AuthorName);

            string query = "SELECT * FROM dbo.BookCategory WHERE dbo.fuConvertToUnsign1(BookCategoryName) LIKE N'%' + dbo.fuConvertToUnsign1(N'" + BookCategoryName + "') + '%'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BookCategoryDTO BookCategory = new BookCategoryDTO(item);
                list.Add(BookCategory);
            }

            return list;
        }
        public List<BookCategoryDTO> GetListBookCategory()
        {
            List<BookCategoryDTO> list = new List<BookCategoryDTO>();

            string query = "select * from BookCategory";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BookCategoryDTO category = new BookCategoryDTO(item);
                list.Add(category);
            }

            return list;
        }

        public BookCategoryDTO GetBookCategoryByID(string BookCategoryID)
        {
            BookCategoryDTO category = null;

            string query = "select * from BookCategory where BookCategoryID = " + BookCategoryID;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new BookCategoryDTO(item);
                return category;
            }

            return category;
        }

        public bool InsertBookCategory(string BookCategoryID, string BookCategoryName)
        {
            string query = "INSERT into BookCategory ([BookCategoryID], [BookCategoryName] ) VALUES  ( '" + BookCategoryID + "' , N'" + BookCategoryName + "')";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;



        }

        public bool UpdateBookCategory(string BookCategoryID, string BookCategoryName)
        {
            string query = "UPDATE dbo.BookCategory SET BookCategoryName = N'" + BookCategoryName + "'  WHERE BookCategoryID = '" + BookCategoryID + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteBookCategory(string BookCategoryID)
        {
            //  BillDAO.Instance.DeleteBillByBookID(BookID);

            string query = "Delete BookCategory where BookCategoryID = '" + BookCategoryID + "' ";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
