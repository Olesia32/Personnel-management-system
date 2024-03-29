﻿using System;
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
    public partial class CreateForm : Form
    {
        public bool is_leader;
        private string surname;
        private double experience;
        private double wage_per_hour;
        private double minimum_hour;
        private double worked_hour;
        public Leader leader;
        public Leader new_leader;
        public Programmer new_programmer;

        public CreateForm()
        {
            InitializeComponent();
        }

        private void leader_bt_Click(object sender, EventArgs e)
        {
            is_leader = true;
            leader_panel.Visible = true;
            leader_panel.Enabled = true;
            programmer_panel.Visible = false;
            programmer_panel.Enabled = false;
            leader_bt.BackgroundImage = global::GI_Project.Properties.Resources.kisspng_web_page_sales_clip_art_landing_page_design_the_emissa_group_5b8d88a8a3ced72;
            programmer_bt.BackgroundImage = global::GI_Project.Properties.Resources._840131;
            leder_choise_panel.BackColor = Color.DarkCyan;
            programmer_choise_panel.BackColor = Color.GhostWhite;
            leader_lb.ForeColor = Color.GhostWhite;
            programmer_lb.ForeColor = Color.DarkCyan;
            programmer_bt.FlatAppearance.MouseOverBackColor = Color.GhostWhite;
            programmer_bt.FlatAppearance.MouseDownBackColor = Color.GhostWhite;
            leader_bt.FlatAppearance.MouseOverBackColor = Color.DarkCyan;
            leader_bt.FlatAppearance.MouseDownBackColor = Color.DarkCyan;
        }

        private void programmer_bt_Click(object sender, EventArgs e)
        {
            is_leader = false;
            programmer_panel.Visible = true;
            programmer_panel.Enabled = true;
            leader_panel.Visible = false;
            leader_panel.Enabled = false;
            programmer_bt.BackgroundImage = global::GI_Project.Properties.Resources._840131__2_;
            leader_bt.BackgroundImage = global::GI_Project.Properties.Resources.kisspng_web_page_sales_clip_art_landing_page_design_the_emissa_group_5b8d88a8a3ced71;
            leder_choise_panel.BackColor = Color.GhostWhite;
            programmer_choise_panel.BackColor = Color.DarkCyan;
            leader_lb.ForeColor = Color.DarkCyan;
            programmer_lb.ForeColor = Color.GhostWhite;
            programmer_bt.FlatAppearance.MouseOverBackColor = Color.DarkCyan;
            programmer_bt.FlatAppearance.MouseDownBackColor = Color.DarkCyan;
            leader_bt.FlatAppearance.MouseOverBackColor = Color.GhostWhite;
            leader_bt.FlatAppearance.MouseDownBackColor = Color.GhostWhite;
            foreach(string i in Personal.ListOfLeaders())
            {
                leader_cb.Items.Add(i);
            }
        }

        private void ParseLeaderData()
        {
            if (surname_ld.Text == string.Empty || experience_ld.Text == string.Empty || wage_per_hour_ld.Text == string.Empty
                    || minimum_hour_ld.Text == string.Empty)
            {
                empty_entry.Visible = true;
            }
            else
            {
                surname = surname_ld.Text;
                experience = TryParse(experience_ld);
                wage_per_hour = TryParse(wage_per_hour_ld);
                minimum_hour = TryParse(minimum_hour_ld);
                if (experience != 0.0 && wage_per_hour != 0.0 && minimum_hour != 0.0)
                {
                    new_leader = new Leader(surname, experience, wage_per_hour, minimum_hour);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void ParseProgrammerData()
        {
            if (surname_pr.Text == string.Empty || experience_pr.Text == string.Empty || wage_per_hour_pr.Text == string.Empty
                    || minimum_hour_pr.Text == string.Empty || worked_hour_pr.Text == string.Empty || leader_cb.Text == string.Empty)
            {
                empty_entry.Visible = true;
            }
            else
            {
                surname = surname_pr.Text;
                experience = TryParse(experience_pr);
                wage_per_hour = TryParse(wage_per_hour_pr);
                minimum_hour = TryParse(minimum_hour_pr);
                worked_hour = TryParse(worked_hour_pr);
                leader = new Leader();
                leader = Personal.CreateLeaderFromData(leader_cb.SelectedItem.ToString());
                if (experience != 0.0 && wage_per_hour != 0.0 && minimum_hour != 0.0 && worked_hour != 0.0 && leader_cb.Text != string.Empty)
                {
                    new_programmer = new Programmer(surname, experience, wage_per_hour, minimum_hour, worked_hour);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        private void ok_bt_Click(object sender, EventArgs e)
        {
            if (is_leader)
            {
                ParseLeaderData();
            }
            else
            {
                ParseProgrammerData();
            }
        }
        private double TryParse(TextBox tb)
        {
            try
            {
                return double.Parse(tb.Text);
            }
            catch
            {
                if (is_leader)
                {
                    invalid_data.Visible = true;
                    invalid_data.Location = new Point(400, tb.Location.Y);
                    invalid_data.Text = "Введіть числове значення";
                }
                else
                {
                    invalid_data_bt.Visible = true;
                    invalid_data_bt.Location = new Point(400, tb.Location.Y);
                    invalid_data_bt.Text = "Введіть числове значення";
                }
                return 0.0;
            }
        }
        private void back_bt_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}


