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
    public partial class fBill : Form
    {
        BindingSource BillList = new BindingSource();
        public fBill()
        {
            InitializeComponent();
            //LoadListBill();
            LoadData();
        }

        #region methods
        void LoadData()
        {
            dgvBill.DataSource = BillList;

            LoadListBill();
            LoadUserIntoCombobox(cbUser);
            LoadBookIntoCombobox(cbBook);
            AddBillBinding();
        }

        void LoadListBill()
        {
            BillList.DataSource = BillDAO.Instance.GetListBill();
        }

        void AddBillBinding()
        {
            //[BillID], [UserID], [BookID] ,[BookLoanDay], [BookReturnDay], [Note]
            txbBillID.DataBindings.Add(new Binding("Text", dgvBill.DataSource, "BillID", true, DataSourceUpdateMode.Never));
            txbBookLoanDay.DataBindings.Add(new Binding("Text", dgvBill.DataSource, "BookLoanDay", true, DataSourceUpdateMode.Never));
            txbBookReturnDay.DataBindings.Add(new Binding("Text", dgvBill.DataSource, "BookReturnDay", true, DataSourceUpdateMode.Never));
            txbNote.DataBindings.Add(new Binding("Text", dgvBill.DataSource, "Note", true, DataSourceUpdateMode.Never));
        }
        void LoadUserIntoCombobox(ComboBox cb)
        {
            cb.DataSource = UserDAO.Instance.GetListUser();
            cb.DisplayMember = "UserName";
        }
        void LoadBookIntoCombobox(ComboBox cb)
        {
            cb.DataSource = BookDAO.Instance.GetListBook();
            cb.DisplayMember = "BookTitle";
        }


        #endregion

        #region events
        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadListBill();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        { 
            //BillID], [UserID], [BookID] ,[BookLoanDay], [BookReturnDay], [Note]
            string BillID = txbBillID.Text;
            string UserID = (cbUser.SelectedItem as UserDTO).UserID;
            string BookID = (cbBook.SelectedItem as BookDTO).BookID;
            string BookLoanDay = txbBookLoanDay.Text;
            string BookReturnDay = txbBookReturnDay.Text;
            string Note = txbNote.Text;


            if (BillDAO.Instance.InsertBill(BillID, UserID, BookID,BookLoanDay, BookReturnDay, Note))
            {
                MessageBox.Show("Thêm Book thành công");
                LoadListBill();
                if (insertBill != null)
                    insertBill(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm Book");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string BillID = txbBillID.Text;

            if (BillDAO.Instance.DeleteBill(BillID))
            {
                MessageBox.Show("Xóa Bill thành công");
                LoadListBill();
                if (deleteBill != null)
                    deleteBill(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa Bill");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string BillID = txbBillID.Text;
            string UserID = (cbUser.SelectedItem as UserDTO).UserID;
            string BookID = (cbBook.SelectedItem as BookDTO).BookID;
            string BookLoanDay = txbBookLoanDay.Text;
            string BookReturnDay = txbBookReturnDay.Text;
            string Note = txbNote.Text;


            if (BillDAO.Instance.UpdateBill(BillID, UserID, BookID, BookLoanDay, BookReturnDay, Note))
            {
                MessageBox.Show("Sửa Bill thành công");
                LoadListBill();
                if (updateBill != null)
                    updateBill(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa Bill");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
 
        }
        private event EventHandler insertBill;
        public event EventHandler InsertBill
        {
            add { insertBill += value; }
            remove { insertBill -= value; }
        }

        private event EventHandler deleteBill;
        public event EventHandler DeleteBill
        {
            add { deleteBill += value; }
            remove { deleteBill -= value; }
        }

        private event EventHandler updateBill;
        public event EventHandler UpdateBill
        {
            add { updateBill += value; }
            remove { updateBill -= value; }
        }
        #endregion
    }
}
