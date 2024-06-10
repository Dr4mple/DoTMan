using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BookShop
{
    public partial class ElBasketList : UserControl
    {
        public OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;");
        public ElBasketList()
        {
            InitializeComponent();
        }

        private void btnDeleteSoonFilm_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand command = new OleDbCommand("DELETE FROM Basket WHERE bName='" + gunaLabel1.Text + "'", myConnection);
                myConnection.Open();
                command.ExecuteNonQuery();
                myConnection.Close();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Messenge", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myConnection.Close();
            }
        }
    }
}
