using System.ComponentModel;

namespace WindowsFormsApp2
{
    partial class Add_student_view
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.student_FIO = new System.Windows.Forms.TextBox();
            this.student_speciality = new System.Windows.Forms.TextBox();
            this.Fio = new System.Windows.Forms.Label();
            this.group_student = new System.Windows.Forms.Label();
            this.student_spicality = new System.Windows.Forms.Label();
            this.student_group_enter = new System.Windows.Forms.TextBox();
            this.add_student = new System.Windows.Forms.Button();
            this.Generate_student = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // student_FIO
            // 
            this.student_FIO.Location = new System.Drawing.Point(61, 105);
            this.student_FIO.Name = "student_FIO";
            this.student_FIO.Size = new System.Drawing.Size(220, 22);
            this.student_FIO.TabIndex = 0;
            this.student_FIO.TextChanged += new System.EventHandler(this.student_FIO_TextChanged);
            // 
            // student_speciality
            // 
            this.student_speciality.Location = new System.Drawing.Point(59, 314);
            this.student_speciality.Name = "student_speciality";
            this.student_speciality.Size = new System.Drawing.Size(220, 22);
            this.student_speciality.TabIndex = 2;
            this.student_speciality.TextChanged += new System.EventHandler(this.student_speciality_TextChanged);
            // 
            // Fio
            // 
            this.Fio.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Fio.Location = new System.Drawing.Point(61, 65);
            this.Fio.Name = "Fio";
            this.Fio.Size = new System.Drawing.Size(218, 31);
            this.Fio.TabIndex = 3;
            this.Fio.Text = "ФИО Студента";
            this.Fio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Fio.Click += new System.EventHandler(this.Fio_Click);
            // 
            // group_student
            // 
            this.group_student.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.group_student.Location = new System.Drawing.Point(59, 168);
            this.group_student.Name = "group_student";
            this.group_student.Size = new System.Drawing.Size(217, 32);
            this.group_student.TabIndex = 4;
            this.group_student.Text = "Группа студента";
            this.group_student.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.group_student.Click += new System.EventHandler(this.group_student_Click);
            // 
            // student_spicality
            // 
            this.student_spicality.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.student_spicality.Location = new System.Drawing.Point(59, 273);
            this.student_spicality.Name = "student_spicality";
            this.student_spicality.Size = new System.Drawing.Size(217, 26);
            this.student_spicality.TabIndex = 5;
            this.student_spicality.Text = "Специальность студента";
            this.student_spicality.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.student_spicality.Click += new System.EventHandler(this.student_spicality_Click);
            // 
            // student_group_enter
            // 
            this.student_group_enter.Location = new System.Drawing.Point(60, 216);
            this.student_group_enter.Name = "student_group_enter";
            this.student_group_enter.Size = new System.Drawing.Size(215, 22);
            this.student_group_enter.TabIndex = 6;
            this.student_group_enter.TextChanged += new System.EventHandler(this.student_group_enter_TextChanged);
            // 
            // add_student
            // 
            this.add_student.BackColor = System.Drawing.SystemColors.HighlightText;
            this.add_student.Location = new System.Drawing.Point(43, 374);
            this.add_student.Name = "add_student";
            this.add_student.Size = new System.Drawing.Size(130, 51);
            this.add_student.TabIndex = 7;
            this.add_student.Text = "Добавить студента";
            this.add_student.UseVisualStyleBackColor = false;
            this.add_student.Click += new System.EventHandler(this.add_student_Click_1);
            // 
            // Generate_student
            // 
            this.Generate_student.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Generate_student.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Generate_student.Location = new System.Drawing.Point(180, 374);
            this.Generate_student.Name = "Generate_student";
            this.Generate_student.Size = new System.Drawing.Size(115, 50);
            this.Generate_student.TabIndex = 8;
            this.Generate_student.Text = "Сгенерировать студента";
            this.Generate_student.UseVisualStyleBackColor = false;
            this.Generate_student.Click += new System.EventHandler(this.Generate_student_Click);
            // 
            // Add_student_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(341, 450);
            this.Controls.Add(this.Generate_student);
            this.Controls.Add(this.add_student);
            this.Controls.Add(this.student_group_enter);
            this.Controls.Add(this.student_spicality);
            this.Controls.Add(this.group_student);
            this.Controls.Add(this.Fio);
            this.Controls.Add(this.student_speciality);
            this.Controls.Add(this.student_FIO);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add_student_view";
            this.Text = "Add_student_view";
            this.Load += new System.EventHandler(this.Add_student_view_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button Generate_student;

        private System.Windows.Forms.Button add_student;

        private System.Windows.Forms.TextBox student_group_enter;

        private System.Windows.Forms.Label student_spicality;

        private System.Windows.Forms.TextBox student_FIO;
        private System.Windows.Forms.TextBox student_speciality;
        private System.Windows.Forms.Label Fio;
        private System.Windows.Forms.Label group_student;

        #endregion
    }
}