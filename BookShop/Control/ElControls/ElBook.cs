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
    public partial class ElBook : UserControl
    {
        public ElBook(Image bPhoto,string dDescriprion)
        {
            InitializeComponent();
            gunaPictureBox1.Image = bPhoto;
            NameBook.Text = dDescriprion;

        }
        public OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;");
        public ElBook()
        {
            InitializeComponent();
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM [Books] WHERE bName='" + this.NameBook.Text + "'", myConnection);
                myConnection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                InfoBookControl infoBookControl = new InfoBookControl();
                if (Home.Instance.PnlLableUser.Visible == true) { infoBookControl.gunaAdvenceButton1.Visible = true; }
                Home.Instance.PnlContainer.Controls.Add(infoBookControl);
                if (Home.Instance.PnlLableUser.Visible == true) { infoBookControl.gunaAdvenceButton1.Visible = true; }
                infoBookControl.gunaPictureBox1.Image = this.gunaPictureBox1.Image;

                while (reader.Read())
                {
                    //информация
                    infoBookControl.gunaLabel1.Text = reader[1].ToString(); //название
                    infoBookControl.gunaLabel2.Text = reader[4].ToString() + ", " + reader[3].ToString(); //автор, год
                    infoBookControl.gunaLabel3.Text += reader[5].ToString(); //издательство
                    infoBookControl.gunaLabel6.Text += reader[6].ToString(); //страниц
                    infoBookControl.gunaLabel8.Text += reader[7].ToString(); //переплет
                    infoBookControl.gunaLabel9.Text += reader[8].ToString(); //Формат
                    infoBookControl.gunaLabel11.Text += reader[9].ToString(); //ISBN
                    infoBookControl.gunaLabel10.Text += reader[10].ToString() + " г"; //вес
                    infoBookControl.gunaLabel4.Text += reader[11].ToString(); //возраст
                    infoBookControl.gunaLabel5.Text += reader[0].ToString(); //№
                    infoBookControl.gunaLabel12.Text = reader[13].ToString() + " руб."; //цена

                    //описание
                    infoBookControl.gunaLabel7.Text = reader[14].ToString();
                }
                
                infoBookControl.Dock = DockStyle.Fill;
                Home.Instance.PnlContainer.Controls["InfoBookControl"].BringToFront();

                Home.Instance.button.Visible = true;
                Home.Instance.pnlSearch.Location = new Point(66, 11);
                reader.Close();
                myConnection.Close();
            }
            catch
            {
                myConnection.Close();
            }
        }

        private void NameBook_Click(object sender, EventArgs e)
        {

        }

        private void Atribute_Click(object sender, EventArgs e)
        {

        }
    }
}
