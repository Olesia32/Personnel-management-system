using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GI_Project
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int windowWidth = this.Width;
            panel1.Width = windowWidth / 3;
            welcome_panel.Width = (windowWidth * 2) / 3;
        }

        private void close_bt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void password_panel_MouseEnter(object sender, EventArgs e)
        {
            password_panel.BackColor = Color.White;
            password_tb.BackColor = Color.White;
        }

        private void password_panel_MouseLeave(object sender, EventArgs e)
        {
            password_panel.BackColor = Color.GhostWhite;
            password_tb.BackColor = Color.GhostWhite;
        }


        private void password_tb_MouseClick(object sender, MouseEventArgs e)
        {
            password_tb.Text = string.Empty;
            password_tb.UseSystemPasswordChar = true;
        }
        // Пароль Lnu2023
        private void start_bt_Click(object sender, EventArgs e)
        {
            if (Personal.CheckPassword(password_tb.Text))
            {
                this.DialogResult = DialogResult.OK;
                error_lb.Visible = false;
                password_tb.Text = "Пароль";
                password_tb.UseSystemPasswordChar = false;
            }
            else
            {
                error_lb.Visible = true;
            }
        }

    }
}

