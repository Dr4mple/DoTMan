using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }


        private void btnSignIN_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home.Instance.Hide();
            SIGNin sIGNin = new SIGNin();
            sIGNin.Show();
        }

        private void btnSignUP_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home.Instance.Hide();
            SIGNup sIGNup = new SIGNup();
            sIGNup.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
