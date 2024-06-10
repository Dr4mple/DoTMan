using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class SIGNin : Form
    {
        public OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;");
        public SIGNin()
        {
            InitializeComponent();
            this.ActiveControl = Label;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home.Instance.Show();
        }

        private void TextBoxUser_Enter(object sender, EventArgs e)
        {
            if(TextBoxUser.Text == "Username")
            {
                TextBoxUser.Text = "";
                TextBoxUser.ForeColor = Color.Black;
            }
        }

        private void TextBoxUser_Leave(object sender, EventArgs e)
        {
            if(TextBoxUser.Text == "")
            {
                TextBoxUser.Text = "Username";
                TextBoxUser.ForeColor = Color.Gray;
            }
        }

        private void TextBoxPassword_Enter(object sender, EventArgs e)
        {
            if(TextBoxPassword.Text == "Password")
            {
                TextBoxPassword.Text = "";
                TextBoxPassword.ForeColor = Color.Black;
            }
        }

        private void TextBoxPassword_Leave(object sender, EventArgs e)
        {
            if(TextBoxPassword.Text == "")
            {
                TextBoxPassword.Text = "Password";
                TextBoxPassword.ForeColor = Color.Gray;
            }
        }

        private void btnSignIN_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxUser.Text != "Username" && TextBoxPassword.Text != "Password")
                {
                    OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Users WHERE uUsername='" + TextBoxUser.Text + "' AND uPassword='" + TextBoxPassword.Text + "'", myConnection);
                    DataTable dataTable = new DataTable();

                    oleDbDataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count != 1)
                    {
                        ErrorPanel.Visible = true;
                        Messenge.ForeColor = Color.Red;
                        Messenge.Text = "Пользователь не найден";
                    }
                    else
                    {
                        if (TextBoxUser.Text == "admin") { Home.Instance.pnlAdmin.Visible = true; }
                        Home.Instance.PnlLableUser.Text = TextBoxUser.Text;
                        Home.Instance.PnlLableUser.Visible = true;
                        Home.Instance.pnlBasket.Visible = true;
                        Home.Instance.Show();
                        this.Hide();
                    }
                }
                else
                {
                    if (TextBoxPassword.Text == "Password")
                        TextBoxPassword.BorderColor = Color.Red;
                    if (TextBoxUser.Text == "Username")
                        TextBoxUser.BorderColor = Color.Red;
                    ErrorPanel.Visible = true;
                    Messenge.ForeColor = Color.Red;
                    Messenge.Text = "Есть пустые поля";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Messenge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignUP_Click(object sender, EventArgs e)
        {
            this.Hide();
            SIGNup sIGNup = new SIGNup();
            sIGNup.Show();
        }

        private void gunaPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
