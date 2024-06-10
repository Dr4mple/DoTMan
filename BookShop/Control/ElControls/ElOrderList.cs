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
using System.IO;

namespace BookShop
{
    public partial class ElOrderList : UserControl
    {
        public OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;");

        public ElOrderList()
        {
            InitializeComponent();
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            if (this.Height == 36) { this.Height += 46; }
            else { this.Height = 36; }

            OleDbCommand command = new OleDbCommand($"SELECT bName, bPhoto, bPrice FROM [Books] where bKey = {rand.Next(1,7)}", myConnection);
            myConnection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            flowLayoutPanel1.Controls.Clear();
            while (reader.Read())
            {
                ElBasketList Item = new ElBasketList();
                Item.btnDeleteSoonFilm.Visible = false;
                Item.Size = new Size(706, 46);
                Item.Dock = DockStyle.Top;
                Item.gunaLabel1.Text = reader[0].ToString();
                Item.gunaLabel2.Text = reader[2].ToString() + " руб.";

                byte[] Photo = (byte[])(reader[1]);
                MemoryStream memoryStream = new MemoryStream(Photo);
                Item.gunaCirclePictureBox1.Image = Image.FromStream(memoryStream);

                flowLayoutPanel1.Controls.Add(Item);
            }
            reader.Close();
            myConnection.Close();
        }
    }
}
