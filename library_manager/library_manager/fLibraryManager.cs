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
    public partial class fLibraryManager : Form
    {
        public fLibraryManager()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            fAuthor f = new fAuthor();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnPublishingCompany_Click(object sender, EventArgs e)
        {
            fPublishingCompany f = new fPublishingCompany();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnBookCategory_Click(object sender, EventArgs e)
        {
            fBookCategory f = new fBookCategory();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            fBook f = new fBook();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            fBill f = new fBill();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            fUser f = new fUser();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  Application.Exit();
        }
    }
}
