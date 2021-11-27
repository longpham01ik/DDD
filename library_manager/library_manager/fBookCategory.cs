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
    public partial class fBookCategory : Form
    {
        BindingSource BookCategoryList = new BindingSource();
        public fBookCategory()
        {
            InitializeComponent();
            LoadData();
        }
        #region methods
        void LoadData()
        {
            dgvBookCategory.DataSource = BookCategoryList;

            LoadListBookCategory();
            AddBookCategoryBinding();
        }

        void LoadListBookCategory()
        {
            BookCategoryList.DataSource = BookCategoryDAO.Instance.GetListBookCategory();
        }

        List<BookCategoryDTO> SearchBookCategoryByName(string BookCategoryName)
        {
            List<BookCategoryDTO> listBookCategory = BookCategoryDAO.Instance.SearchBookCategoryByName(BookCategoryName);

            return listBookCategory;
        }
        void AddBookCategoryBinding()
        {
            txbBookCategoryID.DataBindings.Add(new Binding("Text", dgvBookCategory.DataSource, "BookCategoryID", true, DataSourceUpdateMode.Never));
            txbBookCategoryName.DataBindings.Add(new Binding("Text", dgvBookCategory.DataSource, "BookCategoryName", true, DataSourceUpdateMode.Never));
        }
        #endregion


        #region events

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BookCategoryList.DataSource = SearchBookCategoryByName(txbSearch.Text);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadListBookCategory();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string BookCategoryID = txbBookCategoryID.Text;
            string BookCategoryName = txbBookCategoryName.Text;

            if (BookCategoryDAO.Instance.InsertBookCategory(BookCategoryID, BookCategoryName))
            {
                MessageBox.Show("Sửa BookCategory thành công");
                LoadListBookCategory();
                if (insertBookCategory != null)
                    insertBookCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa BookCategory");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string BookCategoryID = txbBookCategoryID.Text;
            string BookCategoryName = txbBookCategoryName.Text;


            if (BookCategoryDAO.Instance.UpdateBookCategory(BookCategoryID, BookCategoryName))
            {
                MessageBox.Show("Sửa BookCategory thành công");
                LoadListBookCategory();
                if (updateBookCategory != null)
                    updateBookCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa BookCategory");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string BookCategoryID = txbBookCategoryID.Text;

            if (BookCategoryDAO.Instance.DeleteBookCategory(BookCategoryID))
            {
                MessageBox.Show("Xóa BookCategory thành công");
                LoadListBookCategory();
                if (deleteBookCategory != null)
                    deleteBookCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa Author");
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {

        }
        private event EventHandler insertBookCategory;
        public event EventHandler InsertBookCategory
        {
            add { insertBookCategory += value; }
            remove { insertBookCategory -= value; }
        }

        private event EventHandler deleteBookCategory;
        public event EventHandler DeleteBookCategory
        {
            add { deleteBookCategory += value; }
            remove { deleteBookCategory -= value; }
        }

        private event EventHandler updateBookCategory;
        public event EventHandler UpdateBookCategory
        {
            add { updateBookCategory += value; }
            remove { updateBookCategory -= value; }
        }
            #endregion
    }
}
