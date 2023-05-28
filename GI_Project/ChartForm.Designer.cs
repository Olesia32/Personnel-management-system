
namespace GI_Project
{
    partial class ChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.leaders = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.programmers = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_panel = new System.Windows.Forms.Panel();
            this.show_bt = new System.Windows.Forms.Button();
            this.programmer_lb = new System.Windows.Forms.Label();
            this.programmer_prg = new System.Windows.Forms.ProgressBar();
            this.leader_lb = new System.Windows.Forms.Label();
            this.leader_prg = new System.Windows.Forms.ProgressBar();
            this.close_bt = new System.Windows.Forms.Button();
            this.break_bt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.leaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programmers)).BeginInit();
            this.button_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leaders
            // 
            chartArea7.Name = "ChartArea1";
            this.leaders.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.leaders.Legends.Add(legend7);
            this.leaders.Location = new System.Drawing.Point(0, 0);
            this.leaders.Name = "leaders";
            this.leaders.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.leaders.Series.Add(series7);
            this.leaders.Size = new System.Drawing.Size(527, 383);
            this.leaders.TabIndex = 0;
            this.leaders.Text = "chart1";
            // 
            // programmers
            // 
            chartArea8.Name = "ChartArea1";
            this.programmers.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.programmers.Legends.Add(legend8);
            this.programmers.Location = new System.Drawing.Point(528, 0);
            this.programmers.Name = "programmers";
            this.programmers.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.programmers.Series.Add(series8);
            this.programmers.Size = new System.Drawing.Size(507, 383);
            this.programmers.TabIndex = 1;
            this.programmers.Text = "chart2";
            // 
            // button_panel
            // 
            this.button_panel.Controls.Add(this.break_bt);
            this.button_panel.Controls.Add(this.show_bt);
            this.button_panel.Controls.Add(this.programmer_lb);
            this.button_panel.Controls.Add(this.programmer_prg);
            this.button_panel.Controls.Add(this.leader_lb);
            this.button_panel.Controls.Add(this.leader_prg);
            this.button_panel.Controls.Add(this.close_bt);
            this.button_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_panel.Location = new System.Drawing.Point(0, 389);
            this.button_panel.Name = "button_panel";
            this.button_panel.Size = new System.Drawing.Size(1035, 146);
            this.button_panel.TabIndex = 2;
            // 
            // show_bt
            // 
            this.show_bt.BackColor = System.Drawing.Color.DarkCyan;
            this.show_bt.FlatAppearance.BorderSize = 0;
            this.show_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show_bt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.show_bt.ForeColor = System.Drawing.Color.GhostWhite;
            this.show_bt.Location = new System.Drawing.Point(736, 74);
            this.show_bt.Name = "show_bt";
            this.show_bt.Size = new System.Drawing.Size(147, 41);
            this.show_bt.TabIndex = 6;
            this.show_bt.Text = "Почати";
            this.show_bt.UseVisualStyleBackColor = false;
            this.show_bt.Click += new System.EventHandler(this.btnGenerateChart_Click);
            // 
            // programmer_lb
            // 
            this.programmer_lb.AutoSize = true;
            this.programmer_lb.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.programmer_lb.Location = new System.Drawing.Point(632, 21);
            this.programmer_lb.Name = "programmer_lb";
            this.programmer_lb.Size = new System.Drawing.Size(0, 17);
            this.programmer_lb.TabIndex = 5;
            // 
            // programmer_prg
            // 
            this.programmer_prg.Location = new System.Drawing.Point(728, 15);
            this.programmer_prg.Name = "programmer_prg";
            this.programmer_prg.Size = new System.Drawing.Size(155, 23);
            this.programmer_prg.TabIndex = 4;
            // 
            // leader_lb
            // 
            this.leader_lb.AutoSize = true;
            this.leader_lb.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.leader_lb.Location = new System.Drawing.Point(44, 21);
            this.leader_lb.Name = "leader_lb";
            this.leader_lb.Size = new System.Drawing.Size(0, 17);
            this.leader_lb.TabIndex = 3;
            // 
            // leader_prg
            // 
            this.leader_prg.Location = new System.Drawing.Point(140, 15);
            this.leader_prg.Name = "leader_prg";
            this.leader_prg.Size = new System.Drawing.Size(155, 23);
            this.leader_prg.TabIndex = 2;
            // 
            // close_bt
            // 
            this.close_bt.BackColor = System.Drawing.Color.DarkCyan;
            this.close_bt.FlatAppearance.BorderSize = 0;
            this.close_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_bt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.close_bt.ForeColor = System.Drawing.Color.GhostWhite;
            this.close_bt.Location = new System.Drawing.Point(148, 74);
            this.close_bt.Name = "close_bt";
            this.close_bt.Size = new System.Drawing.Size(147, 41);
            this.close_bt.TabIndex = 0;
            this.close_bt.Text = "Завершити";
            this.close_bt.UseVisualStyleBackColor = false;
            this.close_bt.Click += new System.EventHandler(this.close_bt_Click);
            // 
            // break_bt
            // 
            this.break_bt.BackColor = System.Drawing.Color.DarkCyan;
            this.break_bt.FlatAppearance.BorderSize = 0;
            this.break_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.break_bt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.break_bt.ForeColor = System.Drawing.Color.GhostWhite;
            this.break_bt.Location = new System.Drawing.Point(444, 74);
            this.break_bt.Name = "break_bt";
            this.break_bt.Size = new System.Drawing.Size(147, 41);
            this.break_bt.TabIndex = 7;
            this.break_bt.Text = "Перервати";
            this.break_bt.UseVisualStyleBackColor = false;
            this.break_bt.Click += new System.EventHandler(this.break_bt_Click);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1035, 535);
            this.Controls.Add(this.button_panel);
            this.Controls.Add(this.programmers);
            this.Controls.Add(this.leaders);
            this.Name = "ChartForm";
            this.Text = "Діаграма";
            ((System.ComponentModel.ISupportInitialize)(this.leaders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programmers)).EndInit();
            this.button_panel.ResumeLayout(false);
            this.button_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart leaders;
        private System.Windows.Forms.DataVisualization.Charting.Chart programmers;
        private System.Windows.Forms.Panel button_panel;
        private System.Windows.Forms.Button close_bt;
        private System.Windows.Forms.Button show_bt;
        private System.Windows.Forms.Label programmer_lb;
        private System.Windows.Forms.ProgressBar programmer_prg;
        private System.Windows.Forms.Label leader_lb;
        private System.Windows.Forms.ProgressBar leader_prg;
        private System.Windows.Forms.Button break_bt;
    }
}