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
    public partial class ChangeForm : Form
    {
        private bool leader;
        private string surname;
        private double experience;
        private double wage_per_hour;
        private double minimum_hour;
        private double worked_hour;
        private Leader old_leader;
        public Leader new_leader;
        public Employee change_employee;
        private MainForm mainForm;
        public ChangeForm(bool is_leder, Employee employee)
        {
            InitializeComponent();
            mainForm = Owner as MainForm;
            leader = is_leder;
            if(leader)
            {
                Leader leader = employee as Leader;
                surname_pr.Text = leader.Surname;
                experience_pr.Text = leader.Experience.ToString();
                wage_per_hour_pr.Text = leader.Wage_per_hour.ToString();
                minimum_hour_pr.Text = leader.Minimum_amount_hour.ToString();
                leader_lb.Visible = false;
                leader_cb.Visible = false;
                worked_hour_lb.Visible = false;
                worked_hour_pr.Visible = false;

            }
            else
            {
                Programmer programmer = employee as Programmer;
                leader_cb.Visible = true;
                worked_hour_lb.Visible = true;
                worked_hour_pr.Visible = true;
                surname_pr.Text = programmer.Surname;
                experience_pr.Text = programmer.Experience.ToString();
                wage_per_hour_pr.Text = programmer.Wage_per_hour.ToString();
                minimum_hour_pr.Text = programmer.Minimum_amount_hour.ToString();
                worked_hour_pr.Text = programmer.HoursWorked.ToString();
                foreach (string i in Personal.ListOfLeaders())
                {
                    leader_cb.Items.Add(i);
                }
                old_leader = Personal.GetLeaderByEmployee(programmer);
                leader_cb.Text = old_leader.ToString();

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
                invalid_data_bt.Visible = true;
                invalid_data_bt.Location = new Point(400, tb.Location.Y);
                invalid_data_bt.Text = "Введіть числове значення";
                return 0.0;
            }
        }
        
        private void ParseData()
        {
            if(!leader)
            {
                if(worked_hour_pr.Text == string.Empty || leader_cb.Text == string.Empty)
                {
                    empty_entry.Visible = true;
                }
            }
            if (surname_pr.Text == string.Empty || experience_pr.Text == string.Empty || wage_per_hour_pr.Text == string.Empty
                    || minimum_hour_pr.Text == string.Empty)
            {
                empty_entry.Visible = true;
            }
            else
            {
                surname = surname_pr.Text;
                experience = TryParse(experience_pr);
                wage_per_hour = TryParse(wage_per_hour_pr);
                minimum_hour = TryParse(minimum_hour_pr);
                if (!leader)
                {
                    worked_hour = TryParse(worked_hour_pr);
                    if (leader_cb.Text != old_leader.ToString())
                    {
                        new_leader = Personal.CreateLeaderFromData(leader_cb.Text);
                    }
                }
                if (experience != 0.0 && wage_per_hour != 0.0 && minimum_hour != 0.0)
                {
                    if (leader)
                    {
                        change_employee = new Leader(surname, experience, wage_per_hour, minimum_hour);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        change_employee = new Programmer(surname, experience, wage_per_hour, minimum_hour, worked_hour);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }
        private void ok_bt_Click(object sender, EventArgs e)
        {
            ParseData();
        }

        private void back_bt_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
