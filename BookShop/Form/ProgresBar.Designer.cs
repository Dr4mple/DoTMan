namespace BookShop
{
    partial class ProgresBar
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgresBar));
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.Progress = new Guna.UI.WinForms.GunaProgressBar();
            this.logo = new Guna.UI.WinForms.GunaPictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 15;
            this.gunaElipse1.TargetControl = this;
            // 
            // Progress
            // 
            this.Progress.BorderColor = System.Drawing.Color.Black;
            this.Progress.ColorStyle = Guna.UI.WinForms.ColorStyle.Default;
            this.Progress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progress.IdleColor = System.Drawing.Color.Gainsboro;
            this.Progress.Location = new System.Drawing.Point(0, 242);
            this.Progress.Name = "Progress";
            this.Progress.ProgressMaxColor = System.Drawing.Color.Red;
            this.Progress.ProgressMinColor = System.Drawing.Color.Red;
            this.Progress.Size = new System.Drawing.Size(430, 10);
            this.Progress.TabIndex = 4;
            // 
            // logo
            // 
            this.logo.BaseColor = System.Drawing.Color.White;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(75, 29);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(274, 189);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 3;
            this.logo.TabStop = false;
            this.logo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.logo_MouseDown);
            this.logo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.logo_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ProgresBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(430, 252);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProgresBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProgresBar_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ProgresBar_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaProgressBar Progress;
        private Guna.UI.WinForms.GunaPictureBox logo;
        private System.Windows.Forms.Timer timer1;
    }
}

