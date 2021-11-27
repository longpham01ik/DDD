using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.DTO
{
    public class BookCategoryDTO
    {
        public BookCategoryDTO(string BookCategoryiD, string BookCategoryname)
        {
            this.BookCategoryID = BookCategoryiD;
            this.BookCategoryName = BookCategoryname;
        }

        public BookCategoryDTO(DataRow row)
        {
            this.BookCategoryID = row["BookCategoryiD"].ToString();
            this.BookCategoryName = row["BookCategoryname"].ToString();
        }
        private string BookCategoryiD;

        public string BookCategoryID
        {
            get { return BookCategoryiD; }
            set { BookCategoryiD = value; }
        }
        private string BookCategoryname;

        public string BookCategoryName
        {
            get { return BookCategoryname; }
            set { BookCategoryname = value; }
        }
    }
}
