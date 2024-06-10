using BookShop.Control.ElControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class Home : Form
    {
        public OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;");
        public Home()
        {
            InitializeComponent();
            logo.Click += new EventHandler(this.logo_Click);
            _obj = this;
            SearchPanel.Location = new Point(26, 11);
            this.ActiveControl = logo;
        }

        static Home _obj;
        public static Home Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Home();
                }
                return _obj;
            }
        }

        public Panel PnlContainer
        {
            get { return InfoPanel; }
            set { InfoPanel = value; }
        }

        public Guna.UI.WinForms.GunaPictureBox button
        {
            get { return btnBack; }
            set { btnBack = value; }
        }

        public Guna.UI.WinForms.GunaPanel pnlSearch
        {
            get { return SearchPanel; }
            set { SearchPanel = value; }
        }

        public Guna.UI.WinForms.GunaPanel pnlAdmin
        {
            get { return AdminPanel; }
            set { AdminPanel = value; }
        }

        public Guna.UI.WinForms.GunaLabel PnlLableUser
        {
            get { return UserName; }
            set { UserName = value; }
        }
        public Guna.UI.WinForms.GunaPanel pnlBasket
        {
            get { return gunaPanel1; }
            set { gunaPanel1 = value; }
        }

        Point lastPoint;
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = logo;
            lastPoint = new Point(e.X, e.Y);
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void TextBoxSearch_Enter(object sender, EventArgs e)
        {
            if (TextBoxSearch.Text == "Search for book")
            {
                TextBoxSearch.Text = "";
            }
        }

        private void TextBoxSearch_Leave(object sender, EventArgs e)
        {
            if (TextBoxSearch.Text == "")
            {
                TextBoxSearch.Text = "Search for book";
            }
        }

        //-------------------------------- Admin
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            SearchPanel.Location = new Point(26, 11);
            btnBack.Visible = false;
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            AdminControl adminControl1 = new AdminControl();
            InfoPanel.Controls.Add(adminControl1);
            adminControl1.Dock = DockStyle.Fill;
            adminControl1.BringToFront();

            PrintListUserAdmin(adminControl1);
            PrintListBookAdmin(adminControl1);
            PrintStatisticAdmin(adminControl1);
        }

        private void PrintStatisticAdmin(AdminControl adminControl1)
        {
            OleDbCommand command = new OleDbCommand("SELECT COUNT(*) FROM Books", myConnection);
            myConnection.Open();
            adminControl1.CountBooks.Text = "0" + command.ExecuteScalar().ToString();
            myConnection.Close();

            command = new OleDbCommand("SELECT COUNT(*) FROM Users", myConnection);
            myConnection.Open();
            adminControl1.CountUsers.Text = "0" + command.ExecuteScalar().ToString();
            myConnection.Close();

            Random random = new Random();
            adminControl1.CountBuyBooks.Text = "0" + random.Next(0, 30);

            adminControl1.DataTime.Text = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString();

        }

        private void PrintListBookAdmin(AdminControl adminControl1)
        {
            OleDbCommand command = new OleDbCommand("SELECT * FROM [Books]", myConnection);
            myConnection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            adminControl1.flowLayoutPanel1.Controls.Clear();
            Random random = new Random();

            while (reader.Read())
            {
                ElBookList Item = new ElBookList();

                byte[] Photo = (byte[])(reader[12]);
                MemoryStream memoryStream = new MemoryStream(Photo);
                Item.gunaCirclePictureBox1.Image = Image.FromStream(memoryStream);

                Item.gunaLabel1.Text = reader[1].ToString();
                Item.gunaLabel3.Text = reader[2].ToString();
                Item.gunaLabel4.Text += reader[0].ToString();

                adminControl1.flowLayoutPanel1.Controls.Add(Item);
            }
            reader.Close();
            myConnection.Close();
        }

        private void PrintListUserAdmin(AdminControl adminControl1)
        {
            OleDbCommand command = new OleDbCommand("SELECT * FROM [Users]", myConnection);
            myConnection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            adminControl1.flowLayoutPanel3.Controls.Clear();
            Random random = new Random();

            while (reader.Read())
            {
                ElUserList Item = new ElUserList();
                Item.gunaLabel1.Text += reader[0].ToString();
                Item.gunaLabel3.Text += reader[1].ToString();
                Item.gunaLabel4.Text += reader[2].ToString();
                Item.gunaLabel2.Text += random.Next(1, 15).ToString();

                adminControl1.flowLayoutPanel3.Controls.Add(Item);
            }
            reader.Close();
            myConnection.Close();
        }

        //--------------------------------- Заказы
        private void btnOrder_Click(object sender, EventArgs e)
        {
            SearchPanel.Location = new Point(26, 11);
            btnBack.Visible = false;
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            OrderControl orderControl = new OrderControl();
            InfoPanel.Controls.Add(orderControl);
            orderControl.Dock = DockStyle.Fill;
            orderControl.BringToFront();
            PrintOrder(orderControl);
        }

        private void PrintOrder(OrderControl orderControl)
        {
            OleDbCommand command = new OleDbCommand("SELECT * FROM [Order]", myConnection);
            myConnection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            Random random = new Random();

            orderControl.flowLayoutPanel1.Controls.Clear();
            int a = 0;
            while (reader.Read())
            {
                ElOrderList Item = new ElOrderList();
                Item.gunaLabel1.Text = reader[1].ToString();
                Item.gunaLabel2.Text = reader[2].ToString();
                Item.gunaLabel6.Text = reader[3].ToString();
                Item.gunaLabel4.Text += a = a + 1;
                Item.Size = new Size(709, 36);

                orderControl.flowLayoutPanel1.Controls.Add(Item);
            }
            reader.Close();
            myConnection.Close();
        }

        //-------------------------------- Книги

        private void PrintBooks(BookControl bookControl, string str)
        {
            OleDbCommand command = new OleDbCommand("SELECT * FROM Books", myConnection);
            myConnection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (str == reader[2].ToString())
                {
                    ElBook Item = new ElBook();

                    byte[] Photo = (byte[])(reader[12]);
                    MemoryStream memoryStream = new MemoryStream(Photo);
                    Item.gunaPictureBox1.Image = Image.FromStream(memoryStream);
                    Item.NameBook.Text = reader[1].ToString();

                    bookControl.flowLayoutPanel1.Controls.Add(Item);
                }
            }
            reader.Close();
            myConnection.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SearchPanel.Location = new Point(26, 11);
            btnBack.Visible = false;
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            BookControl bookControl = new BookControl();
            InfoPanel.Controls.Add(bookControl);
            bookControl.Dock = DockStyle.Fill;
            bookControl.BringToFront();

            PrintBooks(bookControl, "Интеллект");
        }

        private void btnBestSellers_Click(object sender, EventArgs e)
        {
            SearchPanel.Location = new Point(26, 11);
            btnBack.Visible = false;
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            BookControl bookControl = new BookControl();
            InfoPanel.Controls.Add(bookControl);
            bookControl.Dock = DockStyle.Fill;
            bookControl.BringToFront();

            PrintBooks(bookControl, "Сила");
        }

        private void btnChildrens_Click(object sender, EventArgs e)
        {
            SearchPanel.Location = new Point(26, 11);
            btnBack.Visible = false;
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            BookControl bookControl = new BookControl();
            InfoPanel.Controls.Add(bookControl);
            bookControl.Dock = DockStyle.Fill;
            bookControl.BringToFront();

            PrintBooks(bookControl, "Ловкость");
        }

        private void btnFantasy_Click(object sender, EventArgs e)
        {
            SearchPanel.Location = new Point(26, 11);
            btnBack.Visible = false;
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            BookControl bookControl = new BookControl();
            InfoPanel.Controls.Add(bookControl);
            bookControl.Dock = DockStyle.Fill;
            bookControl.BringToFront();

            PrintBooks(bookControl, "Универсальный");
        }

        private void btnSoonInSales_Click(object sender, EventArgs e)
        {
            SearchPanel.Location = new Point(26, 11);
            btnBack.Visible = false;
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            BookControl bookControl = new BookControl();
            InfoPanel.Controls.Add(bookControl);
            bookControl.Dock = DockStyle.Fill;
            bookControl.BringToFront();

            PrintBooks(bookControl, "Скоро в продаже");
        }

        //------------------------------------------ Корзина
        private void btnBasket_Click(object sender, EventArgs e)
        {
            SearchPanel.Location = new Point(26, 11);
            btnBack.Visible = false;
            _obj = this;

            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            BasketControl basketControl = new BasketControl();
            InfoPanel.Controls.Add(basketControl);
            basketControl.Dock = DockStyle.Fill;
            basketControl.BringToFront();

            PrintBasketBook(basketControl);
            CountBasketBook(basketControl);
        }

        private void CountBasketBook(BasketControl basketControl)
        {
            OleDbCommand command = new OleDbCommand("SELECT COUNT(*) FROM Basket", myConnection);
            myConnection.Open();
            basketControl.gunaLabel5.Text = "Итого: " + command.ExecuteScalar().ToString() + " книг";
            myConnection.Close();
        }

        private void PrintBasketBook(BasketControl basketControl)
        {
            OleDbCommand command = new OleDbCommand("SELECT * FROM Basket", myConnection);
            myConnection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            decimal sum = 0;

            while (reader.Read())
            {
                ElBasketList Item = new ElBasketList();

                byte[] Photo = (byte[])(reader[2]);
                MemoryStream memoryStream = new MemoryStream(Photo);
                Item.gunaCirclePictureBox1.Image = Image.FromStream(memoryStream);
                Item.gunaLabel1.Text = reader[1].ToString();
                Item.gunaLabel2.Text = reader[3].ToString();
                basketControl.flowLayoutPanel1.Controls.Add(Item);

                string numberOnly = Regex.Replace(reader[3].ToString(), "[^0-9]", "");
                sum += decimal.Parse(numberOnly);
            }
            basketControl.gunaLabel7.Text = sum.ToString() + " руб.";

            reader.Close();
            myConnection.Close();
        }

        private void UserPicture_Click(object sender, EventArgs e)
        {
            UserControl1 userControl1 = new UserControl1();
            InfoPanel.Controls.Add(userControl1);

            if (UserName.Text != "Name")
            {
                userControl1.PanelLogReg.Visible = false;
                userControl1.Size = new Size(134, 45);
            }

            userControl1.Location = new Point(626, 0);
            userControl1.BringToFront();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            SearchPanel.Location = new Point(26, 11);
            InfoPanel.Controls.RemoveAt(0);
            btnBack.Visible = false;
        }
        private void PrintListAirprot(BookControl UserListControl)
        {
            UserListControl.flowLayoutPanel1.Controls.Clear();
            OleDbCommand command = new OleDbCommand("SELECT * FROM Books ORDER BY bCategory", myConnection);
            myConnection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            string currentGenre = string.Empty;
            FlowLayoutPanel genrePanel = null;

            while (reader.Read())
            {
                string genre = reader["bCategory"].ToString();

                // Если жанр изменился, создаем новый заголовок и новый FlowLayoutPanel для жанра
                if (genre != currentGenre)
                {
                    currentGenre = genre;

                    Label genreLabel = new Label();
                    genreLabel.Text = genre;
                    genreLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                    genreLabel.AutoSize = true;

                    genrePanel = new FlowLayoutPanel();
                    genrePanel.FlowDirection = FlowDirection.BottomUp; 
                    genrePanel.AutoSize = true;
                    genrePanel.WrapContents = false;

                    UserListControl.flowLayoutPanel1.Controls.Add(genreLabel);
                    UserListControl.flowLayoutPanel1.Controls.Add(genrePanel);
                }

                // Создаем элемент книги
                ElBook item = new ElBook();
                byte[] photo = (byte[])(reader["bPhoto"]);
                MemoryStream memoryStream = new MemoryStream(photo);
                item.gunaPictureBox1.Image = Image.FromStream(memoryStream);
                item.NameBook.Text = reader["bName"].ToString();

                // Добавляем элемент книги в текущий жанровый FlowLayoutPanel
                genrePanel.Controls.Add(item);
            }

            reader.Close();
            myConnection.Close();
        }
        private void Home_Load(object sender, EventArgs e)
        {

            _obj = this;
            if (InfoPanel.Controls.Count > 0)
                InfoPanel.Controls.RemoveAt(0);
            BookControl UserListControl = new BookControl();
            InfoPanel.Controls.Add(UserListControl);
            UserListControl.BringToFront();

            PrintListAirprot(UserListControl);
            try
            {
                OleDbCommand command = new OleDbCommand("DELETE FROM [Basket]", myConnection);
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

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            SystemSP system = new SystemSP();
            system.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            string query = TextBoxSearch.Text;

            // Очищаем предыдущие результаты
            InfoPanel.Controls.Clear();

            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;"))
            {
                connection.Open();
                string sqlQuery = "SELECT bName, bCategory, bAuthor, bPublishing,bPhoto FROM Books WHERE bName  LIKE @query OR bCategory LIKE @query OR bAuthor LIKE @query OR bPublishing LIKE @query";
                using (OleDbCommand command = new OleDbCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@query", "%" + query + "%");
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        // Создаем пользовательский элемент управления для отображения всех результатов
                        var userListControl = new BookControl();

                        while (reader.Read())
                        {
                            byte[] photo = (byte[])(reader["bPhoto"]);
                            string dDescriprion = reader["bName"].ToString();
                            Image airportImage = null;
                            if (photo != null && photo.Length > 0)
                            {
                                using (MemoryStream memoryStream = new MemoryStream(photo))
                                {
                                    airportImage = Image.FromStream(memoryStream);
                                }
                            }

                            // Создаем пользовательский элемент управления для отображения отдельного результата
                            var resultControl = new ElBook(airportImage, dDescriprion);

                            // Добавляем элемент управления в FlowLayoutPanel внутри UserListAirportControl
                            userListControl.flowLayoutPanel1.Controls.Add(resultControl);
                        }

                        // Добавляем UserListAirportControl в основную панель
                        InfoPanel.Controls.Add(userListControl);
                    }
                }
            }

        }

        private void InfoPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logo_Click(object sender, EventArgs e)
        {
            BookControl UserListControl = InfoPanel.Controls.OfType<BookControl>().FirstOrDefault();
            if (UserListControl != null)
            {
                PrintListAirprot(UserListControl);
            }
        }

        private void TopPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
