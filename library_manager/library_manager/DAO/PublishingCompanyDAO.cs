using library_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.DAO
{
    public class PublishingCompanyDAO
    {

        private static PublishingCompanyDAO instance;

        public static PublishingCompanyDAO Instance
        {
            get { if (instance == null) instance = new PublishingCompanyDAO(); return PublishingCompanyDAO.instance; }
            private set { PublishingCompanyDAO.instance = value; }
        }

        private PublishingCompanyDAO() { }

        public List<PublishingCompanyDTO> GetListPublishingCompany()
        {
            List<PublishingCompanyDTO> list = new List<PublishingCompanyDTO>();

            string query = "select * from PublishingCompany";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                PublishingCompanyDTO publishingCompany = new PublishingCompanyDTO(item);
                list.Add(publishingCompany);
            }

            return list;
        }

        public PublishingCompanyDTO GetPublishingCompanyByID(string PublishingCompanyID)
        {
            PublishingCompanyDTO publishingCompany = null;

            string query = "select * from PublishingCompany where PublishingCompanyID = " + PublishingCompanyID;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                publishingCompany = new PublishingCompanyDTO(item);
                return publishingCompany;
            }

            return publishingCompany;
        }

        public List<PublishingCompanyDTO> SearchPublishingCompanyByName(string PublishingCompanyName)
        {

            List<PublishingCompanyDTO> list = new List<PublishingCompanyDTO>();

            string query = "SELECT * FROM dbo.PublishingCompany WHERE dbo.fuConvertToUnsign1(PublishingCompanyName) LIKE N'%' + dbo.fuConvertToUnsign1(N'" + PublishingCompanyName + "') + '%'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                PublishingCompanyDTO PublishingCompany = new PublishingCompanyDTO(item);
                list.Add(PublishingCompany);
            }

            return list;
        }

        public bool InsertPublishingCompany(string PublishingCompanyID, string PublishingCompanyName, string Address,  int Hotline, string Email)
        {
            string query = "INSERT into PublishingCompany ([PublishingCompanyID], [PublishingCompanyName] ,[Address], [Hotline], [Email]) VALUES  ( '" + PublishingCompanyID + "' , N'" + PublishingCompanyName + "', '" + Address + "', '" + Hotline + "' , '" + Email + "' )";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;



        }

        public bool UpdatePublishingCompany(string PublishingCompanyID, string PublishingCompanyName, string Address, int Hotline, string Email)
        {
            string query = "UPDATE dbo.PublishingCompany SET PublishingCompanyName = N'" + PublishingCompanyName + "', Address = '" + Address + "', Hotline = '" + Hotline + "', Email = '" + Email + "' WHERE PublishingCompanyID = '" + PublishingCompanyID + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeletePublishingCompany(string PublishingCompanyID)
        {
            //  BillDAO.Instance.DeleteBillByBookID(BookID);

            string query = "Delete PublishingCompany where PublishingCompanyID = '" + PublishingCompanyID + "' ";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
