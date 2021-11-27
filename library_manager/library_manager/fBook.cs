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
    public partial class fBook : Form
    {
        BindingSource BookList = new BindingSource();
        public fBook()
        {
            InitializeComponent();
            LoadData();
            
        }
        #region methods
        void LoadData()
         {
            dgvBook.DataSource = BookList;

            LoadListBook();
            LoadBookCategoryIntoCombobox(cbBookCategory);
            LoadAuthorIntoCombobox(cbAuthor);
            LoadPublishingCompanyIntoCombobox(cbPublishingCompany);
            AddBookBinding();
         }

        void LoadListBook()
        {
            BookList.DataSource = BookDAO.Instance.GetListBook();
        }

        List<BookDTO> SearchBookByName(string BookTitle)
        {
            List<BookDTO> listBook = BookDAO.Instance.SearchBookByName(BookTitle);

            return listBook;
        }
        void AddBookBinding()
        {
            txbBookID.DataBindings.Add(new Binding("Text", dgvBook.DataSource, "BookID", true, DataSourceUpdateMode.Never));
            txbBookTitle.DataBindings.Add(new Binding("Text", dgvBook.DataSource, "BookTitle", true, DataSourceUpdateMode.Never));
            txbPublishingYear.DataBindings.Add(new Binding("Text", dgvBook.DataSource, "PublishingYear", true, DataSourceUpdateMode.Never));
            txbPrice.DataBindings.Add(new Binding("Text", dgvBook.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void LoadBookCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = BookCategoryDAO.Instance.GetListBookCategory();
            cb.DisplayMember = "BookCategoryName";
        }
        void LoadAuthorIntoCombobox(ComboBox cb)
        {
            cb.DataSource = AuthorDAO.Instance.GetListAuthor();
            cb.DisplayMember = "AuthorName";
        }
        void LoadPublishingCompanyIntoCombobox(ComboBox cb)
        {
            cb.DataSource = PublishingCompanyDAO.Instance.GetListPublishingCompany();
            cb.DisplayMember = "PublishingCompanyName";
        }
        #endregion

        #region events
        private void txbBookID_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dgvBook.SelectedCells.Count > 0)
            //    {
            //        string BookCategoryID = (string)dgvBook.SelectedCells[0].OwningRow.Cells["BookCategoryID"].Value;

            //        BookCategoryDTO cateogory = BookCategoryDAO.Instance.GetCategoryByID(BookCategoryID);

            //        cbBookCategory.SelectedItem = cateogory;

            //        int index = -1;
            //        int i = 0;
            //        foreach (BookCategoryDTO item in cbBookCategory.Items)
            //        {
            //            if (item.BookCategoryID == cateogory.BookCategoryID)
            //            {
            //                index = i;
            //                break;
            //            }
            //            i++;
            //        }

            //        cbBookCategory.SelectedIndex = index;
            //    }
            //}
            //catch { }
        }
      
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadListBook();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BookList.DataSource = SearchBookByName(txbSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string BookID = txbBookID.Text;
            string BookTitle = txbBookTitle.Text;
            string AuthorID = (cbAuthor.SelectedItem as AuthorDTO).AuthorID;
            string PublishingCompanyID = (cbPublishingCompany.SelectedItem as PublishingCompanyDTO).PublishingCompanyID;
            string BookCategoryID = (cbBookCategory.SelectedItem as BookCategoryDTO).BookCategoryID;
            int PublishingYear = Convert.ToInt32(txbPublishingYear.Text);
            int Price = Convert.ToInt32(txbPrice.Text);


            if (BookDAO.Instance.InsertBook(BookID, BookTitle, AuthorID, PublishingCompanyID, BookCategoryID, PublishingYear, Price))
            {
                MessageBox.Show("Thêm Book thành công");
                LoadListBook();
                if (insertBook != null)
                    insertBook(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm Book");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string BookID = txbBookID.Text; 

            if (BookDAO.Instance.DeleteBook(BookID))
            {
                MessageBox.Show("Xóa Book thành công");
                LoadListBook();
                if (deleteBook != null)
                    deleteBook(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa Book");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string BookTitle = txbBookTitle.Text;
            string AuthorID = (cbAuthor.SelectedItem as AuthorDTO).AuthorID;
            string PublishingCompanyID = (cbPublishingCompany.SelectedItem as PublishingCompanyDTO).PublishingCompanyID;
            string BookCategoryID = (cbBookCategory.SelectedItem as BookCategoryDTO).BookCategoryID;
            int PublishingYear = Convert.ToInt32(txbPublishingYear.Text);
            int Price = Convert.ToInt32(txbPrice.Text);
            string BookID = txbBookID.Text;


            if (BookDAO.Instance.UpdateBook(BookID, BookTitle, AuthorID, PublishingCompanyID, BookCategoryID, PublishingYear, Price))
            {
                MessageBox.Show("Sửa Book thành công");
                LoadListBook();
                if (updateBook != null)
                    updateBook(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa Book");
            }
        }
    

        
        private event EventHandler insertBook;
        public event EventHandler InsertBook
        {
            add { insertBook += value; }
            remove { insertBook -= value; }
        }

        private event EventHandler deleteBook;
        public event EventHandler DeleteBook
        {
            add { deleteBook += value; }
            remove { deleteBook -= value; }
        }

        private event EventHandler updateBook;
        public event EventHandler UpdateBook
        {
            add { updateBook += value; }
            remove { updateBook -= value; }
        }
        #endregion
        private void fBook_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        
    }
}
