using library_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.DAO
{
    public class UserDAO
    {
        private static UserDAO instance;

        public static UserDAO Instance
        {
            get { if (instance == null) instance = new UserDAO(); return UserDAO.instance; }
            private set { UserDAO.instance = value; }
        }

        private UserDAO() { }

        public List<UserDTO> GetListUser()
        {
            List<UserDTO> list = new List<UserDTO>();

            string query = "select * from _User";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                UserDTO User = new UserDTO(item);
                list.Add(User);
            }

            return list;
        }

        public UserDTO GetUserByID(string UserID)
        {
            UserDTO User = null;

            string query = "select * from _User where UserID = " + UserID;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                User = new UserDTO(item);
                return User;
            }

            return User;
        }

        public List<UserDTO> SearchUserByName(string UserName)
        {

            List<UserDTO> list = new List<UserDTO>();

            string query = "SELECT * FROM _User WHERE dbo.fuConvertToUnsign1(UserName) LIKE N'%' + dbo.fuConvertToUnsign1(N'" + UserName + "') + '%'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                UserDTO user = new UserDTO(item);
                list.Add(user);
            }

            return list;
        }

        public bool InsertUser(string UserID, string UserName, string DoB, string Address, string Email, int PhoneNumber)
        {
            string query = "INSERT into _User ([UserID], [UserName], [DoB] ,[Address], [Email], [PhoneNumber]) VALUES  ( '" + UserID + "' , N'" + UserName + "', '" + DoB + "', '" + Address + "' , '" + Email + "', '" + PhoneNumber + "' )";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;



        }

        public bool UpdateUser(string UserID, string UserName, string DoB, string Address, string Email, int PhoneNumber)
        {
            string query = "UPDATE dbo._User SET UserName = N'" + UserName + "', DoB = '" + DoB + "', Address = '" + Address + "', Email = '" + Email + "', PhoneNumber = '" + PhoneNumber + "' WHERE UserID = '" + UserID + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteUser(string UserID)
        {
            //  BillDAO.Instance.DeleteBillByBookID(BookID);

            string query = "Delete _User where UserID = '" + UserID + "' ";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
