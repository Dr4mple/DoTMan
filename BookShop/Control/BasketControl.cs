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
    public partial class BasketControl : UserControl
    {
        public OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;");
        public BasketControl()
        {
            InitializeComponent();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand command = new OleDbCommand($"INSERT INTO [Order] (bName, bPhone, bAdress) VALUES ('{gunaTextBox1.Text}', '{gunaTextBox2.Text}', '{gunaTextBox3.Text}')", myConnection);
                
                myConnection.Open();
                command.ExecuteNonQuery();
                myConnection.Close();

                MessageBox.Show("Заказ успешно оформлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Messenge", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myConnection.Close();
            }
        }

        private void gunaLabel7_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel7_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BasketControl_Load(object sender, EventArgs e)
        {
            //OleDbCommand command = new OleDbCommand($"SELECT SUM(bPrice) FROM [Basket])", myConnection);

            //myConnection.Open();
            //decimal tPrice = (decimal)command.ExecuteScalar();
            //myConnection.Close();
            
            //gunaLabel7.Text = tPrice.ToString();
        }

        private void gunaLabel6_Click(object sender, EventArgs e)
        {

        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
