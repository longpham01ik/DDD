using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.DTO
{
    public class BookDTO
    {
        public BookDTO(string BookiD, string Booktitle, string AuthoriD, string PublishingCompanyiD, string BookCategoryiD,int Publishingyear, int price)
        {
            this.BookID = BookiD;
            this.BookTitle = Booktitle;
            this.AuthorID = AuthoriD;
            this.PublishingCompanyID = PublishingCompanyiD;
            this.BookCategoryID = BookCategoryiD;
            this.PublishingYear = Publishingyear;
            this.Price = price;
        }

        public BookDTO(DataRow row)
        {
            this.BookID = row["BookiD"].ToString();
            this.BookTitle = row["Booktitle"].ToString();
            this.AuthorID = row["AuthoriD"].ToString();
            this.PublishingCompanyID = row["PublishingCompanyiD"].ToString();
            this.BookCategoryID = row["BookCategoryiD"].ToString();
            this.PublishingYear = (int)row["Publishingyear"];
            this.Price = (int)row["price"];

        }

        private string BookiD;

        public string BookID
        {
            get { return BookiD; }
            set { BookiD = value; }
        }

        private string Booktitle;

        public string BookTitle
        {
            get { return Booktitle; }
            set { Booktitle = value; }
        }

        private string AuthoriD;

        public string AuthorID
        {
            get { return AuthoriD; }
            set { AuthoriD = value; }
        }       

        private string PublishingCompanyiD;

        public string PublishingCompanyID
        {
            get { return PublishingCompanyiD; }
            set { PublishingCompanyiD = value; }
        }

        private string BookCategoryiD;

        public string BookCategoryID
        {
            get { return BookCategoryiD; }
            set { BookCategoryiD = value; }
        }

        private int Publishingyear;
        public int PublishingYear
        {
            get { return Publishingyear; }
            set { Publishingyear = value; }
        }

        private int price;
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
