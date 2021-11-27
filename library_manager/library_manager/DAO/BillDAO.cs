using library_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }

        public void DeleteBillByBookID(string BookID)
        {
            DataProvider.Instance.ExecuteQuery("delete dbo.Bill WHERE BookID = " + BookID);
        }


        public List<BillDTO> GetListBill()
        {
            List<BillDTO> list = new List<BillDTO>();

            string query = "select * from Bill";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BillDTO bill = new BillDTO(item);
                list.Add(bill);
            }

            return list;
        }

            

            public bool InsertBill(string BillID, string UserID, string BookID, string BookLoanDay, string BookReturnDay, string Note)
            {
                string query = "INSERT into Bill ([BillID], [UserID], [BookID] ,[BookLoanDay], [BookReturnDay], [Note]) VALUES  ( '" + BillID + "' , '" + UserID + "', '" + BookID + "', '" + BookLoanDay + "' , '" + BookReturnDay + "' , N'" + Note + "' )";
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;



            }

            public bool UpdateBill(string BillID, string UserID, string BookID, string BookLoanDay, string BookReturnDay, string Note)
            {
                string query = "UPDATE dbo.Bill SET UserID = '" + UserID + "', BookID = '" + BookID + "', BookLoanDay = '" + BookLoanDay + "',BookReturnDay = '" + BookReturnDay + "', Note = N'" + Note + "'  WHERE BillID = '" + BillID + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }

            public bool DeleteBill(string BillID)
            {

                string query = "Delete Bill where BillID = '" + BillID + "' ";
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
        
    }
}
