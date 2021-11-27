using library_manager.DAO;
using library_manager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_manager
{
    public partial class fUser : Form
    {
        BindingSource UserList = new BindingSource();
        public fUser()
        {
            InitializeComponent();
            LoadData();
        }

        #region methods
        void LoadData()
        {
            dgvUser.DataSource = UserList;

            LoadListUser();
            AddUserBinding();
        }

        void LoadListUser()
        {
            UserList.DataSource = UserDAO.Instance.GetListUser();
        }

        List<UserDTO> SearchUserByName(string UserName)
        {
            List<UserDTO> listUser = UserDAO.Instance.SearchUserByName(UserName);

            return listUser;
        }
        void AddUserBinding()
        {
            //[UserID], [UserName], [DoB] ,[DoB], [Email], [PhoneNumber]
            txbUserID.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "UserID", true, DataSourceUpdateMode.Never));
            txbUserName.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDoB.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "DoB", true, DataSourceUpdateMode.Never));
            txbAddress.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "Address", true, DataSourceUpdateMode.Never));
            txbEmail.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "Email", true, DataSourceUpdateMode.Never));
            txbPhoneNumber.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "PhoneNumber", true, DataSourceUpdateMode.Never));
        }

        #endregion

        #region events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            UserList.DataSource = SearchUserByName(txbSearch.Text);
        }

        private void btnShowAlll_Click(object sender, EventArgs e)
        {
            LoadListUser();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string UserID = txbUserID.Text;
            string UserName = txbUserName.Text;
            string DoB = txbDoB.Text;
            string Address = txbAddress.Text;
            string Email = txbEmail.Text;
            int PhoneNumber = Convert.ToInt32(txbPhoneNumber.Text);

            if (UserDAO.Instance.InsertUser(UserID, UserName, DoB, Address, Email, PhoneNumber))
            {
                MessageBox.Show("Thêm User thành công");
                LoadListUser();
                if (insertUser != null)
                    insertUser(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm PublishingCompany");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string UserID = txbUserID.Text;

            if (UserDAO.Instance.DeleteUser(UserID))
            {
                MessageBox.Show("Xóa User thành công");
                LoadListUser();
                if (deleteUser != null)
                    deleteUser(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa User");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string UserID = txbUserID.Text;
            string UserName = txbUserName.Text;
            string DoB = txbDoB.Text;
            string Address = txbAddress.Text;
            string Email = txbEmail.Text;
            int PhoneNumber = Convert.ToInt32(txbPhoneNumber.Text);


            if (UserDAO.Instance.UpdateUser(UserID, UserName, DoB, Address, Email, PhoneNumber))
            {
                MessageBox.Show("Sửa User thành công");
                LoadListUser();
                if (updateUser != null)
                    updateUser(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa User");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
        private event EventHandler insertUser;
        public event EventHandler InsertUser
        {
            add { insertUser += value; }
            remove { insertUser -= value; }
        }

        private event EventHandler deleteUser;
        public event EventHandler DeleteUser
        {
            add { deleteUser += value; }
            remove { deleteUser -= value; }
        }

        private event EventHandler updateUser;
        public event EventHandler UpdateUser
        {
            add { updateUser += value; }
            remove { updateUser -= value; }
        }
        #endregion

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
