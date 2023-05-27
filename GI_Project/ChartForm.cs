using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GI_Project
{
    public partial class ChartForm : Form
    {
        CancellationTokenSource source;
        IProgress<(string, int)> progress_leader;
        IProgress<(string, int)> progress_programmer;
        public ChartForm()
        {
            InitializeComponent();
            leader_prg.Maximum = Personal.CountLeader;
            programmer_prg.Maximum = Personal.CountProgrammer;
            progress_leader = new Progress<(string, int)>(
                 value =>
                 {
                     leader_lb.Text = value.Item1;
                     leader_prg.Value = value.Item2;
                 });
            progress_programmer = new Progress<(string, int)>(
                 value =>
                 {
                     programmer_lb.Text = value.Item1;
                     programmer_prg.Value = value.Item2;
                 });
        }
        private async void btnGenerateChart_Click(object sender, EventArgs e)
        {
            source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            Task programmer = Task.Run(() => BuildSalaryDistributionChartForEmployees());
            Task leader = Task.Run(() => BuildSalaryDistributionChartForLeaders());
            await Task.WhenAll(programmer, leader);
        }
        private void close_bt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void BuildSalaryDistributionChartForEmployees()
        {
            List<double> employeeSalaries = Personal.GetProgarammerSalaries();
            employeeSalaries.Sort();
            int employeeCount = employeeSalaries.Count;
            List<DataPoint> dataPoints = new List<DataPoint>();
            for (int i = 0; i < employeeCount; i++)
            {
                progress_programmer.Report(((i + 1).ToString() + "/" + employeeCount, (i + 1)));
                Thread.Sleep(200);
                double xValue = employeeSalaries[i];
                double yValue = (i + 1) / (double)employeeCount;
                dataPoints.Add(new DataPoint(xValue, yValue));
                BuildChart(programmers, "Функція розподілу для працівників", "Зарплата", "Ймовірність", dataPoints);
            }
        }

        private void BuildSalaryDistributionChartForLeaders()
        {
            List<double> leaderSalaries = Personal.GetLeaderSalaries();
            leaderSalaries.Sort();
            int leaderCount = leaderSalaries.Count;
            List<DataPoint> dataPoints = new List<DataPoint>();
            for (int i = 0; i < leaderCount; i++)
            {
                progress_leader.Report(((i + 1).ToString() + "/" + leaderCount, (i+1)));
                Thread.Sleep(200);
                double xValue = leaderSalaries[i];
                double yValue = (i + 1) / (double)leaderCount;
                dataPoints.Add(new DataPoint(xValue, yValue));
                BuildChart(leaders, "Функція розподілу для керівників", "Зарплата", "Ймовірність", dataPoints);
            }
        }

        private void BuildChart(Chart chart, string title, string xLabel, string yLabel, List<DataPoint> dataPoints)
        {
            if (chart.InvokeRequired)
            {
                chart.Invoke(new Action(() =>
                {
                    BuildChart(chart, title, xLabel, yLabel, dataPoints);
                }));
                return;
            }
            chart.Titles.Clear();
            chart.Titles.Add(title);
            chart.ChartAreas[0].AxisX.Title = xLabel;
            chart.ChartAreas[0].AxisY.Title = yLabel;
            chart.Series[0].Points.Clear();
            foreach (var dataPoint in dataPoints)
            {
                chart.Series[0].Points.Add(dataPoint);
            }
            chart.Update();
        }

        private void break_bt_Click(object sender, EventArgs e)
        {
            source.Cancel();
        }
    }
}
