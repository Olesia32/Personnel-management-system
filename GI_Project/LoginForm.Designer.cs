
namespace GI_Project
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.welcome_panel = new System.Windows.Forms.Panel();
            this.error_lb = new System.Windows.Forms.Label();
            this.close_bt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.password_panel = new System.Windows.Forms.Panel();
            this.password_tb = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.start_bt = new System.Windows.Forms.Button();
            this.welcome_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.welcome_lb = new System.Windows.Forms.Label();
            this.welcome_pc = new System.Windows.Forms.PictureBox();
            this.welcome_panel.SuspendLayout();
            this.password_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.welcome_pc)).BeginInit();
            this.SuspendLayout();
            //  
            // welcome_panel
            // 
            this.welcome_panel.BackColor = System.Drawing.Color.GhostWhite;
            this.welcome_panel.Controls.Add(this.error_lb);
            this.welcome_panel.Controls.Add(this.close_bt);
            this.welcome_panel.Controls.Add(this.label3);
            this.welcome_panel.Controls.Add(this.password_panel);
            this.welcome_panel.Controls.Add(this.start_bt);
            this.welcome_panel.Controls.Add(this.welcome_label);
            this.welcome_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.welcome_panel.Location = new System.Drawing.Point(263, 0);
            this.welcome_panel.Name = "welcome_panel";
            this.welcome_panel.Size = new System.Drawing.Size(537, 450);
            this.welcome_panel.TabIndex = 3;
            // 
            // error_lb
            // 
            this.error_lb.AutoSize = true;
            this.error_lb.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.error_lb.ForeColor = System.Drawing.Color.Red;
            this.error_lb.Location = new System.Drawing.Point(3, 238);
            this.error_lb.Name = "error_lb";
            this.error_lb.Size = new System.Drawing.Size(154, 17);
            this.error_lb.TabIndex = 11;
            this.error_lb.Text = "Неправильний пароль";
            this.error_lb.Visible = false;
            // 
            // close_bt
            // 
            this.close_bt.BackColor = System.Drawing.Color.DarkCyan;
            this.close_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_bt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.close_bt.ForeColor = System.Drawing.Color.Ivory;
            this.close_bt.Location = new System.Drawing.Point(77, 317);
            this.close_bt.Name = "close_bt";
            this.close_bt.Size = new System.Drawing.Size(125, 40);
            this.close_bt.TabIndex = 9;
            this.close_bt.Text = "Завершити";
            this.close_bt.UseVisualStyleBackColor = false;
            this.close_bt.Click += new System.EventHandler(this.close_bt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(6, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Введіть пароль:";
            // 
            // password_panel
            // 
            this.password_panel.BackColor = System.Drawing.Color.GhostWhite;
            this.password_panel.Controls.Add(this.password_tb);
            this.password_panel.Controls.Add(this.pictureBox2);
            this.password_panel.Location = new System.Drawing.Point(3, 191);
            this.password_panel.Name = "password_panel";
            this.password_panel.Size = new System.Drawing.Size(537, 44);
            this.password_panel.TabIndex = 7;
            this.password_panel.MouseEnter += new System.EventHandler(this.password_panel_MouseEnter);
            this.password_panel.MouseLeave += new System.EventHandler(this.password_panel_MouseLeave);
            // 
            // password_tb
            // 
            this.password_tb.BackColor = System.Drawing.Color.GhostWhite;
            this.password_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password_tb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.password_tb.ForeColor = System.Drawing.Color.DarkCyan;
            this.password_tb.Location = new System.Drawing.Point(60, 8);
            this.password_tb.Name = "password_tb";
            this.password_tb.Size = new System.Drawing.Size(444, 20);
            this.password_tb.TabIndex = 2;
            this.password_tb.Text = "Пароль";
            this.password_tb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.password_tb_MouseClick);
            this.password_tb.MouseEnter += new System.EventHandler(this.password_panel_MouseEnter);
            this.password_tb.MouseLeave += new System.EventHandler(this.password_panel_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GI_Project.Properties.Resources.pngfind_com_lock_icon_png_1130400;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(9, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // start_bt
            // 
            this.start_bt.BackColor = System.Drawing.Color.DarkCyan;
            this.start_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_bt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.start_bt.ForeColor = System.Drawing.Color.Ivory;
            this.start_bt.Location = new System.Drawing.Point(306, 317);
            this.start_bt.Name = "start_bt";
            this.start_bt.Size = new System.Drawing.Size(125, 40);
            this.start_bt.TabIndex = 5;
            this.start_bt.Text = "Продовжити";
            this.start_bt.UseVisualStyleBackColor = false;
            this.start_bt.Click += new System.EventHandler(this.start_bt_Click);
            // 
            // welcome_label
            // 
            this.welcome_label.AutoSize = true;
            this.welcome_label.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.welcome_label.ForeColor = System.Drawing.Color.DarkCyan;
            this.welcome_label.Location = new System.Drawing.Point(18, 58);
            this.welcome_label.Name = "welcome_label";
            this.welcome_label.Size = new System.Drawing.Size(76, 39);
            this.welcome_label.TabIndex = 1;
            this.welcome_label.Text = "Вхід";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.welcome_lb);
            this.panel1.Controls.Add(this.welcome_pc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 450);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(263, 205);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(537, 30);
            this.panel3.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.GhostWhite;
            this.label2.Location = new System.Drawing.Point(97, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "персоналом";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.GhostWhite;
            this.label1.Location = new System.Drawing.Point(3, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = " в системі управління ";
            // 
            // welcome_lb
            // 
            this.welcome_lb.AutoSize = true;
            this.welcome_lb.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.welcome_lb.ForeColor = System.Drawing.Color.GhostWhite;
            this.welcome_lb.Location = new System.Drawing.Point(151, 237);
            this.welcome_lb.Name = "welcome_lb";
            this.welcome_lb.Size = new System.Drawing.Size(105, 25);
            this.welcome_lb.TabIndex = 1;
            this.welcome_lb.Text = "Вітаємо ";
            // 
            // welcome_pc
            // 
            this.welcome_pc.Image = global::GI_Project.Properties.Resources._1282897_200__1_1;
            this.welcome_pc.Location = new System.Drawing.Point(73, 69);
            this.welcome_pc.Name = "welcome_pc";
            this.welcome_pc.Size = new System.Drawing.Size(113, 99);
            this.welcome_pc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.welcome_pc.TabIndex = 0;
            this.welcome_pc.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.welcome_panel);
            this.Controls.Add(this.panel1);
            this.Name = "LoginForm";
            this.Text = "Система управління персоналом";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.welcome_panel.ResumeLayout(false);
            this.welcome_panel.PerformLayout();
            this.password_panel.ResumeLayout(false);
            this.password_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.welcome_pc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel welcome_panel;
        private System.Windows.Forms.Button start_bt;
        private System.Windows.Forms.Label welcome_label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox welcome_pc;
        private System.Windows.Forms.Label welcome_lb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel password_panel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button close_bt;
        private System.Windows.Forms.TextBox password_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label error_lb;
    }
}

