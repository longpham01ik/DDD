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
    public partial class fPublishingCompany : Form
    {
        BindingSource PublishingCompanyList = new BindingSource();
        public fPublishingCompany()
        {
            InitializeComponent();
            LoadData();
        }

        #region methods
        void LoadData()
        {
            dgvPublishingCompany.DataSource = PublishingCompanyList;

            LoadListPublishingCompany();
            AddPublishingCompanyBinding();
        }

        void LoadListPublishingCompany()
        {
            PublishingCompanyList.DataSource = PublishingCompanyDAO.Instance.GetListPublishingCompany();
        }

        List<PublishingCompanyDTO> SearchPublishingCompanyByName(string PublishingCompanyName)
        {
            List<PublishingCompanyDTO> listPublishingCompany = PublishingCompanyDAO.Instance.SearchPublishingCompanyByName(PublishingCompanyName);

            return listPublishingCompany;
        }
        void AddPublishingCompanyBinding()
        {
            txbPublishingCompanyID.DataBindings.Add(new Binding("Text", dgvPublishingCompany.DataSource, "PublishingCompanyID", true, DataSourceUpdateMode.Never));
            txbPublishingCompanyName.DataBindings.Add(new Binding("Text", dgvPublishingCompany.DataSource, "PublishingCompanyName", true, DataSourceUpdateMode.Never));
            txbAddress.DataBindings.Add(new Binding("Text", dgvPublishingCompany.DataSource, "Address", true, DataSourceUpdateMode.Never));
            txbHotline.DataBindings.Add(new Binding("Text", dgvPublishingCompany.DataSource, "Hotline", true, DataSourceUpdateMode.Never));
            txbEmail.DataBindings.Add(new Binding("Text", dgvPublishingCompany.DataSource, "Email", true, DataSourceUpdateMode.Never));
        }

        #endregion

        #region events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            PublishingCompanyList.DataSource = SearchPublishingCompanyByName(txbSearch.Text);
        }
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadListPublishingCompany();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string PublishingCompanyID = txbPublishingCompanyID.Text;
            string PublishingCompanyName = txbPublishingCompanyName.Text;
            string Address = txbAddress.Text;
            int Hotline = Convert.ToInt32(txbHotline.Text);
            string Email = txbEmail.Text;

            if (PublishingCompanyDAO.Instance.InsertPublishingCompany( PublishingCompanyID, PublishingCompanyName, Address, Hotline, Email))
            {
                MessageBox.Show("Thêm PublishingCompany thành công");
                LoadListPublishingCompany();
                if (insertPublishingCompany != null)
                    insertPublishingCompany(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm PublishingCompany");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string PublishingCompanyID = txbPublishingCompanyID.Text;

            if (PublishingCompanyDAO.Instance.DeletePublishingCompany(PublishingCompanyID))
            {
                MessageBox.Show("Xóa PublishingCompany thành công");
                LoadListPublishingCompany();
                if (deletePublishingCompany != null)
                    deletePublishingCompany(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa PublishingCompany");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string PublishingCompanyID = txbPublishingCompanyID.Text;
            string PublishingCompanyName = txbPublishingCompanyName.Text;
            string Address = txbAddress.Text;
            int Hotline = Convert.ToInt32(txbHotline.Text);
            string Email = txbEmail.Text;


            if (PublishingCompanyDAO.Instance.UpdatePublishingCompany(PublishingCompanyID, PublishingCompanyName, Address, Hotline, Email))
            {
                MessageBox.Show("Sửa PublishingCompany thành công");
                LoadListPublishingCompany();
                if (updatePublishingCompany != null)
                    updatePublishingCompany(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa PublishingCompany");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
        private event EventHandler insertPublishingCompany;
        public event EventHandler InsertPublishingCompany
        {
            add { insertPublishingCompany += value; }
            remove { insertPublishingCompany -= value; }
        }

        private event EventHandler deletePublishingCompany;
        public event EventHandler DeletePublishingCompany
        {
            add { deletePublishingCompany += value; }
            remove { deletePublishingCompany -= value; }
        }

        private event EventHandler updatePublishingCompany;
        public event EventHandler UpdatePublishingCompany
        {
            add { updatePublishingCompany += value; }
            remove { updatePublishingCompany -= value; }
        }
#endregion

    }
}
