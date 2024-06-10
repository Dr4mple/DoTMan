using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class SystemSP : Form
    {
        public SystemSP()
        {
            InitializeComponent();
            gunaPanel19.Height = 34;
            gunaPanel1.Height = 34;
            gunaPanel3.Height = 34;
            gunaPanel5.Height = 34;
            gunaPanel7.Height = 34;
            gunaPanel9.Height = 34;
            gunaPanel11.Height = 34;
            gunaPanel17.Height = 34;
        }

        private void gunaLabel4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Point lastPoint;
        private void SystemSP_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void SystemSP_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void gunaPictureBox10_Click(object sender, EventArgs e)
        {
            if(gunaPanel19.Height == 34) gunaPanel19.Height = 128;
            else gunaPanel19.Height = 34;
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            if (gunaPanel1.Height == 34) gunaPanel1.Height = 229;
            else gunaPanel1.Height = 34;
        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            if (gunaPanel3.Height == 34) gunaPanel3.Height = 414;
            else gunaPanel3.Height = 34;
        }

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {
            if (gunaPanel5.Height == 34) gunaPanel5.Height = 363;
            else gunaPanel5.Height = 34;
        }

        private void gunaPictureBox4_Click(object sender, EventArgs e)
        {
            if (gunaPanel7.Height == 34) gunaPanel7.Height = 446;
            else gunaPanel7.Height = 34;
        }

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {
            if (gunaPanel9.Height == 34) gunaPanel9.Height = 413;
            else gunaPanel9.Height = 34;
        }

        private void gunaPictureBox6_Click(object sender, EventArgs e)
        {
            if (gunaPanel11.Height == 34) gunaPanel11.Height = 421;
            else gunaPanel11.Height = 34;
        }

        private void gunaPictureBox9_Click(object sender, EventArgs e)
        {
            if (gunaPanel17.Height == 34) gunaPanel17.Height = 93;
            else gunaPanel17.Height = 34;
        }

        private void gunaLabel17_Click(object sender, EventArgs e)
        {

        }

        private void gunaPanel15_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
