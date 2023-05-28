using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GI_Project
{
    public partial class MainForm : Form
    {
        private bool is_leaders;
        private string path;
        private DataGridView current_dgv;
        private bool show_click;
        private bool is_changed;
        private bool is_new_file;
        private bool is_log;
        private string message;

        public MainForm()
        {
            InitializeComponent();
            path = @"../../Files/default.txt";
            LoadData("txt");
            current_dgv = leaders_dgv;
            is_leaders = true;
            show_click = false;
            is_new_file = false;
            is_changed = false;
            is_log = false;
            message = "Доступно записів: ";
            UpdateInfo();
        }
        private void LoadData(string format)
        {
            Personal.Clear();
            Personal.ClearLog();
            switch(format)
            {
                case "txt":
                    Personal.ReadDataFromFile(path);
                    break;
                case "binary":
                    Personal.ReadFromBinaryFile(path);
                    break;
                case "xml":
                    Personal.ReadFromXmlFile(path);
                    break;
                case "json":
                    Personal.ReadFromJsonFile(path);
                    break;
            }
            DGV_Filling(Personal.ToArray(true), leaders_dgv);
            DGV_Filling(Personal.ToArray(false), programmers_dgv);   
        }
        
        private void DGV_Filling(object[] array, DataGridView data)
        {
            current_status.Text = "Додавання даних.";
            foreach (object[] i in array)
            {
                data.Rows.Add(i);
                UpdateInfo();
            }
            current_status.Text = "Відображення даних.";
        }
        private void create_bt_Click(object sender, EventArgs e)
        {
            CreateForm create = new CreateForm();
            DialogResult result = create.ShowDialog();
            if(result == DialogResult.OK)
            {
                if (create.is_leader && create.new_leader != null)
                {
                    Personal.AddNewLeader(create.new_leader);
                    leaders_dgv.Rows.Add(create.new_leader.Surname, create.new_leader.Experience, create.new_leader.Wage_per_hour,
                        create.new_leader.Minimum_amount_hour, create.new_leader.Salary());
                    NewMessage($"Створено керівника {create.new_leader.ToString()} ");
                }
                else if (!create.is_leader && create.new_programmer != null)
                {
                    Personal.AddNewEmployee(create.leader, create.new_programmer);
                    programmers_dgv.Rows.Add(create.new_programmer.Surname, create.new_programmer.Experience, create.new_programmer.Wage_per_hour,
                        create.new_programmer.Minimum_amount_hour, create.new_programmer.HoursWorked, create.new_programmer.Salary());
                    NewMessage($"Створено програміста {create.new_programmer.ToString()} ");
                }
                is_changed = true;
                UpdateInfo();
            }
            create.Dispose();
        }

        private void delete_bt_Click(object sender, EventArgs e)
        {
            int index = -1;
            try
            {
                index = current_dgv.SelectedRows[0].Index;
            }
            catch
            {
                error_lb.Text = "Оберіть рядок";
            }
            if (index >= 0 && !show_click)
            {
                DialogResult result = MessageBox.Show("Ви дійсно хочете видалити працівника?", "Видалення працівника", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    error_lb.Text = string.Empty;
                    DataGridViewCellCollection data = current_dgv.Rows[index].Cells;
                    if (is_leaders)
                    {
                        Leader leader = CreateLeader(data);
                        Personal.DeleteLeader(leader);
                        NewMessage($"Видалено керівника {leader.ToString()}");
                    }
                    else
                    {
                        Programmer programmer = CreateProgrammer(data);
                        Personal.DeleteEmployee(programmer);
                        NewMessage($"Видалено працівника {programmer.ToString()} ");
                    }
                    current_dgv.Rows.RemoveAt(index);
                    is_changed = true;
                    UpdateInfo();
                }
            }
        }

        public Leader CreateLeader(DataGridViewCellCollection data)
        {
            Leader leader = new Leader(data[0].Value.ToString(), double.Parse(data[1].Value.ToString()), double.Parse(data[2].Value.ToString()),
                    double.Parse(data[3].Value.ToString()));
            return leader;
        }
        public Programmer CreateProgrammer(DataGridViewCellCollection data)
        {
            Programmer programmer = new Programmer(data[0].Value.ToString(), double.Parse(data[1].Value.ToString()), double.Parse(data[2].Value.ToString()),
                    double.Parse(data[3].Value.ToString()), double.Parse(data[4].Value.ToString()));
            return programmer;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if(is_log) Personal.StoreLog();
            else Personal.WriteDataToFile(path);
        }

        private void create_bt_MouseEnter(object sender, EventArgs e)
        {
            create_bt.BackColor = Color.DarkCyan;
        }

        private void create_bt_MouseLeave(object sender, EventArgs e)
        {
            create_bt.BackColor = Color.DimGray;
        }

        private void change_bt_MouseEnter(object sender, EventArgs e)
        {
            change_bt.BackColor = Color.DarkCyan;
        }

        private void change_bt_MouseLeave(object sender, EventArgs e)
        {
            change_bt.BackColor = Color.DimGray;
        }

        private void delete_bt_MouseEnter(object sender, EventArgs e)
        {
            delete_bt.BackColor = Color.DarkCyan;
        }

        private void delete_bt_MouseLeave(object sender, EventArgs e)
        {
            delete_bt.BackColor = Color.DimGray;
        }

        private void search_bt_MouseEnter(object sender, EventArgs e)
        {
            search_bt.BackColor = Color.DarkCyan;
        }

        private void search_bt_MouseLeave(object sender, EventArgs e)
        {
            search_bt.BackColor = Color.DimGray;
        }

        private void leader_bt_Click(object sender, EventArgs e)
        {
            leder_choise_panel.BackColor = Color.DimGray;
            programmer_choise_panel.BackColor = Color.DarkSlateGray;
            is_leaders = true;
            current_dgv = leaders_dgv;
            leader_bt.BackgroundImage = global::GI_Project.Properties.Resources.ld_white_gray1;
            programmer_bt.BackgroundImage = global::GI_Project.Properties.Resources.pr_white_gray1;
            programmer_bt.FlatAppearance.MouseOverBackColor = Color.DarkSlateGray;
            programmer_bt.FlatAppearance.MouseDownBackColor = Color.DarkSlateGray;
            leader_bt.FlatAppearance.MouseOverBackColor = Color.DimGray;
            leader_bt.FlatAppearance.MouseDownBackColor = Color.DimGray;
            leaders_dgv.Visible = true;
            programmers_dgv.Visible = false;
            search_bt.Text = "Показати підлеглих";
        }

        private void programmer_bt_Click(object sender, EventArgs e)
        {
            is_leaders = false;
            current_dgv = programmers_dgv;
            leder_choise_panel.BackColor = Color.DarkSlateGray;
            programmer_choise_panel.BackColor = Color.DimGray;
            programmer_bt.BackgroundImage = global::GI_Project.Properties.Resources.pr_white_gray;
            leader_bt.BackgroundImage = global::GI_Project.Properties.Resources.ld_white_gray2;
            programmer_bt.FlatAppearance.MouseOverBackColor = Color.DimGray;
            programmer_bt.FlatAppearance.MouseDownBackColor = Color.DimGray;
            leader_bt.FlatAppearance.MouseOverBackColor = Color.DarkSlateGray;
            leader_bt.FlatAppearance.MouseDownBackColor = Color.DarkSlateGray;
            leaders_dgv.Visible = false;
            programmers_dgv.Visible = true;
            search_bt.Text = "Показати керівника";
        }

        private void search_bt_Click(object sender, EventArgs e)
        {
            if (!show_click)
            {
                int index = -1;
                try
                {
                    index = current_dgv.SelectedRows[0].Index;
                }
                catch
                {
                    error_lb.Text = "Оберіть рядок";
                }
                if (index >= 0)
                {
                    error_lb.Text = string.Empty;
                    show_click = true;
                    if (is_leaders)
                    {
                        Leader leader = CreateLeader(current_dgv.Rows[index].Cells);
                        if (Personal.GetEmployeesByLeader(leader) != null)
                        {
                            foreach (Programmer i in Personal.GetEmployeesByLeader(leader))
                            {
                                var k = i.ToArray();
                                leaders_junior_dgv.Rows.Add(i.ToArray());
                            }
                        }
                        leaders_junior_dgv.Visible = true;
                        current_dgv = leaders_junior_dgv;
                        search_bt.Text = "Приховати підлеглих";
                        leaders_dgv.Visible = false;
                    }
                    else
                    {
                        Programmer programmer = CreateProgrammer(current_dgv.Rows[index].Cells);
                        programmers_leader_dgv.Rows.Add(Personal.GetLeaderByEmployee(programmer).ToArray());
                        programmers_leader_dgv.Visible = true;
                        current_dgv = programmers_leader_dgv;
                        search_bt.Text = "Приховати керівника";
                        programmers_dgv.Visible = false;
                    }
                }
            }
            else
            {
                show_click = false;
                if (is_leaders)
                {
                    search_bt.Text = "Показати підлеглих";
                    ClearDataGridView(leaders_junior_dgv);
                    leaders_junior_dgv.Visible = false;
                    leaders_dgv.Visible = true;
                    current_dgv = leaders_dgv;
                }
                else
                {
                    search_bt.Text = "Показати керівника";
                    ClearDataGridView(programmers_leader_dgv);
                    programmers_leader_dgv.Visible = false;
                    programmers_dgv.Visible = true;
                    current_dgv = programmers_dgv;
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_status.Text = "Збереження даних.";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1: Personal.WriteDataToFile(saveFileDialog1.FileName); break;
                    case 2: Personal.WriteToBinaryFile(saveFileDialog1.FileName); break;
                    case 3: Personal.WriteToXmlFile(saveFileDialog1.FileName); break;
                    case 4: Personal.WriteToJsonFile(saveFileDialog1.FileName); break;
                }
            }
            current_status.Text = "Відображення даних.";
        }
        private void ClearDataGridView(DataGridView dgv)
        {
            while(dgv.Rows.Count != 0)
            {
                dgv.Rows.Remove(dgv.Rows[dgv.Rows.Count - 1]);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDataGridView(leaders_dgv);
            ClearDataGridView(programmers_dgv);
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                if (File.Exists(fileName))
                {
                    try
                    {
                        switch (Path.GetExtension(fileName))
                        {
                            case ".txt": path = fileName;  LoadData("txt"); break;
                            case ".bin": path = fileName; LoadData("binary"); break;
                            case ".soap": path = fileName; LoadData("soap"); break;
                            case ".xml": path = fileName; LoadData("xml"); break;
                            case ".json": path = fileName; LoadData("json"); break;
                            default:
                                MessageBox.Show("Файл невідомого формату", "Помилка імені файла",
                           MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Сталася помилка читання з файла.\n  Ім'я: {openFileDialog1.FileName}\n  Помилка: {ex.Message}", "Помилка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else MessageBox.Show($"Файл {openFileDialog1.FileName} не існує.\nОберіть файл з наявних.",
                    "Помилка імені файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void change_bt_Click(object sender, EventArgs e)
        {
            int index = -1;
            try
            {
                index = current_dgv.SelectedRows[0].Index;
            }
            catch
            {
                error_lb.Text = "Оберіть рядок";
            }
            if (index >= 0 && !show_click)
            {
                error_lb.Text = string.Empty;
                Employee employee = new Employee();
                if (is_leaders)
                {
                    employee = CreateLeader(current_dgv.Rows[index].Cells);
                }
                else
                {
                    employee = CreateProgrammer(current_dgv.Rows[index].Cells);
                }
                current_dgv.Rows.RemoveAt(index);
                ChangeForm change = new ChangeForm(is_leaders, employee);
                change.Owner = this;
                DialogResult result = change.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (is_leaders)
                    {
                        Leader change_employee = change.change_employee as Leader;
                        Personal.UpdateEmployee(true, employee as Leader, change.change_employee);
                        current_dgv.Rows.Insert(index, change_employee.Surname, change_employee.Experience,
                            change_employee.Wage_per_hour, change_employee.Minimum_amount_hour,
                            change_employee.Salary());
                        NewMessage($"Змінено інформацію про керівника {change_employee.ToString()}");
                    }
                    else
                    {
                        Programmer change_employee = change.change_employee as Programmer;
                        if (change.new_leader == null)
                        {
                            Personal.UpdateEmployee(false, employee as Programmer, change.change_employee);
                        }
                        else
                        {
                            Personal.DeleteEmployee(employee as Programmer);
                            Personal.AddNewEmployee(change.new_leader, change_employee);
                        }
                        current_dgv.Rows.Insert(index, change_employee.Surname, change_employee.Experience,
                            change_employee.Wage_per_hour, change_employee.Minimum_amount_hour, change_employee.HoursWorked,
                            change_employee.Salary());
                        NewMessage($"Змінено інформацію про працівника {change_employee.ToString()}");
                    }
                    is_changed = true;
                }
                change.Dispose();
            }
        }
        private void UpdateInfo()
        {
            status_lb.Text = message + (Personal.CountLeader + Personal.CountProgrammer).ToString();
        }

        private void close_bt_MouseEnter(object sender, EventArgs e)
        {
            close_bt.BackColor = Color.DarkCyan;
        }

        private void close_bt_MouseLeave(object sender, EventArgs e)
        {
            close_bt.BackColor = Color.DimGray;
        }

        private void close_bt_Click(object sender, EventArgs e)
        {
            Personal.StoreLog();
            if (is_new_file)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else if (is_changed)
            {
                DialogResult result = MessageBox.Show("Чи бажаєте зберегти зміни?", "Збереження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    saveToolStripButton_Click(sender, e);
                }
            }
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(is_log)
            {
                Personal.ClearLog();
                log_list_box.DataSource = null;
                log_list_box.DataSource = Personal.log;
            }
            is_new_file = true;
            Personal.Clear();
            ClearDataGridView(leaders_dgv);
            ClearDataGridView(programmers_dgv);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_status.Text = "Друк";
            DialogResult result = printPreviewDialog1.ShowDialog();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (is_log)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in log_list_box.Items)
                {
                    stringBuilder.AppendLine(item.ToString());
                }

                Clipboard.SetText(stringBuilder.ToString());
            }
            else
            {
                selectAllToolStripMenuItem_Click(sender, e);
                Clipboard.SetDataObject(current_dgv.GetClipboardContent());
                current_dgv.ClearSelection();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_status.Text = "Виділено всі дані";
            current_dgv.SelectAll();
            current_status.Text = "Відображення даних";
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int height = current_dgv.Height;
            current_dgv.Height = current_dgv.RowCount * current_dgv.RowTemplate.Height * 2;
            Bitmap bmp = new Bitmap(current_dgv.Width, current_dgv.Height);
            current_dgv.DrawToBitmap(bmp, new Rectangle(0, 0, current_dgv.Width, current_dgv.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
            current_dgv.Height = height;
        }

        private void log_bt_MouseEnter(object sender, EventArgs e)
        {
            log_bt.BackColor = Color.DarkCyan;
        }

        private void log_bt_MouseLeave(object sender, EventArgs e)
        {
            log_bt.BackColor = Color.DimGray;
        }

        private void log_bt_Click(object sender, EventArgs e)
        {
            if (!is_log)
            {
                current_status.Text = "Журнал операцій";
                is_log = true;
                create_bt.Enabled = false;
                delete_bt.Enabled = false;
                change_bt.Enabled = false;
                search_bt.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                printToolStripMenuItem.Enabled = false;
                printToolStripButton.Enabled = false;
                openToolStripButton.Enabled = false;
                openToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;
                leader_bt.Enabled = false;
                programmer_bt.Enabled = false;
                current_dgv.Visible = false;
                result_panel.Visible = true;
                button_box.Visible = true;
                log_panel.Visible = true;
                log_bt.Text = "Приховати журнал операцій";
            }
            else
            {
                current_status.Text = "Відображення даних";
                is_log = false;
                create_bt.Enabled = true;
                delete_bt.Enabled = true;
                change_bt.Enabled = true;
                search_bt.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                printToolStripMenuItem.Enabled = true;
                printToolStripButton.Enabled = true;
                openToolStripButton.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
                openToolStripMenuItem.Enabled = true;
                leader_bt.Enabled = true;
                programmer_bt.Enabled = true;
                current_dgv.Visible = true;
                result_panel.Visible = false;
                button_box.Visible = false;
                log_panel.Visible = false;
                log_bt.Text = "Журнал операцій";
            }
        }

        private void av_salary_Click(object sender, EventArgs e)
        {
            NewMessage(string.Format("Середня зарплата працівників складає: {0:0.00} UAN.", Personal.CalculateAverageSalary()));  
        }
        private void av_experience_Click(object sender, EventArgs e)
        {
            NewMessage(string.Format("Середній досвід працівників складає: {0:0.00} років.", Personal.CalculateAverage("Experience")));
        }
        private void NewMessage(string message)
        {
            show_label.Text = message;
            Personal.AddNewRecordToLog(message);
            log_list_box.DataSource = null;
            log_list_box.DataSource = Personal.log;
        }

        private void av_wage_per_hour_Click(object sender, EventArgs e)
        {
            NewMessage(string.Format("Середня оплата за годину для працівників складає: {0:0.00} UAN.", Personal.CalculateAverage("Wage_per_hour")));

        }

        private void av_minimum_hour_Click(object sender, EventArgs e)
        {
            NewMessage(string.Format("Середня обов'язкова кількість годин для працівників складає: {0:0.00}.", Personal.CalculateAverage("Minimum_amount_hour")));

        }

        private void av_worked_hour_Click(object sender, EventArgs e)
        {
            NewMessage(string.Format("Середня кількість відпрацьованих годин серед програмістів складає: {0:0.00}.", Personal.CalculateAverage("HoursWorked")));

        }

        private void sum_salary_Click(object sender, EventArgs e)
        {
            NewMessage(string.Format("Загальна сума виплачена працівникам складає: {0:0.00} UAN.", Personal.CalculateTotalSalary()));

        }

        private void sum_worked_hour_Click(object sender, EventArgs e)
        {
            NewMessage(string.Format("Загальна кількість відпрацьованих годин серед програмістів складає: {0:0.00}.", Personal.CalculateSum("HoursWorked")));

        }

        private void max_salary_Click(object sender, EventArgs e)
        {
            NewMessage(string.Format("Найвища зарплата складає: {0:0.00} UAN.", Personal.FindMaxSalary()));
        }

        private void min_salary_Click(object sender, EventArgs e)
        {
            NewMessage(string.Format("Найнижча зарплата складає: {0:0.00} UAN.", Personal.FindMinSalary()));
        }

        private void max_employee_Click(object sender, EventArgs e)
        {
            NewMessage(string.Format("Найвисокооплачуваний працівник: {0}.", Personal.FindHighestPaidEmployee().ToString()));

        }

        private void diagram_bt_Click(object sender, EventArgs e)
        {
            ChartForm chart = new ChartForm();
            DialogResult result = chart.ShowDialog();
            if(result == DialogResult.OK)
            {
                chart.Dispose();
            }
        }

        private void diagram_bt_MouseEnter(object sender, EventArgs e)
        {
            diagram_bt.BackColor = Color.DarkCyan;
        }

        private void diagram_bt_MouseLeave(object sender, EventArgs e)
        {
            diagram_bt.BackColor = Color.DimGray;
        } 
    }
}
