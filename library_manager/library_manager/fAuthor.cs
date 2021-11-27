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
    public partial class fAuthor : Form
    {
        BindingSource AuthorList = new BindingSource();
        public fAuthor()
        {
            InitializeComponent();
            LoadData();
        }

        #region methods
        void LoadData()
        {
            dgvAuthor.DataSource = AuthorList;

            LoadListAuthor();
            AddAuthorBinding();
        }

        void LoadListAuthor()
        {
            AuthorList.DataSource = AuthorDAO.Instance.GetListAuthor();
        }

        List<AuthorDTO> SearchAuthorByName(string AuthorName)
        {
            List<AuthorDTO> listAuthor = AuthorDAO.Instance.SearchAuthorByName(AuthorName);

            return listAuthor;
        }
        void AddAuthorBinding()
        {
            txbAuthorID.DataBindings.Add(new Binding("Text", dgvAuthor.DataSource, "AuthorID", true, DataSourceUpdateMode.Never));
            txbAuthorName.DataBindings.Add(new Binding("Text", dgvAuthor.DataSource, "AuthorName", true, DataSourceUpdateMode.Never));
            txbDoB.DataBindings.Add(new Binding("Text", dgvAuthor.DataSource, "DoB", true, DataSourceUpdateMode.Never));
        }
        #endregion

        #region events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            AuthorList.DataSource = SearchAuthorByName(txbSearch.Text);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadListAuthor();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string AuthorID = txbAuthorID.Text;
            string AuthorName = txbAuthorName.Text;
            string DoB = txbDoB.Text;


            if (AuthorDAO.Instance.InsertAuthor(AuthorID, AuthorName, DoB))
            {
                MessageBox.Show("Them Author thành công");
                LoadListAuthor();
                if (insertAuthor != null)
                    insertAuthor(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi Them Author");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string AuthorID = txbAuthorID.Text;

            if (AuthorDAO.Instance.DeleteAuthor(AuthorID))
            {
                MessageBox.Show("Xóa Author thành công");
                LoadListAuthor();
                if (deleteAuthor != null)
                    deleteAuthor(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa Author");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string AuthorID = txbAuthorID.Text;
            string AuthorName = txbAuthorName.Text;
            string DoB = txbDoB.Text;


            if (AuthorDAO.Instance.UpdateAuthor(AuthorID, AuthorName, DoB))
            {
                MessageBox.Show("Sửa Author thành công");
                LoadListAuthor();
                if (updateAuthor != null)
                    updateAuthor(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa Author");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private event EventHandler insertAuthor;
        public event EventHandler InsertAuthor
        {
            add { insertAuthor += value; }
            remove { insertAuthor -= value; }
        }

        private event EventHandler deleteAuthor;
        public event EventHandler DeleteAuthor
        {
            add { deleteAuthor += value; }
            remove { deleteAuthor -= value; }
        }

        private event EventHandler updateAuthor;
        public event EventHandler UpdateAuthor
        {
            add { updateAuthor += value; }
            remove { updateAuthor -= value; }
        }
        #endregion
    }
}
