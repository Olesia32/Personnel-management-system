
namespace GI_Project
{
    partial class ChangeForm
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
            this.programmer_panel = new System.Windows.Forms.Panel();
            this.invalid_data_bt = new System.Windows.Forms.Label();
            this.leader_lb = new System.Windows.Forms.Label();
            this.leader_cb = new System.Windows.Forms.ComboBox();
            this.worked_hour_pr = new System.Windows.Forms.TextBox();
            this.worked_hour_lb = new System.Windows.Forms.Label();
            this.surname_pr = new System.Windows.Forms.TextBox();
            this.wage_per_hour_pr = new System.Windows.Forms.TextBox();
            this.minimum_hour_pr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.experience_pr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ok_bt = new System.Windows.Forms.Button();
            this.back_bt = new System.Windows.Forms.Button();
            this.empty_entry = new System.Windows.Forms.Label();
            this.programmer_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // programmer_panel
            // 
            this.programmer_panel.Controls.Add(this.invalid_data_bt);
            this.programmer_panel.Controls.Add(this.leader_lb);
            this.programmer_panel.Controls.Add(this.leader_cb);
            this.programmer_panel.Controls.Add(this.worked_hour_pr);
            this.programmer_panel.Controls.Add(this.worked_hour_lb);
            this.programmer_panel.Controls.Add(this.surname_pr);
            this.programmer_panel.Controls.Add(this.wage_per_hour_pr);
            this.programmer_panel.Controls.Add(this.minimum_hour_pr);
            this.programmer_panel.Controls.Add(this.label1);
            this.programmer_panel.Controls.Add(this.label2);
            this.programmer_panel.Controls.Add(this.experience_pr);
            this.programmer_panel.Controls.Add(this.label3);
            this.programmer_panel.Controls.Add(this.label4);
            this.programmer_panel.Location = new System.Drawing.Point(65, 55);
            this.programmer_panel.Name = "programmer_panel";
            this.programmer_panel.Size = new System.Drawing.Size(548, 285);
            this.programmer_panel.TabIndex = 9;
            // 
            // invalid_data_bt
            // 
            this.invalid_data_bt.AutoSize = true;
            this.invalid_data_bt.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.invalid_data_bt.ForeColor = System.Drawing.Color.Red;
            this.invalid_data_bt.Location = new System.Drawing.Point(410, 75);
            this.invalid_data_bt.Name = "invalid_data_bt";
            this.invalid_data_bt.Size = new System.Drawing.Size(41, 16);
            this.invalid_data_bt.TabIndex = 19;
            this.invalid_data_bt.Text = "label5";
            this.invalid_data_bt.Visible = false;
            // 
            // leader_lb
            // 
            this.leader_lb.AutoSize = true;
            this.leader_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.leader_lb.ForeColor = System.Drawing.Color.DarkCyan;
            this.leader_lb.Location = new System.Drawing.Point(59, 19);
            this.leader_lb.Name = "leader_lb";
            this.leader_lb.Size = new System.Drawing.Size(69, 18);
            this.leader_lb.TabIndex = 18;
            this.leader_lb.Text = "Керівник";
            // 
            // leader_cb
            // 
            this.leader_cb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.leader_cb.ForeColor = System.Drawing.Color.DarkCyan;
            this.leader_cb.FormattingEnabled = true;
            this.leader_cb.Location = new System.Drawing.Point(228, 19);
            this.leader_cb.Name = "leader_cb";
            this.leader_cb.Size = new System.Drawing.Size(161, 29);
            this.leader_cb.TabIndex = 17;
            // 
            // worked_hour_pr
            // 
            this.worked_hour_pr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.worked_hour_pr.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.worked_hour_pr.ForeColor = System.Drawing.Color.DarkCyan;
            this.worked_hour_pr.Location = new System.Drawing.Point(228, 231);
            this.worked_hour_pr.Name = "worked_hour_pr";
            this.worked_hour_pr.Size = new System.Drawing.Size(161, 27);
            this.worked_hour_pr.TabIndex = 16;
            // 
            // worked_hour_lb
            // 
            this.worked_hour_lb.AutoSize = true;
            this.worked_hour_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.worked_hour_lb.ForeColor = System.Drawing.Color.DarkCyan;
            this.worked_hour_lb.Location = new System.Drawing.Point(55, 233);
            this.worked_hour_lb.Name = "worked_hour_lb";
            this.worked_hour_lb.Size = new System.Drawing.Size(158, 18);
            this.worked_hour_lb.TabIndex = 15;
            this.worked_hour_lb.Text = "Відпрацьовані години";
            // 
            // surname_pr
            // 
            this.surname_pr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.surname_pr.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.surname_pr.ForeColor = System.Drawing.Color.DarkCyan;
            this.surname_pr.Location = new System.Drawing.Point(228, 72);
            this.surname_pr.Name = "surname_pr";
            this.surname_pr.Size = new System.Drawing.Size(161, 27);
            this.surname_pr.TabIndex = 12;
            // 
            // wage_per_hour_pr
            // 
            this.wage_per_hour_pr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wage_per_hour_pr.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wage_per_hour_pr.ForeColor = System.Drawing.Color.DarkCyan;
            this.wage_per_hour_pr.Location = new System.Drawing.Point(228, 150);
            this.wage_per_hour_pr.Name = "wage_per_hour_pr";
            this.wage_per_hour_pr.Size = new System.Drawing.Size(161, 27);
            this.wage_per_hour_pr.TabIndex = 11;
            // 
            // minimum_hour_pr
            // 
            this.minimum_hour_pr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minimum_hour_pr.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.minimum_hour_pr.ForeColor = System.Drawing.Color.DarkCyan;
            this.minimum_hour_pr.Location = new System.Drawing.Point(228, 190);
            this.minimum_hour_pr.Name = "minimum_hour_pr";
            this.minimum_hour_pr.Size = new System.Drawing.Size(161, 27);
            this.minimum_hour_pr.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(55, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Обов\'язкові години";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(55, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Оплата за годину";
            // 
            // experience_pr
            // 
            this.experience_pr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.experience_pr.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.experience_pr.ForeColor = System.Drawing.Color.DarkCyan;
            this.experience_pr.Location = new System.Drawing.Point(228, 110);
            this.experience_pr.Name = "experience_pr";
            this.experience_pr.Size = new System.Drawing.Size(161, 27);
            this.experience_pr.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(55, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Стаж";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(55, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Прізвище";
            // 
            // ok_bt
            // 
            this.ok_bt.BackColor = System.Drawing.Color.DarkCyan;
            this.ok_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok_bt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ok_bt.ForeColor = System.Drawing.Color.Ivory;
            this.ok_bt.Location = new System.Drawing.Point(365, 373);
            this.ok_bt.Name = "ok_bt";
            this.ok_bt.Size = new System.Drawing.Size(125, 40);
            this.ok_bt.TabIndex = 20;
            this.ok_bt.Text = "Продовжити";
            this.ok_bt.UseVisualStyleBackColor = false;
            this.ok_bt.Click += new System.EventHandler(this.ok_bt_Click);
            // 
            // back_bt
            // 
            this.back_bt.BackColor = System.Drawing.Color.DarkCyan;
            this.back_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_bt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.back_bt.ForeColor = System.Drawing.Color.Ivory;
            this.back_bt.Location = new System.Drawing.Point(175, 373);
            this.back_bt.Name = "back_bt";
            this.back_bt.Size = new System.Drawing.Size(125, 40);
            this.back_bt.TabIndex = 21;
            this.back_bt.Text = "Скасувати";
            this.back_bt.UseVisualStyleBackColor = false;
            this.back_bt.Click += new System.EventHandler(this.back_bt_Click);
            // 
            // empty_entry
            // 
            this.empty_entry.AutoSize = true;
            this.empty_entry.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.empty_entry.ForeColor = System.Drawing.Color.Red;
            this.empty_entry.Location = new System.Drawing.Point(258, 343);
            this.empty_entry.Name = "empty_entry";
            this.empty_entry.Size = new System.Drawing.Size(128, 17);
            this.empty_entry.TabIndex = 22;
            this.empty_entry.Text = "Заповніть усі поля!";
            this.empty_entry.Visible = false;
            // 
            // ChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(681, 450);
            this.Controls.Add(this.empty_entry);
            this.Controls.Add(this.ok_bt);
            this.Controls.Add(this.back_bt);
            this.Controls.Add(this.programmer_panel);
            this.Name = "ChangeForm";
            this.Text = "Змінити дані працівника";
            this.programmer_panel.ResumeLayout(false);
            this.programmer_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel programmer_panel;
        private System.Windows.Forms.Label leader_lb;
        private System.Windows.Forms.ComboBox leader_cb;
        private System.Windows.Forms.TextBox worked_hour_pr;
        private System.Windows.Forms.Label worked_hour_lb;
        private System.Windows.Forms.TextBox surname_pr;
        private System.Windows.Forms.TextBox wage_per_hour_pr;
        private System.Windows.Forms.TextBox minimum_hour_pr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox experience_pr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ok_bt;
        private System.Windows.Forms.Button back_bt;
        private System.Windows.Forms.Label empty_entry;
        private System.Windows.Forms.Label invalid_data_bt;
    }
}