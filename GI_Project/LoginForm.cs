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

        private void start_bt_Click(object sender, EventArgs e)
        {
            if(password_tb.Text == "LNu2023")
            {
                this.Hide();
                MainForm newForm = new MainForm();
                newForm.ShowDialog();
                this.Dispose();
            }
        }
    }
}

