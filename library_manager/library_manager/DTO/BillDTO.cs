using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.DTO
{
    public class BillDTO
    {
        public BillDTO(string BilliD, string UseriD, string BookiD, DateTime? bookLoanDay, DateTime? bookReturnDay, string note )
        {
            this.BillID = BilliD;
            this.UserID = UseriD;
            this.BookID = BookiD;
            this.BookLoanDay = bookLoanDay;
            this.BookReturnDay = bookReturnDay;
            this.Note = note;
        }

        public BillDTO(DataRow row)
        {
            this.BillID = row["BilliD"].ToString();
            this.UserID = row["UseriD"].ToString();
            this.BookID = row["BookiD"].ToString();
            this.BookLoanDay = (DateTime?)row["bookLoanDay"];

            var bookReturnDayTemp = row["bookReturnDay"];
            if (bookReturnDayTemp.ToString() != "")
                this.BookReturnDay = (DateTime?)bookReturnDayTemp;
            this.Note = row["note"].ToString();

        }

        private string BilliD;

        public string BillID
        {
            get { return BilliD; }
            set { BilliD = value; }
        }

        private string UseriD;

        public string UserID
        {
            get { return UseriD; }
            set { UseriD = value; }
        }

        private string BookiD;

        public string BookID
        {
            get { return BookiD; }
            set { BookiD = value; }
        }

        private DateTime? bookReturnDay;

        public DateTime? BookReturnDay
        {
            get { return bookReturnDay; }
            set { bookReturnDay = value; }
        }

        private DateTime? bookLoanDay;

        public DateTime? BookLoanDay
        {
            get { return bookLoanDay; }
            set { bookLoanDay = value; }
        }

         
        private string note;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }
    }
}
