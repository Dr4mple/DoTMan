using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class AddBook : Form
    {
        public OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;");
        public AddBook()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog efd = new OpenFileDialog();
                if (efd.ShowDialog() == DialogResult.OK)
                    PictureBox.Image = Image.FromFile(efd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                PictureBox.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] Photo = new byte[memoryStream.Length];

                memoryStream.Position = 0;
                memoryStream.Read(Photo, 0, Photo.Length);

                OleDbCommand command = new OleDbCommand("INSERT INTO Books (bName, bCategory, bYear, bAuthor, bPublishing, bPages, bBinding, bForm, bISBN, bWeight, bAge, bPhoto, bPrice, bDiscription) VALUES ('" + TextBoxName.Text + "', '" + BoxCategory.Text + "', '" + TextBoxYear.Text + "', '" + TextBoxAuthor.Text + "', '" + TextBoxPublishing.Text + "', '" + TextBoxPages.Text + "', '" + TextBoxBinding.Text + "', '" + TextBoxForm.Text + "', '" + TextBoxISBN.Text + "', '" + TextBoxWeight.Text + "', '" + TextBoxAge.Text + "', @photo, '"+ TextBoxPrice.Text+ "', '"+ TextBoxDiscription.Text + "')", myConnection);
                command.Parameters.AddWithValue("@photo", Photo);

                myConnection.Open();
                command.ExecuteNonQuery();
                myConnection.Close();

                this.Close();

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
    }
}
